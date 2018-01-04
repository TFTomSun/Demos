using System.Collections.Generic;
using Retyped;

namespace ReactCore.Framework
{
    public interface IDomNodeDescriptor<out TProperties> : IDomNodeDescriptor
    {
        
    }
    public interface IDomNodeDescriptor
    {
        List<IDomNodeDescriptor> Children { get; }
        react.React.ReactNode CreateNode();
        IObject CreateElement();
    }
}