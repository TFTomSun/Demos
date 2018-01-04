using System;
using System.Collections.Generic;
using Bridge;
using Retyped;

namespace ScriptLoader
{
   
    public class Loader
    {
        [Init(InitPosition.Top)]
        public static void InitTop()
        {
            /*@
            var require = function(packageName)
            {
                return ScriptLoader.Loader.LoadPackage(packageName);
            }

            var scriptCache = [];
            var paths = [];
            function Import(path, isFullPath)
            {
                var index = 0;
                if((index = paths.indexOf(path)) != -1) //If we already imported this module
                {
                    return scriptCache [index];
                }

                var request, script, source;
                var fullPath;
                if(isFullPath)
                {
                fullPath = path;
                }
                else
                {
                fullPath = window.location.protocol + '//' + window.location.host + '/' + path;
                }
                request = new XMLHttpRequest();
                request.open('GET', fullPath, false);
                request.send();

                source = request.responseText;

                var module = (function concealedEval() {
                    eval(source);
                    //return exports;
                })();

                scriptCache.push(module);
                paths.push(path);

                return module;
            }

            Import('https://cdnjs.cloudflare.com/ajax/libs/Bridge.NET/16.5.0/bridge.min.js',true);
           */
        }

      

        public static Dictionary<string, string> PackageDefinitions { get; } = new Dictionary<string, string>();

        public static object LoadPackage(string packageName)
        {
            var variableName = PackageDefinitions[packageName];

            return Script.Eval<object>(variableName);


        }

        public static void LoadScripts(Action callback, bool inParallel, params string[] urls)
        {
            if (inParallel)
            {
                var counter = 0;
                foreach (var url in urls)
                {
                    AppendUrl(url, () =>
                    {
                        ++counter;
                        if (counter == urls.Length)
                            callback();
                    });
                }
            }
            else
            {
                var counter = 0;
                Action append = null;
                append = () =>
                {
                    if (counter == urls.Length)
                    {
                        callback();
                    }
                    else
                    {
                        AppendUrl(urls[counter], append);
                    }
                    ++counter;
                };
                append();
            }
        }

        public static void AppendUrl(string url, Action onLoad)
        {
            var doc = dom.document;
            var head = (dom.HTMLHeadElement) doc.getElementsByTagName("head")[0];
            var script = (dom.HTMLScriptElement) doc.createElement("script");
            script.type = "text/javascript";
            script.src = url;

            // Then bind the event to the callback function.
            // There are several events for cross browser compatibility.
            //script.on.oonreadystatechange = callback;
            script.onload = e =>
            {
                onLoad();
                return null;
            };
            head.appendChild(script);
        }
    }

    //[Namespace(null)]
    //[Name(null)]
    //public class ReactDummy
    //{
    //    public void Test()
    //    {

    //    }
    //}
}