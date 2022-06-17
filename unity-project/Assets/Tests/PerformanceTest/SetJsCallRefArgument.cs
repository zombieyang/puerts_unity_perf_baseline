// using System;
// using NUnit.Framework;
// using Puerts;
// using Unity.PerformanceTesting;

// namespace Tests
// {
//     public class SetJsCallRefArgument
//     {
//         private ResultType Run<ResultType>(bool isReflection, string jsValue, string methodName)
//         {
//             string className = isReflection ? "TestClassReflection" : "TestClassStatic";
//             JsEnv jsEnv = new JsEnv();
//             jsEnv.Eval("global.CS = require('csharp'); global.PUERTS = require('puerts');");
//             jsEnv.Eval(string.Format("for (let i = 0; i < {3}; i++) {{ const ref = PUERTS.$ref({0}); CS.{1}.{2}(ref); PUERTS.$unref(ref); }}", jsValue, className, methodName, PuertsPerformanceUtil.warmUpRepeatCount));
//             Measure
//                 .Method(() =>
//                 {
//                     jsEnv.Eval(string.Format("for (let i = 0; i < {3}; i++) {{ const ref = PUERTS.$ref({0}); CS.{1}.{2}(ref); PUERTS.$unref(ref); }}", jsValue, className, methodName, PuertsPerformanceUtil.repeatCount));
//                 })
//                 .WarmupCount(PuertsPerformanceUtil.warmUpCount)
//                 .MeasurementCount(PuertsPerformanceUtil.SampleCount)
//                 .Run();

//             return jsEnv.Eval<ResultType>(string.Format("var ref = PUERTS.$ref({0}); CS.{1}.{2}(ref); PUERTS.$unref(ref);", jsValue, className, methodName));
//         }

//         [Test, Performance]
//         public void IntStatic()
//         {
//             var result = Run<int>(false, "1", "IntRef");

//             Assert.IsTrue(result == 2);
//         }

//         [Test, Performance]
//         public void IntReflection()
//         {
//             var result = Run<int>(true, "1", "IntRef");

//             Assert.IsTrue(result == 2);
//         }

//         [Test, Performance]
//         public void BooleanStatic()
//         {
//             var result = Run<bool>(false, "false", "BooleanRef");

//             Assert.IsTrue(result);
//         }

//         [Test, Performance]
//         public void BooleanReflection()
//         {
//             var result = Run<bool>(true, "false", "BooleanRef");

//             Assert.IsTrue(result);
//         }

//         [Test, Performance]
//         public void DateStatic()
//         {
//             var result = Run<DateTime>(false, "new Date", "DateRef");

//             Assert.IsTrue(result.Year > 2000);
//         }

//         [Test, Performance]
//         public void DateReflection()
//         {
//             var result = Run<DateTime>(true, "new Date", "DateRef");

//             Assert.IsTrue(result.Year > 2000);
//         }

//         [Test, Performance]
//         public void BigIntStatic()
//         {
//             var result = Run<long>(false, "9223372036854775807n", "BigIntRef");

//             Assert.IsTrue(result > 922337203685477);
//         }

//         [Test, Performance]
//         public void BigIntReflection()
//         {
//             var result = Run<long>(true, "9223372036854775807n", "BigIntRef");

//             Assert.IsTrue(result > 922337203685477);
//         }

//         [Test, Performance]
//         public void StringStatic()
//         {
//             var result = Run<string>(false, "'hello'", "StringRef");

//             Assert.IsTrue(result.Length > 0);
//         }

//         [Test, Performance]
//         public void StringReflection()
//         {
//             var result = Run<string>(true, "'hello'", "StringRef");

//             Assert.IsTrue(result.Length > 0);
//         }

//         [Test, Performance]
//         public void ArrayBufferStatic()
//         {
//             var result = Run<Puerts.ArrayBuffer>(false, "new ArrayBuffer(3)", "ArrayBufferRef");

//             Assert.IsTrue(result.Bytes.Length > 0);
//         }

//         [Test, Performance]
//         public void ArrayBufferReflection()
//         {
//             var result = Run<Puerts.ArrayBuffer>(true, "new ArrayBuffer(3)", "ArrayBufferRef");

//             Assert.IsTrue(result.Bytes.Length > 0);
//         }

//         [Test, Performance]
//         public void NativeObjectStatic()
//         {
//             var result = Run<NativeObjectClass>(false, "new CS.NativeObjectClass", "NativeObjectRef");

//             Assert.IsTrue(result.name == "NOC");
//         }

//         [Test, Performance]
//         public void NativeObjectReflection()
//         {
//             var result = Run<NativeObjectClass>(true, "new CS.NativeObjectClass", "NativeObjectRef");

//             Assert.IsTrue(result.name == "NOC");
//         }
//     }
// }
