using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Puerts;
using Unity.PerformanceTesting;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GetJsCallArgument
    {
        private void RunJSCallCS(bool isReflection, string methodName, string jsValue)
        {
            string className = isReflection ? "TestClassReflection" : "TestClassStatic";
            JsEnv jsEnv = new JsEnv();
            jsEnv.Eval("global.CS = require('csharp'); global.PUERTS = require('puerts');");
            jsEnv.Eval(string.Format("for (let i = 0; i < {3}; i++) CS.{0}.{1}({2})", className, methodName, jsValue, PuertsPerformanceUtil.warmUpRepeatCount));
            Measure
                .Method(() =>
                {
                    jsEnv.Eval(string.Format("for (let i = 0; i < {3}; i++) CS.{0}.{1}({2})", className, methodName, jsValue, PuertsPerformanceUtil.repeatCount));
                })
                .WarmupCount(PuertsPerformanceUtil.warmUpCount)
                .MeasurementCount(PuertsPerformanceUtil.SampleCount)
                .Run();

            jsEnv.Eval(string.Format("CS.{0}.{1}Checked({2})", className, methodName, jsValue));
        }

        private void RunJSCallCSStatic(string methodName, string jsValue)
        {
            RunJSCallCS(false, methodName, jsValue);
        }

        private void RunJSCallCSReflection(string methodName, string jsValue)
        {
            RunJSCallCS(true, methodName, jsValue);
        }

        [Test, Performance]
        public void IntStatic()
        {
            RunJSCallCSStatic("IntArg", "1");
        }

        [Test, Performance]
        public void IntReflection()
        {
            RunJSCallCSReflection("IntArg", "1");
        }

        [Test, Performance]
        public void BooleanStatic()
        {
            RunJSCallCSStatic("BooleanArg", "true");
        }

        [Test, Performance]
        public void BooleanReflection()
        {
            RunJSCallCSReflection("BooleanArg", "true");
        }

        [Test, Performance]
        public void DateStatic()
        {
            RunJSCallCSStatic("DateArg", "new Date");
        }

        [Test, Performance]
        public void DateReflection()
        {
            RunJSCallCSReflection("DateArg", "new Date");
        }

        [Test, Performance]
        public void BigIntStatic()
        {
            RunJSCallCSStatic("BigIntArg", "9223372036854775807n");
        }

        [Test, Performance]
        public void BigIntReflection()
        {
            RunJSCallCSReflection("BigIntArg", "9223372036854775807n");
        }

        [Test, Performance]
        public void StringStatic()
        {
            RunJSCallCSStatic("StringArg", "'hello'");
        }

        [Test, Performance]
        public void StringReflection()
        {
            RunJSCallCSReflection("StringArg", "'hello'");
        }

        [Test, Performance]
        public void ArrayBufferStatic()
        {
            RunJSCallCSStatic("ArrayBufferArg", "new ArrayBuffer(3)");
        }

        [Test, Performance]
        public void ArrayBufferReflection()
        {
            RunJSCallCSReflection("ArrayBufferArg", "new ArrayBuffer(3)");
        }

        [Test, Performance]
        public void NativeObjectStatic()
        {
            RunJSCallCSStatic("NativeObjectArg", "new CS.NativeObjectClass");
        }

        [Test, Performance]
        public void NativeObjectReflection()
        {
            RunJSCallCSReflection("NativeObjectArg", "new CS.NativeObjectClass");
        }
    }
}
