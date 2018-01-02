using Bridge;
using Retyped;


    [External]
    public static class ExternalExtensions
    {
        /// <summary>
        /// Converts DOMElement -> ReactNode.
        /// </summary>
        [Template("{0}")]
        public static extern react.React.ReactNode AsNode(this IObject el);
    }
