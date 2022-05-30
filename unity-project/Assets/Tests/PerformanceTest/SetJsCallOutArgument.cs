using System;
using NUnit.Framework;
using Puerts;
using Unity.PerformanceTesting;

namespace Tests
{
    public class SetJsCallOutArgument
    {
        private ResultType Run<ResultType>(bool isReflection, string methodName)
        {
            string className = isReflection ? "TestClassReflection" : "TestClassStatic";
            JsEnv jsEnv = new JsEnv();
            jsEnv.Eval("global.CS = require('csharp'); global.PUERTS = require('puerts');");
            jsEnv.Eval(string.Format("for (let i = 0; i < {2}; i++) {{ const ref = PUERTS.$ref(0); CS.{0}.{1}(ref); PUERTS.$unref(ref); }}", className, methodName, PuertsPerformanceUtil.warmUpRepeatCount));
            Measure
                .Method(() =>
                {
                    jsEnv.Eval(string.Format("for (let i = 0; i < {2}; i++) {{ const ref = PUERTS.$ref(0); CS.{0}.{1}(ref); PUERTS.$unref(ref); }}", className, methodName, PuertsPerformanceUtil.repeatCount));
                })
                .WarmupCount(PuertsPerformanceUtil.warmUpCount)
                .MeasurementCount(PuertsPerformanceUtil.SampleCount)
                .Run();

            return jsEnv.Eval<ResultType>(string.Format("var ref = PUERTS.$ref(0); CS.{0}.{1}(ref); PUERTS.$unref(ref);", className, methodName));
        }

        [Test, Performance]
        public void IntStatic()
        {
            var result = Run<int>(false, "IntOut");

            Assert.IsTrue(result == 3);
        }

        [Test, Performance]
        public void IntReflection()
        {
            var result = Run<int>(true, "IntOut");

            Assert.IsTrue(result == 3);
        }

        [Test, Performance]
        public void BooleanStatic()
        {
            var result = Run<bool>(false, "BooleanOut");

            Assert.IsTrue(result);
        }

        [Test, Performance]
        public void BooleanReflection()
        {
            var result = Run<bool>(true, "BooleanOut");

            Assert.IsTrue(result);
        }

        [Test, Performance]
        public void DateStatic()
        {
            var result = Run<DateTime>(false, "DateOut");

            Assert.IsTrue(result.Year > 2000);
        }

        [Test, Performance]
        public void DateReflection()
        {
            var result = Run<DateTime>(true, "DateOut");

            Assert.IsTrue(result.Year > 2000);
        }

        [Test, Performance]
        public void BigIntStatic()
        {
            var result = Run<long>(false, "BigIntOut");

            Assert.IsTrue(result > 922337203685477);
        }

        [Test, Performance]
        public void BigIntReflection()
        {
            var result = Run<long>(true, "BigIntOut");

            Assert.IsTrue(result > 922337203685477);
        }

        [Test, Performance]
        public void StringStatic()
        {
            var result = Run<string>(false, "StringOut");

            Assert.IsTrue(result.Length > 0);
        }

        [Test, Performance]
        public void StringReflection()
        {
            var result = Run<string>(true, "StringOut");

            Assert.IsTrue(result.Length > 0);
        }

        [Test, Performance]
        public void ArrayBufferStatic()
        {
            var result = Run<Puerts.ArrayBuffer>(false, "ArrayBufferOut");

            Assert.IsTrue(result.Bytes.Length > 0);
        }

        [Test, Performance]
        public void ArrayBufferReflection()
        {
            var result = Run<Puerts.ArrayBuffer>(true, "ArrayBufferOut");

            Assert.IsTrue(result.Bytes.Length > 0);
        }

        [Test, Performance]
        public void NativeObjectStatic()
        {
            var result = Run<NativeObjectClass>(false, "NativeObjectOut");

            Assert.IsTrue(result.name == "NativeObject");
        }

        [Test, Performance]
        public void NativeObjectReflection()
        {
            var result = Run<NativeObjectClass>(true, "NativeObjectOut");

            Assert.IsTrue(result.name == "NativeObject");
        }
    }
}
