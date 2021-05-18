using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inouttest : MonoBehaviour
{

    static Puerts.JsEnv jsEnv;

    public static void test(DateTime value) {
    }

    // Start is called before the first frame update
    void Start()
    {
        jsEnv = new Puerts.JsEnv();
        jsEnv.Eval("require('csharp').inouttest.test(new Date)");

        int a = 1;
        Debug.Log(inValue(a));
        Debug.Log(a);
        Debug.Log("===");

        int b = 1;
        Debug.Log(refValue(ref b));
        Debug.Log(b);
        Debug.Log("===");

        int c = 1;
        Debug.Log(outValue(out c));
        Debug.Log(c);
        Debug.Log("===");

        Num d = new Num();
        Num resd = Object(d);
        Debug.Log(resd.number);
        Debug.Log(d.number);
        Debug.Log(d == resd);
        Debug.Log("===");

        Num e = new Num();
        Num rese = inObject(e);
        Debug.Log(rese.number);
        Debug.Log(e.number);
        Debug.Log(e == rese);
        Debug.Log("===");

        Num f = new Num();
        Num resf = refObject(ref f);
        Debug.Log(resf.number);
        Debug.Log(f.number);
        Debug.Log(f == resf);
        Debug.Log("===");

        Num g = new Num();
        Num resg = outObject(out g);
        Debug.Log(resg.number);
        Debug.Log(g.number);
        Debug.Log(g == resg);
        Debug.Log("===");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int inValue(in int number)
    {
        Debug.Log("called in:" + number);
        return number;
    }

    private int outValue(out int number)
    {
        Debug.Log("called out:"/* + number*/);
        number = 3;
        return number;
    }

    private int refValue(ref int number)
    {
        Debug.Log("called ref:" + number);
        number = 3;
        return number;
    }

    class Num {
        public int number = 0;
    }
    private Num Object(Num number)
    {
        Debug.Log("called:" + number.number);
        number = new Num();
        number.number = 3;
        return number;
    }
    private Num inObject(in Num number)
    {
        Debug.Log("called in:" + number.number);
        number.number = 3;
        return number;
    }
    private Num refObject(ref Num number)
    {
        Debug.Log("called ref:" + number.number);
        number = new Num();
        number.number = 3;
        return number;
    }
    private Num outObject(out Num number)
    {
        Debug.Log("called out:"/* + number*/);
        number = new Num();
        number.number = 3;
        return number;
    }
}
