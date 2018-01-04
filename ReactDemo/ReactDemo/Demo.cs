//#define Original
//#define Test
#if Original
#region Original
using System;
using Bridge;
using Retyped;
using static Retyped.dom;
using static Retyped.react.React;
using static Retyped.react_dom;

namespace ReactDemo
{
    using DivAttr = HTMLAttributes<HTMLDivElement>;
    using InputAttr = ChangeTargetHTMLAttributes<HTMLInputElement>;
    using ButtonAttr = ChangeTargetHTMLAttributes<HTMLButtonElement>;

    public class Demo
    {
        public static void Main()
        {
            var root = document.getElementById("root");

            var formProps = new MessageEntryForm.Props
            {
                Label = "Text:",
                OnSave = value => System.Console.WriteLine($"Entered value: '{value}'.")
            };

            var formEl = createElement(MessageEntryForm.Class, formProps);
            render(formEl, root);
        }
    }

    public class MessageEntryForm : Component<MessageEntryForm.Props, MessageEntryForm.State>
    {
        public static ComponentClass<Props> Class => typeof(MessageEntryForm).As<ComponentClass<Props>>();

        public new Props props => base.props.As<Props>();

        public new State state
        {
            get { return base.state.As<State>(); }
            set { base.state = value.As<es5.Readonly<State>>(); }
        }
    
        public MessageEntryForm(Props p)
            : base(p)
        {
            state = new State { Value = "" };
        }

        [Name("render")]
        public ReactElement<HTMLAttributes<HTMLDivElement>> Render()
        {
            // Create label:
            Intersection<ClassAttributes<HTMLLabelElement>, HTMLAttributes<HTMLLabelElement>> labelConfig =
                new ClassAttributes<HTMLLabelElement>
                {
                    key = "label1"
                };
            var labelNode = DOM.label.Self(labelConfig, props.Label).AsNode();

            // Create input:
            Intersection<ClassAttributes<HTMLInputElement>, ChangeTargetHTMLAttributes<HTMLInputElement>> inputConfig =
                new ChangeTargetHTMLAttributes<HTMLInputElement>
                {
                    style = new CSSProperties
                    {
                        marginLeft = 20,
                    },
                    value = state.Value,
                    onChange = Handler.ChangeEvent<HTMLInputElement>(e =>
                    {
                        setState(new State { Value = e.currentTarget.Type2.value});
                    })
                };
            inputConfig.Type1.key = "input1";
            var inputNode = DOM.input.Self(inputConfig).AsNode();

            // Create button:
            Intersection<ClassAttributes<HTMLButtonElement>, HTMLAttributes<HTMLButtonElement>> buttonConfig =
                new HTMLAttributes<HTMLButtonElement>
                {
                    style = new CSSProperties
                    {
                        height = 28,
                        width = 150,
                        marginLeft = 20,
                    },
                    dangerouslySetInnerHTML = new DOMAttributes<HTMLButtonElement>.dangerouslySetInnerHTMLConfig()
                    {
                        __html =string.IsNullOrWhiteSpace(state.Value) ? "Enter text" : "Print to Console",
                    },
                    disabled = string.IsNullOrWhiteSpace(state.Value),
                    onClick = Handler.MouseEvent<HTMLButtonElement>(e => props.OnSave(state.Value))
                };
            buttonConfig.Type1.key = "button1";
            var buttonNode = DOM.button.Self(buttonConfig).AsNode();

            // Create div:
            var div = DOM.div.Self(new HTMLAttributes<HTMLDivElement> { className = "wrapper" }, new [] {
                labelNode,
                inputNode,
                buttonNode});

            return div;
        }

        [ObjectLiteral]
        public class Props
        {
            public string Label;
            public Action<string> OnSave;
        }

        [ObjectLiteral]
        public class State : es5.Pick<State, KeyOf<State>>
        {
            public string Value;
        }
    }

    [External]
    public static class ExtensionsX
    {
        /// <summary>
        /// Converts DOMElement -> ReactNode.
        /// </summary>
        [Template("{0}")]
        public static extern ReactNode AsNode<P, T>(this DOMElement<P, T> el)
            where P : DOMAttributes<T>
            where T : Element;
    }

   
}

#endregion
#elif Test

using System;
using System.Linq.Expressions;
using Bridge;
using Retyped;


namespace ReactDemo
{

    public class Demo
    {
        public static void Main()
        {
            Test(x => x.Label);
        }

        private static void Test<TValue>(Expression<Func<TestClass, TValue>> test)
        {
        }
    }

    public class TestClass
    {
        public string Label { get; set; }
    }
}

#else
#region New
using System;
using Bridge;
using ReactCore.Framework;
using Retyped;
using ScriptLoader;

namespace ReactDemo
{
    [FileName("EntryPoint.js")]
    public class EntryPoint
    {
        [Init(InitPosition.Top)]
        public static void InitTop()
        {
            Loader.PackageDefinitions.Add("react", "React");
            Loader.PackageDefinitions.Add("react-dom", "ReactDOM");
            Loader.LoadScripts(() => new Demo().Run(), false,
                //"js/bridge.min.js" ,
                "https://cdnjs.cloudflare.com/ajax/libs/Bridge.NET/16.5.0/bridge.console.min.js",
                "https://cdnjs.cloudflare.com/ajax/libs/react/15.3.1/react.min.js",
                "http://cdnjs.cloudflare.com/ajax/libs/react/15.3.1/react-dom.min.js",
                "js/ReactCore.js", "js/ReactCore.meta.js",
                "js/ReactDemo.js", "js/ReactDemo.meta.js");
        }
    }

    public class Demo
    {
        public void Run()
        {
            MessageEntryForm.Define()
                .With(x => x.Label, "Text:")
                .With(x => x.OnSave, value => System.Console.WriteLine($"Entered value: '{value}'."))
                .Render("root");
        }
    }

    public class MessageEntryForm : ReactComponent<MessageEntryForm, MessageEntryForm.Props, MessageEntryForm.State>
    {
        public MessageEntryForm(Props p)
            : base(p)
        {
        }

        protected override IDomNodeDescriptor DoRender()
        {
            var div = this.Define(x => x.div)
                .With(x => x.className, "wrapper");

            // Create label:
            div.Add(x => x.label)
                .WithInnerHtml(this.props.Label, true);

            // Create input:
            div.Add(x => x.input, "input1")
                .With(x => x.value, this.state.Value)
                .With(x => x.size, 50)
                .With(x => x.style, s => s.WithMargin(50))
                .WithOnChange(e => this.UpdateState(x=>x.Value,e.value));
 
            var button = div.Add(x => x.button, "button1")
                .With(x => x.style, v => v.WithSize(150, 28).WithMargin(20))
                .With(x => x.disabled, string.IsNullOrWhiteSpace(this.state.Value))
                .WithInnerHtml(this.state.Value.IsNullOrEmpty() ? "Enter Text..." : "Print to Console", true)
                .WithOnClick(e => this.props.OnSave(this.state.Value));

            return div;
        }

     
        public class State : BaseState
        {
            public string Value { get;  set; }

        }

        public class Props : BaseProps
        {
            public string Label { get; set; }
            public Action<string> OnSave { get; set; }
        }

    }
}
#endregion
#endif
