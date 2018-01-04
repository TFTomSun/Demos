using System;
using System.Linq.Expressions;
using System.Reflection;
using ReactCore.Framework;
using static Retyped.dom;
using static Retyped.react.React;
using static Retyped.react_dom;


    public static class Extensions
    {

        public static DomNodeDescriptor<TNode, TProperties> With<TNode, TProperties, TValue>(
            this DomNodeDescriptor<TNode, TProperties> descriptor,
            Expression<Func<TProperties, TValue>> expression, Func<TValue,TValue> modifyValue)
            where TNode : Element
            where TProperties : DOMAttributes<TNode>, new()
            where TValue: class, new()
        {
            var property = (PropertyInfo)expression.GetMemberInfo().Member;
            var existingValue = (TValue)property.GetValue(descriptor.Properties) ?? new TValue();
            property.SetValue(descriptor.Properties, modifyValue(existingValue));
            return descriptor;
        }
        public static ClassDescriptor<TProperties> With< TProperties, TValue>(
            this ClassDescriptor<TProperties> descriptor,
            Expression<Func<TProperties, TValue>> expression, TValue value)
            where TProperties : new()
        {
        var property = (PropertyInfo)expression.GetMemberInfo().Member;
        property.SetValue(descriptor.Properties, value);
        return descriptor;
        }
        public static DomNodeDescriptor<TNode, TProperties> With<TNode, TProperties, TValue>(
            this DomNodeDescriptor<TNode, TProperties> descriptor, 
            Expression<Func<TProperties, TValue>> expression, TValue value) 
            where TNode : Element 
            where TProperties : DOMAttributes<TNode>, new()
        {
            var property = (PropertyInfo) expression.GetMemberInfo().Member;
            property.SetValue(descriptor.Properties, value);
            return descriptor;
        }
        public static void Render<TProperties>(this ClassDescriptor<TProperties> classDescriptor, string targetId) where TProperties : new()
        {
            var instance = createElement(classDescriptor.Class, classDescriptor.Properties);
            render(instance, document.getElementById(targetId));
        }
        public static void Render<TProperties>(this ClassDescriptor<TProperties> classDescriptor, HTMLElement target) where TProperties : new()
        {
            var instance = createElement(classDescriptor.Class,classDescriptor.Properties);
            render(instance, target);
        }
     
        public static CSSProperties WithPosition(this CSSProperties properties, int? left = null, int? top = null)
        {
            if (left != null)
                properties.left = left.Value;
            if (top != null)
                properties.top = top.Value;

            return properties;
        }

        public static CSSProperties WithSize(this CSSProperties properties, int? width = null, int? height = null)
        {
       
            if (width != null)
                properties.width = width.Value;

            if (height != null)
                properties.height = height.Value;
            return properties;
        }

        public static CSSProperties WithMargin(this CSSProperties properties, int? left = null, int? top = null,
            int? right = null, int? bottom = null)
        {
            if (left != null)
                properties.marginLeft = left.Value;
            if (top != null)
                properties.marginTop = top.Value;

            if (right != null)
                properties.marginRight= right.Value;

            if (bottom != null)
                properties.marginBottom = bottom.Value;
            return properties;
        }

        public static DomNodeDescriptor<TChildNode, TChildProperties> Add<TChildNode,
            TChildProperties>(
            this IDomNodeDescriptor descriptor,
            Func<ReactDOM, DOMFactory<TChildProperties, TChildNode>> expression, string key = null)
            where TChildNode : HTMLElement
            where TChildProperties : DOMAttributes<TChildNode>, new()
        {
            var child = expression(DOM).Define(key);
            descriptor.Children.Add(child);
            return child;
        }

        public static DomNodeDescriptor<TNode, TProperties> WithInnerHtml<TNode, TProperties>(
            this DomNodeDescriptor<TNode, TProperties> descriptor,
            string html, bool iKnowWhatIDo)
            where TProperties : DOMAttributes<TNode>, new()
            where TNode : Element
        {
#pragma warning disable 618
            return descriptor.WithInnerHtml(html);
#pragma warning restore 618
           
        }
        [Obsolete("Warning: Using that method exposes security risks. See dangerouslySetInnerHTML section at https://reactjs.org/docs/dom-elements.html for more information.")]
        public static DomNodeDescriptor<TNode, TProperties> WithInnerHtml<TNode, TProperties>(
            this DomNodeDescriptor<TNode, TProperties> descriptor,
            string html)
            where TProperties : DOMAttributes<TNode>, new() 
            where TNode : Element
        {
            descriptor.Properties.dangerouslySetInnerHTML = new DOMAttributes<TNode>.dangerouslySetInnerHTMLConfig
            {
                __html =html,
            };
            return descriptor;
        }

        public static DomNodeDescriptor<TNode, TProperties> WithOnChange<TNode,TProperties>(this DomNodeDescriptor<TNode,TProperties> descriptor,
            Action<TNode> eventHandler)
            where TNode : HTMLElement
            where TProperties :ChangeTargetHTMLAttributes<TNode>, new()
        {
            descriptor.Properties.onChange = Handler.ChangeEvent(new Action<ChangeEvent<TNode>>(eh=>eventHandler(eh.currentTarget.Type2)));
            return descriptor;
        }
        public static DomNodeDescriptor<TNode, TProperties> WithOnClick<TNode, TProperties>(this DomNodeDescriptor<TNode, TProperties> descriptor,
            Action<MouseEvent<TNode>> clickHandler)
            where TNode : HTMLElement 
            where TProperties : DOMAttributes<TNode>, new()
        {

            descriptor.Properties.onClick = Handler.MouseEvent(clickHandler);
            return descriptor;
        }
      
       

        public static DomNodeDescriptor<TNode,P> Define<TNode, P>(this DOMFactory<P, TNode> factory, string key = null)
            where TNode : Element
            where P : DOMAttributes<TNode>, new()
        {
            var node = new DomNodeDescriptor<TNode, P>(factory);
            node.Key = key;
          
            return node;


        }
    }
