requirejs.config({
    baseUrl: "",
    paths:
    {
        "react": "https://cdnjs.cloudflare.com/ajax/libs/react/15.3.1/react.min",
        "react-dom": "http://cdnjs.cloudflare.com/ajax/libs/react/15.3.1/react-dom.min",
    }
});
// Load 'react' module at the very beginning of the generated script
require(["react", "react-dom"], function (react, reactDom) {
//requirejs.require.Self(new string[] ("react", "react-dom"), es5.Function.Self(). new es5.Function().)

/**
 * @version 1.0.0.0
 * @copyright Copyright ©  2017
 * @compiler Bridge.NET 16.6.0
 */
Bridge.assembly("ReactDemo", function ($asm, globals) {
    "use strict";

    var React,
        ReactDOM;

    Bridge.define("ReactDemo.Framework.ReactLoader", {
        statics: {
            methods: {
                InitBefore: function () {
                    React = react;
                    ReactDOM = reactDom;
                }
            }
        }
    });

    Bridge.init(function () { ReactDemo.Framework.ReactLoader.InitBefore(); });

    Bridge.define("CommonExtensions", {
        statics: {
            methods: {
                IsNullOrEmpty: function (value) {
                    return System.String.isNullOrEmpty(value);
                },
                GetMemberInfo: function (lambda) {
                    var $t;
                    if (lambda == null) {
                        throw new System.ArgumentNullException("method");
                    }

                    var memberExpr = null;

                    if (lambda.body.ntype === 10) {
                        memberExpr = ($t = ($t = lambda.body, Bridge.cast($t, Bridge.hasValue($t) && ([4,10,11,28,29,30,34,40,44,49,54,60,62,77,78,79,80,82,83,84].indexOf($t.ntype) >= 0))).operand, Bridge.as($t, Bridge.hasValue($t) && ($t.ntype === 23)));
                    } else if (lambda.body.ntype === 23) {
                        memberExpr = ($t = lambda.body, Bridge.as($t, Bridge.hasValue($t) && ($t.ntype === 23)));
                    }

                    if (memberExpr == null) {
                        throw new System.ArgumentException("method");
                    }

                    return memberExpr;
                }
            }
        }
    });

    Bridge.define("Extensions", {
        statics: {
            methods: {
                With$2: function (TNode, TProperties, TValue, descriptor, expression, modifyValue) {
                    var property = Bridge.cast(CommonExtensions.GetMemberInfo(expression).member, System.Reflection.PropertyInfo);
                    var existingValue = Bridge.cast(Bridge.Reflection.midel(property.g, descriptor.Properties)(), TValue) || Bridge.createInstance(TValue);
                    Bridge.Reflection.midel(property.s, descriptor.Properties)(modifyValue(existingValue));
                    return descriptor;
                },
                With: function (TProperties, TValue, descriptor, expression, value) {
                    var property = Bridge.cast(CommonExtensions.GetMemberInfo(expression).member, System.Reflection.PropertyInfo);
                    Bridge.Reflection.midel(property.s, descriptor.Properties)(value);
                    return descriptor;
                },
                With$1: function (TNode, TProperties, TValue, descriptor, expression, value) {
                    var property = Bridge.cast(CommonExtensions.GetMemberInfo(expression).member, System.Reflection.PropertyInfo);
                    Bridge.Reflection.midel(property.s, descriptor.Properties)(value);
                    return descriptor;
                },
                Render$1: function (TProperties, classDescriptor, targetId) {
                    var instance = React.createElement(classDescriptor.Class, classDescriptor.Properties);
                    ReactDOM.render(instance, document.getElementById(targetId));
                },
                Render: function (TProperties, classDescriptor, target) {
                    var instance = React.createElement(classDescriptor.Class, classDescriptor.Properties);
                    ReactDOM.render(instance, target);
                },
                WithPosition: function (properties, left, top) {
                    if (left === void 0) { left = null; }
                    if (top === void 0) { top = null; }
                    if (left != null) {
                        properties.left = System.Nullable.getValue(left);
                    }
                    if (top != null) {
                        properties.top = System.Nullable.getValue(top);
                    }

                    return properties;
                },
                WithSize: function (properties, width, height) {
                    if (width === void 0) { width = null; }
                    if (height === void 0) { height = null; }

                    if (width != null) {
                        properties.width = System.Nullable.getValue(width);
                    }

                    if (height != null) {
                        properties.height = System.Nullable.getValue(height);
                    }
                    return properties;
                },
                WithMargin: function (properties, left, top, right, bottom) {
                    if (left === void 0) { left = null; }
                    if (top === void 0) { top = null; }
                    if (right === void 0) { right = null; }
                    if (bottom === void 0) { bottom = null; }
                    if (left != null) {
                        properties.marginLeft = System.Nullable.getValue(left);
                    }
                    if (top != null) {
                        properties.marginTop = System.Nullable.getValue(top);
                    }

                    if (right != null) {
                        properties.marginRight = System.Nullable.getValue(right);
                    }

                    if (bottom != null) {
                        properties.marginBottom = System.Nullable.getValue(bottom);
                    }
                    return properties;
                },
                Add: function (TChildNode, TChildProperties, descriptor, expression, key) {
                    if (key === void 0) { key = null; }
                    var child = Extensions.Define(TChildNode, TChildProperties, expression(React.DOM), key);
                    descriptor.ReactDemo$Framework$IDomNodeDescriptor$Children.add(child);
                    return child;
                },
                WithInnerHtml$1: function (TNode, TProperties, descriptor, html, iKnowWhatIDo) {
                    return Extensions.WithInnerHtml(TNode, TProperties, descriptor, html);

                },
                WithInnerHtml: function (TNode, TProperties, descriptor, html) {
                    descriptor.Properties.dangerouslySetInnerHTML = { __html: html };
                    return descriptor;
                },
                WithOnChange: function (TNode, TProperties, descriptor, eventHandler) {
                    descriptor.Properties.onChange = function (eh) {
                            eventHandler(eh.currentTarget);
                        };
                    return descriptor;
                },
                WithOnClick: function (TNode, TProperties, descriptor, clickHandler) {

                    descriptor.Properties.onClick = clickHandler;
                    return descriptor;
                },
                Define: function (TNode, P, factory, key) {
                    if (key === void 0) { key = null; }
                    var node = new (ReactDemo.Framework.DomNodeDescriptor$2(TNode,P))(factory);
                    node.Key = key;

                    return node;


                }
            }
        }
    });

    Bridge.define("ReactDemo.Demo", {
        main: function Main () {
            function loadScript(url, callback)
            {
                // Adding the script tag to the head as suggested before
                var head = document.getElementsByTagName('head')[0];
                var script = document.createElement('script');
                script.type = 'text/javascript';
                script.src = url;

                // Then bind the event to the callback function.
                // There are several events for cross browser compatibility.
                script.onreadystatechange = callback;
                script.onload = callback;

                // Fire the loading
                head.appendChild(script);
            }
            loadScript("js/ReactDemo.meta.js", function(){new ReactDemo.Demo().Run();});

            //new Demo().Run();
        },
        methods: {
            Run: function () {
                var $t, $t1, $t2, $t3, $t4, $t5;
                Extensions.Render$1(Bridge.global.ReactDemo.MessageEntryForm.Props, Extensions.With(Bridge.global.ReactDemo.MessageEntryForm.Props, Bridge.global.Function, Extensions.With(Bridge.global.ReactDemo.MessageEntryForm.Props, System.String, ReactDemo.Framework.ReactComponent$3(ReactDemo.MessageEntryForm,ReactDemo.MessageEntryForm.Props,ReactDemo.MessageEntryForm.State).Define(), ($t = { ntype: 38, t: ReactDemo.MessageEntryForm.Props, n: "x" }, ($t2 = ($t1 = Bridge.getMetadata(ReactDemo.MessageEntryForm.Props).m[1], { ntype: 23, t: $t1.rt, expression: $t, member: $t1 }), { ntype: 18, t: Function, rt: $t2.t, body: $t2, p: Bridge.toList([$t]) })), "Text:"), ($t3 = { ntype: 38, t: ReactDemo.MessageEntryForm.Props, n: "x" }, ($t5 = ($t4 = Bridge.getMetadata(ReactDemo.MessageEntryForm.Props).m[2], { ntype: 23, t: $t4.rt, expression: $t3, member: $t4 }), { ntype: 18, t: Function, rt: $t5.t, body: $t5, p: Bridge.toList([$t3]) })), function (value) {
                    System.Console.WriteLine(System.String.format("Entered value: '{0}'.", [value]));
                }), "root");
            }
        }
    });

    Bridge.define("ReactDemo.Framework.ClassDescriptor$1", function (TProperties) { return {
        fields: {
            Properties: Bridge.getDefaultValue(TProperties),
            Class: null
        },
        ctors: {
            ctor: function ($class) {
                this.$initialize();
                this.Class = $class;
                this.Properties = Bridge.createInstance(TProperties);
            }
        }
    }; });

    Bridge.define("ReactDemo.Framework.IDomNodeDescriptor", {
        $kind: "interface"
    });

    Bridge.definei("ReactDemo.Framework.IDomNodeDescriptor$1", function (TProperties) { return {
        inherits: [ReactDemo.Framework.IDomNodeDescriptor],
        $kind: "interface",
        $variance: [1]
    }; });

    Bridge.define("ReactDemo.Framework.DomNodeDescriptor$2", function (TNode, TProperties) { return {
        inherits: [ReactDemo.Framework.IDomNodeDescriptor$1(TProperties)],
        fields: {
            Properties: Bridge.getDefaultValue(TProperties),
            ClassAttributes: null,
            Factory: null,
            Key: null,
            Children: null
        },
        alias: [
            "Children", "ReactDemo$Framework$IDomNodeDescriptor$Children",
            "CreateNode", "ReactDemo$Framework$IDomNodeDescriptor$CreateNode"
        ],
        ctors: {
            init: function () {
                this.ClassAttributes = { };
                this.Children = new (System.Collections.Generic.List$1(ReactDemo.Framework.IDomNodeDescriptor)).ctor();
            },
            ctor: function (factory) {
                this.$initialize();
                this.Factory = factory;
                var properties = Bridge.createInstance(TProperties);
                var htmlProperties = properties;
                if (htmlProperties != null) {
                    htmlProperties.style = new (Bridge.virtualc("React.CSSProperties"))();
                }
                this.Properties = properties;
            }
        },
        methods: {
            CreateNode: function () {
                return this.CreateElement();
            },
            CreateElement: function () {

                var config = this.Properties;
                config.key = this.Key;
                if (this.Children.Count === 0) {
                    return this.Factory(config, null);
                }

                return this.Factory(config, System.Linq.Enumerable.from(this.Children).select(function (c) {
                            return c.ReactDemo$Framework$IDomNodeDescriptor$CreateNode();
                        }).toArray(Bridge.virtualc("React.ReactNode")));
            },
            ReactDemo$Framework$IDomNodeDescriptor$CreateElement: function () {
                return this.CreateElement();
            }
        }
    }; });

    Bridge.define("ReactDemo.Framework.ReactComponent$3", function (TSelf, TProperties, TState) { return {
        inherits: [React.Component],
        statics: {
            props: {
                Class: {
                    get: function () {
                        return TSelf;
                    }
                }
            },
            methods: {
                Define: function () {
                    return new (ReactDemo.Framework.ClassDescriptor$1(TProperties))(ReactDemo.Framework.ReactComponent$3(TSelf,TProperties,TState).Class);
                }
            }
        },
        props: {
            props$1: {
                get: function () {
                    return this.props;
                }
            },
            state$1: {
                get: function () {
                    return this.state;
                }
            }
        },
        ctors: {
            ctor: function (properties) {
                this.$initialize();
                React.Component.call(this, properties);
                var state = Bridge.createInstance(TState);
                this.state = state;
            }
        },
        methods: {
            render: function () {
                return this.DoRender().ReactDemo$Framework$IDomNodeDescriptor$CreateElement();
            },
            Define: function (TChildNode, TChildProperties, expression, key) {
                if (key === void 0) { key = null; }
                return Extensions.Define(TChildNode, TChildProperties, expression(React.DOM), key);
            },
            UpdateState: function (TValue, propertyExpression, value) {
                var propertyInfo = Bridge.cast(CommonExtensions.GetMemberInfo(propertyExpression).member, System.Reflection.PropertyInfo);
                Bridge.Reflection.midel(propertyInfo.s, this.state$1)(value);
                this.setState(this.state$1); //UpdateState();
            }
        }
    }; });

    Bridge.define("ReactDemo.MessageEntryForm.State", {
        fields: {
            Value: null
        }
    });

    Bridge.define("ReactDemo.MessageEntryForm.Props", {
        fields: {
            Label: null,
            OnSave: null
        }
    });

    Bridge.define("ReactDemo.MessageEntryForm", {
        inherits: function () { return [ReactDemo.Framework.ReactComponent$3(ReactDemo.MessageEntryForm,ReactDemo.MessageEntryForm.Props,ReactDemo.MessageEntryForm.State)]; },
        ctors: {
            ctor: function (p) {
                this.$initialize();
                ReactDemo.Framework.ReactComponent$3(ReactDemo.MessageEntryForm,ReactDemo.MessageEntryForm.Props,ReactDemo.MessageEntryForm.State).ctor.call(this, p);
            }
        },
        methods: {
            DoRender: function () {
                var $t, $t1, $t2, $t3, $t4, $t5, $t6, $t7, $t8, $t9, $t10, $t11, $t12, $t13, $t14, $t15, $t16, $t17;
                var div = Extensions.With$1(Bridge.global.HTMLDivElement, Bridge.global.System.Object, System.String, this.Define(Bridge.global.HTMLDivElement, Bridge.global.System.Object, function (x) {
                    return x.div;
                }), ($t = { ntype: 38, t: System.Object, n: "x" }, ($t2 = ($t1 = {"td":System.Object,"a":2,"n":"className","t":16,"rt":System.String,"g":{"td":System.Object,"a":2,"n":"get_className","t":8,"rt":System.String,"fg":"className"},"s":{"td":System.Object,"a":2,"n":"set_className","t":8,"p":[System.String],"rt":System.Void,"fs":"className"},"fn":"className"}, { ntype: 23, t: $t1.rt, expression: $t, member: $t1 }), { ntype: 18, t: Function, rt: $t2.t, body: $t2, p: Bridge.toList([$t]) })), "wrapper");
                Extensions.WithInnerHtml$1(Bridge.global.HTMLLabelElement, Bridge.global.System.Object, Extensions.Add(Bridge.global.HTMLLabelElement, Bridge.global.System.Object, div, function (x) {
                    return x.label;
                }), this.props$1.Label, true);
                Extensions.WithOnChange(Bridge.global.HTMLInputElement, Bridge.global.System.Object, Extensions.With$2(Bridge.global.HTMLInputElement, Bridge.global.System.Object, Bridge.virtualc("React.CSSProperties"), Extensions.With$1(Bridge.global.HTMLInputElement, Bridge.global.System.Object, System.Nullable$1(System.Double), Extensions.With$1(Bridge.global.HTMLInputElement, Bridge.global.System.Object, Bridge.global.System.Object, Extensions.Add(Bridge.global.HTMLInputElement, Bridge.global.System.Object, div, function (x) {
                    return x.input;
                }, "input1"), ($t3 = { ntype: 38, t: System.Object, n: "x" }, ($t5 = ($t4 = {"td":System.Object,"a":2,"n":"value","t":16,"rt":System.Object,"g":{"td":System.Object,"a":2,"n":"get_value","t":8,"rt":System.Object,"fg":"value"},"s":{"td":System.Object,"a":2,"n":"set_value","t":8,"p":[System.Object],"rt":System.Void,"fs":"value"},"fn":"value"}, { ntype: 23, t: $t4.rt, expression: $t3, member: $t4 }), { ntype: 18, t: Function, rt: $t5.t, body: $t5, p: Bridge.toList([$t3]) })), this.state$1.Value), ($t6 = { ntype: 38, t: System.Object, n: "x" }, ($t8 = ($t7 = {"td":System.Object,"a":2,"n":"size","t":16,"rt":System.Nullable$1(System.Double),"g":{"td":System.Object,"a":2,"n":"get_size","t":8,"rt":System.Nullable$1(System.Double),"fg":"size","box":function ($v) { return Bridge.box($v, System.Double, System.Nullable.toStringFn(System.Double.format), System.Nullable.getHashCodeFn(System.Double.getHashCode));}},"s":{"td":System.Object,"a":2,"n":"set_size","t":8,"p":[System.Nullable$1(System.Double)],"rt":System.Void,"fs":"size"},"fn":"size"}, { ntype: 23, t: $t7.rt, expression: $t6, member: $t7 }), { ntype: 18, t: Function, rt: $t8.t, body: $t8, p: Bridge.toList([$t6]) })), 50), ($t9 = { ntype: 38, t: System.Object, n: "x" }, ($t11 = ($t10 = {"td":System.Object,"a":2,"n":"style","t":16,"rt":Bridge.virtualc("React.CSSProperties"),"g":{"td":System.Object,"a":2,"n":"get_style","t":8,"rt":Bridge.virtualc("React.CSSProperties"),"fg":"style"},"s":{"td":System.Object,"a":2,"n":"set_style","t":8,"p":[Bridge.virtualc("React.CSSProperties")],"rt":System.Void,"fs":"style"},"fn":"style"}, { ntype: 23, t: $t10.rt, expression: $t9, member: $t10 }), { ntype: 18, t: Function, rt: $t11.t, body: $t11, p: Bridge.toList([$t9]) })), function (s) {
                    return Extensions.WithMargin(s, 50);
                }), Bridge.fn.bind(this, function (e) {
                    var $t12, $t13, $t14;
                    this.UpdateState(System.String, ($t12 = { ntype: 38, t: ReactDemo.MessageEntryForm.State, n: "x" }, ($t14 = ($t13 = Bridge.getMetadata(ReactDemo.MessageEntryForm.State).m[1], { ntype: 23, t: $t13.rt, expression: $t12, member: $t13 }), { ntype: 18, t: Function, rt: $t14.t, body: $t14, p: Bridge.toList([$t12]) })), e.value);
                }));

                var button = Extensions.WithOnClick(Bridge.global.HTMLButtonElement, Bridge.global.System.Object, Extensions.WithInnerHtml$1(Bridge.global.HTMLButtonElement, Bridge.global.System.Object, Extensions.With$1(Bridge.global.HTMLButtonElement, Bridge.global.System.Object, System.Nullable$1(System.Boolean), Extensions.With$2(Bridge.global.HTMLButtonElement, Bridge.global.System.Object, Bridge.virtualc("React.CSSProperties"), Extensions.Add(Bridge.global.HTMLButtonElement, Bridge.global.System.Object, div, function (x) {
                    return x.button;
                }, "button1"), ($t12 = { ntype: 38, t: System.Object, n: "x" }, ($t14 = ($t13 = {"td":System.Object,"a":2,"n":"style","t":16,"rt":Bridge.virtualc("React.CSSProperties"),"g":{"td":System.Object,"a":2,"n":"get_style","t":8,"rt":Bridge.virtualc("React.CSSProperties"),"fg":"style"},"s":{"td":System.Object,"a":2,"n":"set_style","t":8,"p":[Bridge.virtualc("React.CSSProperties")],"rt":System.Void,"fs":"style"},"fn":"style"}, { ntype: 23, t: $t13.rt, expression: $t12, member: $t13 }), { ntype: 18, t: Function, rt: $t14.t, body: $t14, p: Bridge.toList([$t12]) })), function (v) {
                    return Extensions.WithMargin(Extensions.WithSize(v, 150, 28), 20);
                }), ($t15 = { ntype: 38, t: System.Object, n: "x" }, ($t17 = ($t16 = {"td":System.Object,"a":2,"n":"disabled","t":16,"rt":System.Nullable$1(System.Boolean),"g":{"td":System.Object,"a":2,"n":"get_disabled","t":8,"rt":System.Nullable$1(System.Boolean),"fg":"disabled","box":function ($v) { return Bridge.box($v, System.Boolean, System.Nullable.toStringFn(System.Boolean.toString), System.Nullable.getHashCode);}},"s":{"td":System.Object,"a":2,"n":"set_disabled","t":8,"p":[System.Nullable$1(System.Boolean)],"rt":System.Void,"fs":"disabled"},"fn":"disabled"}, { ntype: 23, t: $t16.rt, expression: $t15, member: $t16 }), { ntype: 18, t: Function, rt: $t17.t, body: $t17, p: Bridge.toList([$t15]) })), System.String.isNullOrWhiteSpace(this.state$1.Value)), CommonExtensions.IsNullOrEmpty(this.state$1.Value) ? "Enter Text..." : "Print to Console", true), Bridge.fn.bind(this, function (e) {
                    this.props$1.OnSave(this.state$1.Value);
                }));

                return div;
            }
        }
    });
});

});
