#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class XLuaClassWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(XLuaClass);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 14, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "EmptyFunction", _m_EmptyFunction_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IntArg", _m_IntArg_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IntArgChecked", _m_IntArgChecked_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "BooleanArg", _m_BooleanArg_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "BooleanArgChecked", _m_BooleanArgChecked_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "StringArg", _m_StringArg_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "StringArgChecked", _m_StringArgChecked_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DateArg", _m_DateArg_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DateArgChecked", _m_DateArgChecked_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "BigIntArg", _m_BigIntArg_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "BigIntArgChecked", _m_BigIntArgChecked_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "NativeObjectArg", _m_NativeObjectArg_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "NativeObjectArgChecked", _m_NativeObjectArgChecked_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new XLuaClass();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to XLuaClass constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EmptyFunction_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    XLuaClass.EmptyFunction(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IntArg_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                    XLuaClass.IntArg( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IntArgChecked_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                    XLuaClass.IntArgChecked( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BooleanArg_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                    XLuaClass.BooleanArg( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BooleanArgChecked_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                    XLuaClass.BooleanArgChecked( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StringArg_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                    XLuaClass.StringArg( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StringArgChecked_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                    XLuaClass.StringArgChecked( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DateArg_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                    XLuaClass.DateArg( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DateArgChecked_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                    XLuaClass.DateArgChecked( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BigIntArg_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                    XLuaClass.BigIntArg( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BigIntArgChecked_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                    XLuaClass.BigIntArgChecked( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NativeObjectArg_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    NativeObjectClass _value = (NativeObjectClass)translator.GetObject(L, 1, typeof(NativeObjectClass));
                    
                    XLuaClass.NativeObjectArg( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NativeObjectArgChecked_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    NativeObjectClass _value = (NativeObjectClass)translator.GetObject(L, 1, typeof(NativeObjectClass));
                    
                    XLuaClass.NativeObjectArgChecked( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
