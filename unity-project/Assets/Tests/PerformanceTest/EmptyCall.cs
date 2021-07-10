using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Puerts;
using Unity.PerformanceTesting;
using System;

namespace Tests
{
    public class EmptyCall
    {
        // A Test behaves as an ordinary method
        [Test, Performance]
        public void JSCallCSReflection()
        {
            JsEnv jsEnv = new JsEnv();
            jsEnv.Eval("global.CS = require('csharp'); global.PUERTS = require('puerts');");
            jsEnv.Eval(string.Format("for (let i = 0; i < {0}; i++) CS.TestClassReflection.EmptyFunction()", PuertsPerformanceUtil.warmUpRepeatCount));

            Measure
                .Method(() =>
                {
                    jsEnv.Eval(string.Format("for (let i = 0; i < {0}; i++) {{ CS.TestClassReflection.EmptyFunction() }}", PuertsPerformanceUtil.repeatCount));
                })
                .WarmupCount(PuertsPerformanceUtil.warmUpCount)
                .MeasurementCount(PuertsPerformanceUtil.SampleCount)
                .Run();
        }

        // A Test behaves as an ordinary method
        [Test, Performance]
        public void JSCallCSStatic()
        {
            JsEnv jsEnv = new JsEnv();
            jsEnv.Eval("global.CS = require('csharp'); global.PUERTS = require('puerts');");
            jsEnv.Eval(string.Format("for (let i = 0; i < {0}; i++) CS.TestClassStatic.EmptyFunction()", PuertsPerformanceUtil.warmUpRepeatCount));

            Measure
                .Method(() =>
                {
                    jsEnv.Eval(string.Format("for (let i = 0; i < {0}; i++) {{ CS.TestClassStatic.EmptyFunction() }}", PuertsPerformanceUtil.repeatCount));
                })
                .WarmupCount(PuertsPerformanceUtil.warmUpCount)
                .MeasurementCount(PuertsPerformanceUtil.SampleCount)
                .Run();
        }

        delegate object JSFunc();
        [Test, Performance]
        public void CSCallJS()
        {
            JsEnv jsEnv = new JsEnv();
            Action func = jsEnv.Eval<Action>("function func () { }; func;");
            for (var i = 0; i < PuertsPerformanceUtil.warmUpRepeatCount; i++)
                func.Invoke();
            Measure
                .Method(() =>
                {
                    for (var i = 0; i < PuertsPerformanceUtil.repeatCount; i++)
                        func.Invoke();
                })
                .WarmupCount(PuertsPerformanceUtil.warmUpCount)
                .MeasurementCount(PuertsPerformanceUtil.SampleCount)
                .Run();
        }
    }
}
