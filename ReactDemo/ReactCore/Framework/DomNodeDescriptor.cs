using System.Collections.Generic;
using System.Linq;
using Bridge;
using Retyped;

namespace ReactCore.Framework
{
    public class DomNodeDescriptor<TNode, TProperties>: IDomNodeDescriptor<TProperties>
        where TNode : dom.Element
        where TProperties : react.React.DOMAttributes<TNode>, new()
    {
        public DomNodeDescriptor(react.React.DOMFactory<TProperties, TNode> factory)
        {
            this.Factory = factory;
            var properties = new TProperties();
            var htmlProperties = properties as react.React.HTMLAttributes<TNode>;
            if(htmlProperties != null)
            {
                htmlProperties.style = new react.React.CSSProperties();
            }
            this.Properties = properties;
        }
        public TProperties Properties { get; } 

        public react.React.ClassAttributes<TNode> ClassAttributes { get; } = new react.React.ClassAttributes<TNode>();
        react.React.DOMFactory<TProperties,TNode> Factory { get; }

        public string Key { get; set; }
        public List<IDomNodeDescriptor> Children { get; } = new List<IDomNodeDescriptor>();


        //public static DomNodeDescriptor<TNode, TProperties> operator +(DomNodeDescriptor<TNode, TProperties> left, IDomNodeDescriptor right)
        //{
        //    left.Children.Add(right);
        //    return left;
        //}
        //public static DomNodeDescriptor<TNode, TProperties> operator ^(IDomNodeDescriptor left, DomNodeDescriptor<TNode, TProperties> right)
        //{
        //    left.Children.Add(right);
        //    return right;
        //}
        //public static DomNodeDescriptor<TNode, TProperties> operator <(IDomNodeDescriptor left, DomNodeDescriptor<TNode, TProperties> right)
        //{
        //    left.Children.Add(right);
        //    return right;
        //}
        //public static DomNodeDescriptor<TNode, TProperties> operator >(IDomNodeDescriptor left,DomNodeDescriptor<TNode, TProperties> right )
        //{
        //    left.Children.Add(right);
        //    return right;
        //}
        public react.React.ReactNode CreateNode()
        {
            return this.CreateElement().AsNode();
        }

        public react.React.DOMElement<TProperties, TNode> CreateElement()
        {

            Intersection<react.React.ClassAttributes<TNode>, TProperties> config  = this.Properties;
            config.Type1.key = this.Key;
            if (this.Children.Count == 0)
            {
                return this.Factory.Self(config);
            }

            return this.Factory.Self(config, this.Children.Select(c => c.CreateNode()).ToArray());
        }

        IObject IDomNodeDescriptor.CreateElement()
        {
            return this.CreateElement();
        }
    }
}