using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Puerts;
using Unity.PerformanceTesting;

namespace Tests
{
    public class SetJsCallReturn
    {
        private void Run(bool isReflection, string methodName, string validator)
        {
            string className = isReflection ? "TestClassReflection" : "TestClassStatic";
            JsEnv jsEnv = new JsEnv();
            jsEnv.Eval("global.CS = require('csharp'); global.PUERTS = require('puerts');");
            jsEnv.Eval(string.Format("for (let i = 0; i < {2}; i++) {{ CS.{0}.{1}() }}", className, methodName, PuertsPerformanceUtil.warmUpRepeatCount));
            Measure
                .Method(() =>
                {
                    jsEnv.Eval(string.Format("for (let i = 0; i < {2}; i++) {{ CS.{0}.{1}() }}", className, methodName, PuertsPerformanceUtil.repeatCount));
                })
                .WarmupCount(PuertsPerformanceUtil.warmUpCount)
                .MeasurementCount(PuertsPerformanceUtil.SampleCount)
                .Run();

            jsEnv.Eval(string.Format("function validate(value) {{ if (!({0})) throw new Error('validate failed') }}(CS.{1}.{2}())", validator, className, methodName));
        }

        [Test, Performance]
        public void IntStatic()
        {
            Run(false, "ReturnIntValue", "value === 1");
        }

        [Test, Performance]
        public void IntReflection()
        {
            Run(true, "ReturnIntValue", "value === 1");
        }

        [Test, Performance]
        public void BooleanStatic()
        {
            Run(false, "ReturnBooleanValue", "value === true");
        }

        [Test, Performance]
        public void BooleanReflection()
        {
            Run(true, "ReturnBooleanValue", "value === true");
        }

        [Test, Performance]
        public void DateStatic()
        {
            Run(false, "ReturnDateValue", "res instanceof Date");
        }

        [Test, Performance]
        public void DateReflection()
        {
            Run(true, "ReturnDateValue", "res instanceof Date");
        }

        [Test, Performance]
        public void BigIntStatic()
        {
            Run(false, "ReturnBigIntValue", "typeof res == 'bigint'");
        }

        [Test, Performance]
        public void BigIntReflection()
        {
            Run(true, "ReturnBigIntValue", "typeof res == 'bigint'");
        }

        [Test, Performance]
        public void StringStatic()
        {
            Run(false, "ReturnStringValue", "typeof res == 'string'");
        }

        [Test, Performance]
        public void StringReflection()
        {
            Run(true, "ReturnStringValue", "typeof res == 'string'");
        }

        [Test, Performance]
        public void ArrayBufferStatic()
        {
            Run(false, "ReturnArrayBufferValue", "res instanceof ArrayBuffer");
        }

        [Test, Performance]
        public void ArrayBufferReflection()
        {
            Run(true, "ReturnArrayBufferValue", "res instanceof ArrayBuffer");
        }

        [Test, Performance]
        public void NativeObjectStatic()
        {
            Run(false, "ReturnNativeObjectValue", "res.name == 'NativeObject'");
        }

        [Test, Performance]
        public void NativeObjectReflection()
        {
            Run(true, "ReturnNativeObjectValue", "res.name == 'NativeObject'");
        }
    }
}
