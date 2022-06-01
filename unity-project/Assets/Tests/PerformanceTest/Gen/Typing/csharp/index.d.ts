
declare module 'csharp' {
    namespace CSharp {
        interface $Ref<T> {
            value: T
        }
        namespace System {
            interface Array$1<T> extends System.Array {
                get_Item(index: number):T;
                set_Item(index: number, value: T):void;
            }
        }
        interface $Task<T> {}
            class TestClassStatic extends System.Object
            {
                public static EmptyFunction () : void
                public static ReturnIntValue () : number
                public static ReturnBooleanValue () : boolean
                public static ReturnStringValue () : string
                public static ReturnDateValue () : Date
                public static ReturnBigIntValue () : bigint
                public static ReturnArrayBufferValue () : ArrayBuffer
                public static ReturnNativeObjectValue () : NativeObjectClass
                public static IntArg ($value: number) : void
                public static IntArgChecked ($value: number) : void
                public static BooleanArg ($value: boolean) : void
                public static BooleanArgChecked ($value: boolean) : void
                public static StringArg ($value: string) : void
                public static StringArgChecked ($value: string) : void
                public static DateArg ($value: Date) : void
                public static DateArgChecked ($value: Date) : void
                public static BigIntArg ($value: bigint) : void
                public static BigIntArgChecked ($value: bigint) : void
                public static ArrayBufferArg ($value: ArrayBuffer) : void
                public static ArrayBufferArgChecked ($value: ArrayBuffer) : void
                public static NativeObjectArg ($value: NativeObjectClass) : void
                public static NativeObjectArgChecked ($value: NativeObjectClass) : void
                public static IntOut ($value: $Ref<number>) : void
                public static BooleanOut ($value: $Ref<boolean>) : void
                public static StringOut ($value: $Ref<string>) : void
                public static DateOut ($value: $Ref<Date>) : void
                public static BigIntOut ($value: $Ref<bigint>) : void
                public static ArrayBufferOut ($value: $Ref<ArrayBuffer>) : void
                public static NativeObjectOut ($value: $Ref<NativeObjectClass>) : void
                public static IntRef ($value: $Ref<number>) : void
                public static BooleanRef ($value: $Ref<boolean>) : void
                public static StringRef ($value: $Ref<string>) : void
                public static DateRef ($value: $Ref<Date>) : void
                public static BigIntRef ($value: $Ref<bigint>) : void
                public static ArrayBufferRef ($value: $Ref<ArrayBuffer>) : void
                public static NativeObjectRef ($value: $Ref<NativeObjectClass>) : void
                public constructor ()
            }
            class NativeObjectClass extends System.Object
            {
            }
            namespace System {
            class Object
            {
            }
            class Void extends System.ValueType
            {
            }
            class ValueType extends System.Object
            {
            }
            class Int32 extends System.ValueType implements System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>, System.IFormattable
            {
            }
            interface IComparable
            {
            }
            interface IComparable$1<T>
            {
            }
            interface IConvertible
            {
            }
            interface IEquatable$1<T>
            {
            }
            interface IFormattable
            {
            }
            class Boolean extends System.ValueType implements System.IComparable, System.IComparable$1<boolean>, System.IConvertible, System.IEquatable$1<boolean>
            {
            }
            class String extends System.Object implements System.ICloneable, System.Collections.IEnumerable, System.IComparable, System.IComparable$1<string>, System.IConvertible, System.IEquatable$1<string>, System.Collections.Generic.IEnumerable$1<number>
            {
            }
            interface ICloneable
            {
            }
            class Char extends System.ValueType implements System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
            {
            }
            class DateTime extends System.ValueType implements System.IComparable, System.IComparable$1<Date>, System.IConvertible, System.IEquatable$1<Date>, System.Runtime.Serialization.ISerializable, System.IFormattable
            {
            }
            class Int64 extends System.ValueType implements System.IComparable, System.IComparable$1<bigint>, System.IConvertible, System.IEquatable$1<bigint>, System.IFormattable
            {
            }
            class Array extends System.Object implements System.ICloneable, System.Collections.IEnumerable, System.Collections.IList, System.Collections.IStructuralComparable, System.Collections.IStructuralEquatable, System.Collections.ICollection
            {
            }
        }
        namespace System.Collections {
            interface IEnumerable
            {
            }
            interface IList extends System.Collections.IEnumerable, System.Collections.ICollection
            {
            }
            interface ICollection extends System.Collections.IEnumerable
            {
            }
            interface IStructuralComparable
            {
            }
            interface IStructuralEquatable
            {
            }
        }
        namespace System.Collections.Generic {
            interface IEnumerable$1<T> extends System.Collections.IEnumerable
            {
            }
        }
        namespace System.Runtime.Serialization {
            interface ISerializable
            {
            }
        }
        namespace Puerts {
            class ArrayBuffer extends System.Object
            {
            }
        }
    }
    export = CSharp;
}
