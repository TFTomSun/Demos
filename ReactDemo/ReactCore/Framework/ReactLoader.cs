using Bridge;

namespace ReactDemo
{
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
            //@ require(["react"], function (React) {
        }

        [Init(InitPosition.Bottom)]
        public static void InitBottom()
        {
            //@ Bridge.init();
            //@ });
        }
    }

}
