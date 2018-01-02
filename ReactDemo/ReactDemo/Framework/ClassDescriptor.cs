using Retyped;

namespace ReactDemo.Framework
{
    public class ClassDescriptor<TProperties> 
        where TProperties : new()
    {
        public TProperties Properties { get; }
        public ClassDescriptor(react.React.ComponentClass<TProperties> @class)
        {
            this.Class = @class;
            this.Properties = new TProperties();
        }

        public react.React.ComponentClass<TProperties> Class { get; }


    }
}