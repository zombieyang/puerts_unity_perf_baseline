using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class XLuaTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void XLuaSimplePasses()
    {
        // Use the Assert class to test conditions
        XLua.LuaEnv env = new XLua.LuaEnv();
        env.DoString("id = 3");
        int i;
        env.Global.Get("id", out i);
        Assert.True(i == 3);

        Puerts.jsEnv JsEnv = new Puerts.JsEnv();
        int j = JsEnv.Eval<int>("4");
        Assert.True(j == 4);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator XLuaWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
