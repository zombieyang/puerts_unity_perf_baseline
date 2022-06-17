using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;
using UnityEngine.TestTools;

// public class XTest
// {
//     // A Test behaves as an ordinary method
//     [Test]
//     public void XLuaSimplePasses()
//     {
//         // Use the Assert class to test conditions
//         env.DoString("id = 3");
//         int i;
//         env.Global.Get("id", out i);
//         Assert.True(i == 3);
//     }
// }


public class GetLuaCallArgument
{
    private void RunLuaCallCS(bool isReflection, string methodName, string jsValue)
    {
        string className = isReflection ? "XLuaClassReflection" : "XLuaClass";
        XLua.LuaEnv env = new XLua.LuaEnv();

        
        env.translator.DelayWrapLoader(typeof(XLuaClass), XLua.CSObjectWrap.XLuaClassWrap.__Register);
        env.DoString(string.Format("for i=0,{3},1 do CS.{0}.{1}({2}) end", className, methodName, jsValue, PuertsPerformanceUtil.warmUpRepeatCount));
        Measure
            .Method(() =>
            {
                env.DoString(string.Format("for i=0,{3},1 do CS.{0}.{1}({2}) end", className, methodName, jsValue, PuertsPerformanceUtil.repeatCount));
            })
            .WarmupCount(PuertsPerformanceUtil.warmUpCount)
            .MeasurementCount(PuertsPerformanceUtil.SampleCount)
            .Run();

        env.DoString(string.Format("CS.{0}.{1}Checked({2})", className, methodName, jsValue));
    }

    private void RunJSCallCSStatic(string methodName, string jsValue)
    {
        RunLuaCallCS(false, methodName, jsValue);
    }

    private void RunJSCallCSReflection(string methodName, string jsValue)
    {
        RunLuaCallCS(true, methodName, jsValue);
    }

    [Test, Performance]
    public void IntStaticXLua()
    {
        RunJSCallCSStatic("IntArg", "1");
    }

    [Test, Performance]
    public void IntReflectionXLua()
    {
        RunJSCallCSReflection("IntArg", "1");
    }

    [Test, Performance]
    public void BooleanStaticXLua()
    {
        RunJSCallCSStatic("BooleanArg", "true");
    }

    [Test, Performance]
    public void BooleanReflectionXLua()
    {
        RunJSCallCSReflection("BooleanArg", "true");
    }

    [Test, Performance]
    public void StringStaticXLua()
    {
        RunJSCallCSStatic("StringArg", "'hello'");
    }

    [Test, Performance]
    public void StringReflectionXLua()
    {
        RunJSCallCSReflection("StringArg", "'hello'");
    }

    [Test, Performance]
    public void NativeObjectStaticXLua()
    {
        RunJSCallCSStatic("NativeObjectArg", "CS.NativeObjectClass()");
    }

    [Test, Performance]
    public void NativeObjectReflectionXLua()
    {
        RunJSCallCSReflection("NativeObjectArg", "CS.NativeObjectClass()");
    }
}