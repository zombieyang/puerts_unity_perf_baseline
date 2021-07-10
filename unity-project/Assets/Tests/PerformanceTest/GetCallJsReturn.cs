using NUnit.Framework;
using Unity.PerformanceTesting;
using System;
using Puerts;

namespace Tests
{
    class GetCallJsReturn
    {

        private ResultType Run<ResultType>(string code)
        {
            JsEnv jsEnv = new JsEnv();
            jsEnv.UsingFunc<ResultType>();
            jsEnv.Eval("global.CS = require('csharp'); global.PUERTS = require('puerts');");

            Func<ResultType> func = jsEnv.Eval<Func<ResultType>>(
                string.Format("global.ret = {0}; function runner() {{ return global.ret; }}; runner;", code)
            );
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

            return func.Invoke();
        }

        [Test, Performance]
        public void Int()
        {
            var result = Run<int>("3");

            Assert.True(result == 3);
        }

        [Test, Performance]
        public void Boolean()
        {
            var result = Run<bool>("true");

            Assert.True(result);
        }

        [Test, Performance]
        public void Date()
        {
            var result = Run<DateTime>("new Date");

            Assert.True(result.GetType() == typeof(DateTime));
        }

        [Test, Performance]
        public void BigInt()
        {
            var result = Run<long>("9223372036854775807n");

            Assert.True(result.GetType() == typeof(long));
        }

        [Test, Performance]
        public void String()
        {
            var result = Run<string>("'hello'");

            Assert.True(result.GetType() == typeof(string));
        }

        [Test, Performance]
        public void ArrayBuffer()
        {
            var result = Run<Puerts.ArrayBuffer>("new ArrayBuffer");

            Assert.True(result.GetType() == typeof(Puerts.ArrayBuffer));
        }

        [Test, Performance]
        public void NativeObject()
        {
            var result = Run<NativeObjectClass>("new CS.NativeObjectClass()");

            Assert.True(result.GetType() == typeof(NativeObjectClass));
        }
    }
}
