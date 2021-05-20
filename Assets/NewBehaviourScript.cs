using Puerts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public Text text1;
    public Text text2;

    // Start is called before the first frame update
    unsafe void Start()
    {
        JsEnv env = new JsEnv();
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
    }

    [MonoPInvokeCallback(typeof(V8FunctionCallback))]
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

    [MonoPInvokeCallback(typeof(V8Function))]
    public static unsafe void newFunctionCallback(IntPtr isolate, CSharpToJsValue* value, IntPtr self, int paramLen, long data)
    {
        // UnityEngine.Debug.Log(value[0].Data.Number + "_" + value[1].Data.Number + "_" + value[2].Data.Number + "_" + value[3].Data.Number);
    }

    // Update is called once per frame
    void Update()
    {

    }
}