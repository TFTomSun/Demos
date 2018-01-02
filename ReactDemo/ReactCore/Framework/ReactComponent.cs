using System;
using Bridge;
using Retyped;

namespace ReactCore.Framework
{
    public abstract class ReactComponent<TSelf, TProperties, TState> : react.React.Component<TProperties, TState>
        where TState: ReactComponent<TSelf, TProperties, TState>.BaseState
        where TProperties : ReactComponent<TSelf, TProperties, TState>.BaseProps, new()
    {
        public static ClassDescriptor<TProperties> Define()
        {
            return new ClassDescriptor<TProperties>(Class);
        }

        protected ReactComponent(TProperties properties) : base(properties) { }
        public static react.React.ComponentClass<TProperties> Class => typeof(TSelf).As<react.React.ComponentClass<TProperties>>();

        public new TProperties props => base.props.As<TProperties>();

        public new TState state
        {
            get { return base.state.As<TState>(); }
            set { base.state = value.As<es5.Readonly<TState>>(); }
        }

        [Name("render")]
        public IObject Render()
        {
            return this.DoRender().CreateElement();
        }

        protected  DomNodeDescriptor<TChildNode, TChildProperties> Define<TChildNode,TChildProperties>(
            Func<react.React.ReactDOM, react.React.DOMFactory<TChildProperties, TChildNode>> expression, string key = null)
            where TChildNode : dom.HTMLElement
            where TChildProperties : react.React.DOMAttributes<TChildNode>, new()
        {
            return expression(react.React.DOM).Define(key);
        }

        protected abstract IDomNodeDescriptor DoRender();

        [ObjectLiteral]
        public abstract class BaseProps
        {
            
        }

        [ObjectLiteral]
        public abstract class BaseState : es5.Pick<TState, KeyOf<TState>>
        {

        }
    }
}