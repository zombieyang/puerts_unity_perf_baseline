using System;
using Puerts;
using UnityEngine.Assertions;

public class NativeObjectClass {
    public string name = "NativeObject";
}

public class TestClassReflection
{
    public static void EmptyFunction() { }


    public static int ReturnIntValue() { return 1; }

    public static bool ReturnBooleanValue() { return true; }

    public static string ReturnStringValue() { return "puerts"; }

    public static DateTime ReturnDateValue() { return DateTime.Now; }

    public static long ReturnBigIntValue() { long l = 9223372036854775807; return l; }

    public static ArrayBuffer ReturnArrayBufferValue() { byte[] bytes = { }; return new ArrayBuffer(bytes); }

    public static NativeObjectClass ReturnNativeObjectValue() { return new NativeObjectClass(); }

    public static void IntArg(int value) { }
    public static void IntArgChecked(int value) { Assert.IsTrue(value > 0); }

    public static void BooleanArg(bool value) { }
    public static void BooleanArgChecked(bool value) { Assert.IsTrue(value); }

    public static void StringArg(string value) { }
    public static void StringArgChecked(string value) { Assert.IsTrue(value.Length > 0); }

    public static void DateArg(DateTime value) { }
    public static void DateArgChecked(DateTime value) { Assert.IsTrue(value.Year > 2000); }

    public static void BigIntArg(long value) { }
    public static void BigIntArgChecked(long value) { Assert.IsTrue(value > 922337203685477); }

    public static void ArrayBufferArg(Puerts.ArrayBuffer value) { }
    public static void ArrayBufferArgChecked(Puerts.ArrayBuffer value) { Assert.IsTrue(value.Bytes.Length > 0); }

    public static void NativeObjectArg(NativeObjectClass value) { }
    public static void NativeObjectArgChecked(NativeObjectClass value) { Assert.IsTrue(value.name == "NativeObject"); }


    public static void IntOut(out int value) { value = 3; }

    public static void BooleanOut(out bool value) { value = true; }

    public static void StringOut(out string value) { value = "hello"; }

    public static void DateOut(out DateTime value) { value = DateTime.Now; }

    public static void BigIntOut(out long value) { value = 9223372036854775807; }

    public static void ArrayBufferOut(out Puerts.ArrayBuffer value) { byte[] bytes = { 1 }; value = new ArrayBuffer(bytes); }

    public static void NativeObjectOut(out NativeObjectClass value) { value = new NativeObjectClass(); }


    public static void IntRef(ref int value) { value++; }

    public static void BooleanRef(ref bool value) { value = !value; }

    public static void StringRef(ref string value) { value += "hello"; }

    public static void DateRef(ref DateTime value) { value = value.AddYears(1); }

    public static void BigIntRef(ref long value) { value -= 1; }

    public static void ArrayBufferRef(ref Puerts.ArrayBuffer value) { byte[] bytes = { 1 }; value = new ArrayBuffer(bytes); /*一时没想到怎么修改ab，先留着*/ }

    public static void NativeObjectRef(ref NativeObjectClass value) { value.name = "NOC"; }
}
public class TestClassStatic
{
    public static void EmptyFunction() { }


    public static int ReturnIntValue() { return 1; }

    public static bool ReturnBooleanValue() { return true; }

    public static string ReturnStringValue() { return "puerts"; }

    public static DateTime ReturnDateValue() { return DateTime.Now; }

    public static long ReturnBigIntValue() { long l = 9223372036854775807; return l; }

    public static ArrayBuffer ReturnArrayBufferValue() { byte[] bytes = { }; return new ArrayBuffer(bytes); }

    public static NativeObjectClass ReturnNativeObjectValue() { return new NativeObjectClass(); }


    public static void IntArg(int value) { }
    public static void IntArgChecked(int value) { Assert.IsTrue(value > 0); }

    public static void BooleanArg(bool value) { }
    public static void BooleanArgChecked(bool value) { Assert.IsTrue(value); }

    public static void StringArg(string value) { }
    public static void StringArgChecked(string value) { Assert.IsTrue(value.Length > 0); }

    public static void DateArg(DateTime value) { }
    public static void DateArgChecked(DateTime value) { Assert.IsTrue(value.Year > 2000); }

    public static void BigIntArg(long value) { }
    public static void BigIntArgChecked(long value) { Assert.IsTrue(value > 922337203685477); }

    public static void ArrayBufferArg(Puerts.ArrayBuffer value) { }
    public static void ArrayBufferArgChecked(Puerts.ArrayBuffer value) { Assert.IsTrue(value.Bytes.Length > 0); }

    public static void NativeObjectArg(NativeObjectClass value) { }
    public static void NativeObjectArgChecked(NativeObjectClass value) { Assert.IsTrue(value.name == "NativeObject"); }


    public static void IntOut(out int value) { value = 3; }

    public static void BooleanOut(out bool value) { value = true; }

    public static void StringOut(out string value) { value = "hello"; }

    public static void DateOut(out DateTime value) { value = DateTime.Now; }

    public static void BigIntOut(out long value) { value = 9223372036854775807; }

    public static void ArrayBufferOut(out Puerts.ArrayBuffer value) { byte[] bytes = { 1 }; value = new ArrayBuffer(bytes); }

    public static void NativeObjectOut(out NativeObjectClass value) { value = new NativeObjectClass(); }


    public static void IntRef(ref int value) { value++; }

    public static void BooleanRef(ref bool value) { value = !value; }

    public static void StringRef(ref string value) { value += "hello"; }

    public static void DateRef(ref DateTime value) { value = value.AddYears(1); }

    public static void BigIntRef(ref long value) { value -= 1; }

    public static void ArrayBufferRef(ref Puerts.ArrayBuffer value) { byte[] bytes = { 1 }; value = new ArrayBuffer(bytes); /*一时没想到怎么修改ab，先留着*/ }

    public static void NativeObjectRef(ref NativeObjectClass value) { value.name = "NOC"; }
}