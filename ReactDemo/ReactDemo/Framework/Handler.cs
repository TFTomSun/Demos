using System;
using Bridge;
using Retyped;

namespace ReactDemo.Framework
{
    [External]
    public static class Handler
    {
        [Template("{0}")]
        public static extern react.React.ChangeEventHandler<TElement> ChangeEvent<TElement>(Action<react.React.ChangeEvent<TElement>> action);

        [Template("{0}")]
        public static extern react.React.MouseEventHandler<TElement> MouseEvent<TElement>(Action<react.React.MouseEvent<TElement>> action);
    }
}