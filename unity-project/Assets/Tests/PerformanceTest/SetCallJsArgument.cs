// using System;
// using System.Collections;
// using System.Collections.Generic;
// using NUnit.Framework;
// using Puerts;
// using Unity.PerformanceTesting;
// using UnityEngine;
// using UnityEngine.TestTools;

// namespace Tests
// {
//     public class SetCallJsArgument
//     {
//         private void RunAndValidate<Arg0Type>(string validator, Arg0Type arg)
//         {
//             JsEnv jsEnv = new JsEnv();
            
//             jsEnv.UsingAction<Arg0Type>();
//             jsEnv.Eval("global.CS = require('csharp'); global.PUERTS = require('puerts');");

//             Action<Arg0Type> func = jsEnv.Eval<Action<Arg0Type>>("global.func = function (value) {  }; global.func");
//             for (var i = 0; i < PuertsPerformanceUtil.warmUpRepeatCount; i++)
//                 func.Invoke(arg);

//             Measure
//                 .Method(() =>
//                 {
//                     for (var i = 0; i < PuertsPerformanceUtil.repeatCount; i++)
//                         func.Invoke(arg);
//                 })
//                 .WarmupCount(PuertsPerformanceUtil.warmUpCount)
//                 .MeasurementCount(PuertsPerformanceUtil.SampleCount)
//                 .Run();

//             jsEnv.Eval(string.Format("global.func = function (value) {{ if (!({0})) throw new Error('validate failed'); }}", validator));
//         }
//         private void Run<Arg0Type>(Arg0Type arg1)
//         {
//             JsEnv jsEnv = new JsEnv();

//             jsEnv.UsingAction<Arg0Type>();
//             jsEnv.Eval("global.CS = require('csharp'); global.PUERTS = require('puerts');");

//             Action<Arg0Type> func = jsEnv.Eval<Action<Arg0Type>>("global.func = function (value) {  }; global.func");
//             for (var i = 0; i < PuertsPerformanceUtil.warmUpRepeatCount; i++)
//                 func.Invoke(arg1);

//             Measure
//                 .Method(() =>
//                 {
//                     for (var i = 0; i < PuertsPerformanceUtil.repeatCount; i++)
//                         func.Invoke(arg1);
//                 })
//                 .WarmupCount(PuertsPerformanceUtil.warmUpCount)
//                 .MeasurementCount(PuertsPerformanceUtil.SampleCount)
//                 .Run();
//         }
//         private void Run<Arg0Type, Arg1Type>(Arg0Type arg0, Arg1Type arg1)
//         {
//             JsEnv jsEnv = new JsEnv();

//             jsEnv.UsingAction<Arg0Type, Arg1Type>();
//             jsEnv.Eval("global.CS = require('csharp'); global.PUERTS = require('puerts');");

//             Action<Arg0Type, Arg1Type> func = jsEnv.Eval<Action<Arg0Type, Arg1Type>>("global.func = function (value) {  }; global.func");
//             for (var i = 0; i < PuertsPerformanceUtil.warmUpRepeatCount; i++)
//                 func.Invoke(arg0, arg1);

//             Measure
//                 .Method(() =>
//                 {
//                     for (var i = 0; i < PuertsPerformanceUtil.repeatCount; i++)
//                         func.Invoke(arg0, arg1);
//                 })
//                 .WarmupCount(PuertsPerformanceUtil.warmUpCount)
//                 .MeasurementCount(PuertsPerformanceUtil.SampleCount)
//                 .Run();
//         }
//         private void Run<Arg0Type, Arg1Type, Arg2Type>(Arg0Type arg0, Arg1Type arg1, Arg2Type arg2)
//         {
//             JsEnv jsEnv = new JsEnv();

//             jsEnv.UsingAction<Arg0Type, Arg1Type, Arg2Type>();
//             jsEnv.Eval("global.CS = require('csharp'); global.PUERTS = require('puerts');");

//             Action<Arg0Type, Arg1Type, Arg2Type> func = jsEnv.Eval<Action<Arg0Type, Arg1Type, Arg2Type>>("global.func = function (value) {  }; global.func");
//             for (var i = 0; i < PuertsPerformanceUtil.warmUpRepeatCount; i++)
//                 func.Invoke(arg0, arg1, arg2);

//             Measure
//                 .Method(() =>
//                 {
//                     for (var i = 0; i < PuertsPerformanceUtil.repeatCount; i++)
//                         func.Invoke(arg0, arg1, arg2);
//                 })
//                 .WarmupCount(PuertsPerformanceUtil.warmUpCount)
//                 .MeasurementCount(PuertsPerformanceUtil.SampleCount)
//                 .Run();
//         }
//         private void Run<Arg0Type, Arg1Type, Arg2Type, Arg3Type>(Arg0Type arg0, Arg1Type arg1, Arg2Type arg2, Arg3Type arg3)
//         {
//             JsEnv jsEnv = new JsEnv();

//             jsEnv.UsingAction<Arg0Type, Arg1Type, Arg2Type, Arg3Type>();
//             jsEnv.Eval("global.CS = require('csharp'); global.PUERTS = require('puerts');");

//             Action<Arg0Type, Arg1Type, Arg2Type, Arg3Type> func = jsEnv.Eval<Action<Arg0Type, Arg1Type, Arg2Type, Arg3Type>>("global.func = function (value) {  }; global.func");
//             for (var i = 0; i < PuertsPerformanceUtil.warmUpRepeatCount; i++)
//                 func.Invoke(arg0, arg1, arg2, arg3);

//             Measure
//                 .Method(() =>
//                 {
//                     for (var i = 0; i < PuertsPerformanceUtil.repeatCount; i++)
//                         func.Invoke(arg0, arg1, arg2, arg3);
//                 })
//                 .WarmupCount(PuertsPerformanceUtil.warmUpCount)
//                 .MeasurementCount(PuertsPerformanceUtil.SampleCount)
//                 .Run();
//         }

//         [Test, Performance]
//         public void Int()
//         {
//             RunAndValidate<int>("typeof value == 'number'", 1);
//         }

//         [Test, Performance]
//         public void Int1()
//         {
//             Run<int>(1);
//         }

//         [Test, Performance]
//         public void Int2()
//         {
//             Run<int, int>(1, 2);
//         }

//         [Test, Performance]
//         public void Int3()
//         {
//             Run<int, int, int>(1, 2, 3);
//         }

//         [Test, Performance]
//         public void Int4()
//         {
//             Run<int, int, int, int>(1, 2, 3, 4);
//         }

//         [Test, Performance]
//         public void Boolean()
//         {
//             RunAndValidate<bool>("typeof value == 'boolean'", true);
//         }

//         [Test, Performance]
//         public void Date()
//         {
//             RunAndValidate<DateTime>("value instanceof Date", DateTime.Now);
//         }

//         [Test, Performance]
//         public void BigInt()
//         {
//             RunAndValidate<long>("typeof value == 'bigint'", 9223372036854775807);

//         }

//         [Test, Performance]
//         public void String()
//         {
//             RunAndValidate<string>("typeof value == 'string'", "hello");
//         }

//         [Test, Performance]
//         public void ArrayBuffer()
//         {
//             byte[] bytes = { 1 };
//             RunAndValidate<Puerts.ArrayBuffer>("value instanceof ArrayBuffer", new Puerts.ArrayBuffer(bytes));
//         }

//         [Test, Performance]
//         public void NativeObject()
//         {
//             RunAndValidate<NativeObjectClass>("value instanceof CS.NativeObjectClass", new NativeObjectClass());
//         }
//     }
// }
