using Bridge;

namespace ReactDemo.Framework
{
    [Priority(int.MaxValue)]
    public class ReactLoader
    {
        [Init(InitPosition.Top)]
        public static void InitTop()
        {
            //@ requirejs.config({
            //@     baseUrl: "",
            //@     paths:
            //@     {
            //@         "react": "https://cdnjs.cloudflare.com/ajax/libs/react/15.3.1/react.min",
            //@         "react-dom": "http://cdnjs.cloudflare.com/ajax/libs/react/15.3.1/react-dom.min",
            //@     }
            //@ });
            // Load 'react' module at the very beginning of the generated script
            //@ require(["react", "react-dom"], function (react, reactDom) {
            //requirejs.require.Self(new string[] ("react", "react-dom"), es5.Function.Self(). new es5.Function().)
        }

        [Init(InitPosition.After)]
        public static void InitBefore()
        {
            //@ React = react;
            //@ ReactDOM = reactDom;
        }

        [Init(InitPosition.Bottom)]
        public static void InitBottom()
        {
            //@});
        }
    }
}


