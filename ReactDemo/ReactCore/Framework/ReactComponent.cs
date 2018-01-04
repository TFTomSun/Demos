using System;
using System.Linq.Expressions;
using System.Reflection;
using Bridge;
using Retyped;

namespace ReactCore.Framework
{
    public abstract class ReactComponent<TSelf, TProperties, TState> : react.React.Component<TProperties, TState>
        where TState: ReactComponent<TSelf, TProperties, TState>.BaseState, new()
        where TProperties : ReactComponent<TSelf, TProperties, TState>.BaseProps, new()
        where TSelf: ReactComponent<TSelf, TProperties, TState>
    {
        public static ClassDescriptor<TProperties> Define()
        {
            return new ClassDescriptor<TProperties>(Class);
        }

        protected ReactComponent(TProperties properties) : base(properties)
        {
            var state = new TState();
            base.state = state.As<es5.Readonly<TState>>();
        }
        public static react.React.ComponentClass<TProperties> Class => typeof(TSelf).As<react.React.ComponentClass<TProperties>>();

        public new TProperties props => base.props.As<TProperties>();

        public new TState state
        {
            get { return base.state.As<TState>(); }
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

        //private Dictionary<string, object> Fields { get; } = new Dictionary<string, object>();

        //private TValue GetStateValue<TValue>(Func<TValue> getDefault,  string propertyName)
        //{
        //    object value;
        //    if (!this.Fields.TryGetValue(propertyName, out value))
        //    {
        //        value = getDefault();
        //        this.Fields.Add(propertyName, value);
        //        this.setState(this.state);
        //    }
        //    return (TValue)value;
        //}
        protected void UpdateState<TValue>(Expression<Func<TState, TValue>> propertyExpression, TValue value)
        {
            var propertyInfo = (PropertyInfo)propertyExpression.GetMemberInfo().Member;
            propertyInfo.SetValue(this.state, value);
            this.setState(this.state);//UpdateState();
        }

        [ObjectLiteral]
        public abstract class BaseState : es5.Pick<TState, KeyOf<TState>>
        { 
        }
    }
}