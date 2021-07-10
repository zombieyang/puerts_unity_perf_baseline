using Puerts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

[LuaCallCSharp]
public class NewBehaviourScript : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    public Text builtinZombie;
    public Text bindedZombie;

    // Start is called before the first frame update
    unsafe void Start()
    {
        JsEnv env = new JsEnv();
        //JsEnv env = new JsEnv(new DefaultLoader(), 9200);
        //env.WaitDebugger();

        double bindedTime = env.Eval<double>(@"
            (function () {
                const start = Date.now()
                for (let i = 0; i < 10000000; i++) {
                    zombie();
                }
                return Date.now() - start;
            })()
        ");
        bindedZombie.text = "binded: " + bindedTime;

        double builtinTime = env.Eval<double>(@"
            (function () {
                const start = Date.now()
                for (let i = 0; i < 10000000; i++) {
                    String.zombie();
                }
                return Date.now() - start;
            })()
        ");
        builtinZombie.text = "builtin: " + builtinTime;


        PuertsDLL.SetGlobalFunction(env.isolate, "oldCallback", v8FunctionCallback, 0);
        PuertsDLL.SetGlobalFunction(env.isolate, "newCallback", newFunctionCallback, 0);
        double resultOld = env.Eval<double>(@"
            for (var i = 0; i < 10000; i++)
                global.oldCallback(1,2,3,4)
            var start1 = Date.now();
            for (var i = 0; i < 1000000; i++)
                global.oldCallback(1,2,3,4)
            
            Date.now() - start1;
        ");
        text1.text = "old: " + resultOld;
        double resultNew = env.Eval<double>(@"
            for (var i = 0; i < 10000; i++)
                global.newCallback(5,6,7,8)
            var start2 = Date.now();
            for (var i = 0; i < 1000000; i++)
                global.newCallback(5,6,7,8)

            Date.now() - start2;
        ");
        text2.text = "new: " + resultNew;

        LuaEnv luaEnv = new LuaEnv();
        luaEnv.DoString(@"
            local aaa = CS.NewBehaviourScript.int4
            for i=1,10000,1 do
                aaa(1,2,3,4);
            end

            local starttime = os.clock(); 
            for i=1,1000000,1 do
                aaa(1,2,3,4);
            end
            local endtime = os.clock();
            
            usetime = (endtime - starttime) * 1000
        ");
        text3.text = "lua: " + (int)luaEnv.Global.Get<double>("usetime");
    }

    public static void int4(int int1, int int2, int int3, int int4)
    {

    }

    [Puerts.MonoPInvokeCallback(typeof(V8FunctionCallback))]
    public static void v8FunctionCallback(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
    {
        var argHelper0 = new Puerts.ArgumentHelper((int)data, isolate, info, 0);
        var argHelper1 = new Puerts.ArgumentHelper((int)data, isolate, info, 1);
        var argHelper2 = new Puerts.ArgumentHelper((int)data, isolate, info, 2);
        var argHelper3 = new Puerts.ArgumentHelper((int)data, isolate, info, 3);
        {
            var Arg0 = argHelper0.GetInt32(false);
            var Arg1 = argHelper1.GetInt32(false);
            var Arg2 = argHelper2.GetInt32(false);
            var Arg3 = argHelper3.GetInt32(false);

            // UnityEngine.Debug.Log(Arg0 + "_" + Arg1 + "_" + Arg2 + "_" + Arg3);
        }
    }

    [Puerts.MonoPInvokeCallback(typeof(V8Function))]
    public static unsafe void newFunctionCallback(IntPtr isolate, CSharpToJsValue* value, IntPtr self, int paramLen, long data)
    {
        // UnityEngine.Debug.Log(value[0].Data.Number + "_" + value[1].Data.Number + "_" + value[2].Data.Number + "_" + value[3].Data.Number);
    }

    // Update is called once per frame
    void Update()
    {

    }
}