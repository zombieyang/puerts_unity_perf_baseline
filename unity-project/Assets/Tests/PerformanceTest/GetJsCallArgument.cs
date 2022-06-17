﻿using System.Collections;
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
            jsEnv.AddLazyStaticWrapLoader(typeof(TestClassStatic), PuertsStaticWrap.TestClassStatic_Wrap.GetRegisterInfo);
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
        public void IntStaticPuerts()
        {
            RunJSCallCSStatic("IntArg", "1");
        }

        [Test, Performance]
        public void IntReflectionPuerts()
        {
            RunJSCallCSReflection("IntArg", "1");
        }

        [Test, Performance]
        public void BooleanStaticPuerts()
        {
            RunJSCallCSStatic("BooleanArg", "true");
        }

        [Test, Performance]
        public void BooleanReflectionPuerts()
        {
            RunJSCallCSReflection("BooleanArg", "true");
        }

        [Test, Performance]
        public void DateStaticPuerts()
        {
            RunJSCallCSStatic("DateArg", "new Date");
        }

        [Test, Performance]
        public void DateReflectionPuerts()
        {
            RunJSCallCSReflection("DateArg", "new Date");
        }

        [Test, Performance]
        public void BigIntStaticPuerts()
        {
            RunJSCallCSStatic("BigIntArg", "9223372036854775807n");
        }

        [Test, Performance]
        public void BigIntReflectionPuerts()
        {
            RunJSCallCSReflection("BigIntArg", "9223372036854775807n");
        }

        [Test, Performance]
        public void StringStaticPuerts()
        {
            RunJSCallCSStatic("StringArg", "'hello'");
        }

        [Test, Performance]
        public void StringReflectionPuerts()
        {
            RunJSCallCSReflection("StringArg", "'hello'");
        }

        [Test, Performance]
        public void ArrayBufferStaticPuerts()
        {
            RunJSCallCSStatic("ArrayBufferArg", "new ArrayBuffer(3)");
        }

        [Test, Performance]
        public void ArrayBufferReflectionPuerts()
        {
            RunJSCallCSReflection("ArrayBufferArg", "new ArrayBuffer(3)");
        }

        [Test, Performance]
        public void NativeObjectStaticPuerts()
        {
            RunJSCallCSStatic("NativeObjectArg", "new CS.NativeObjectClass");
        }

        [Test, Performance]
        public void NativeObjectReflectionPuerts()
        {
            RunJSCallCSReflection("NativeObjectArg", "new CS.NativeObjectClass");
        }
    }
}
