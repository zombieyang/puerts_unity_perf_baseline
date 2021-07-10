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
    public class NewBehaviourScriptWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(NewBehaviourScript);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 5, 5);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "text1", _g_get_text1);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "text2", _g_get_text2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "text3", _g_get_text3);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "builtinZombie", _g_get_builtinZombie);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "bindedZombie", _g_get_bindedZombie);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "text1", _s_set_text1);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "text2", _s_set_text2);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "text3", _s_set_text3);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "builtinZombie", _s_set_builtinZombie);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "bindedZombie", _s_set_bindedZombie);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 3, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "int4", _m_int4_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "v8FunctionCallback", _m_v8FunctionCallback_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new NewBehaviourScript();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to NewBehaviourScript constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_int4_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _int1 = LuaAPI.xlua_tointeger(L, 1);
                    int _int2 = LuaAPI.xlua_tointeger(L, 2);
                    int _int3 = LuaAPI.xlua_tointeger(L, 3);
                    int _int4 = LuaAPI.xlua_tointeger(L, 4);
                    
                    NewBehaviourScript.int4( _int1, _int2, _int3, _int4 );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_v8FunctionCallback_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    System.IntPtr _isolate = LuaAPI.lua_touserdata(L, 1);
                    System.IntPtr _info = LuaAPI.lua_touserdata(L, 2);
                    System.IntPtr _self = LuaAPI.lua_touserdata(L, 3);
                    int _paramLen = LuaAPI.xlua_tointeger(L, 4);
                    long _data = LuaAPI.lua_toint64(L, 5);
                    
                    NewBehaviourScript.v8FunctionCallback( _isolate, _info, _self, _paramLen, _data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_text1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NewBehaviourScript gen_to_be_invoked = (NewBehaviourScript)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.text1);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_text2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NewBehaviourScript gen_to_be_invoked = (NewBehaviourScript)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.text2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_text3(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NewBehaviourScript gen_to_be_invoked = (NewBehaviourScript)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.text3);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_builtinZombie(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NewBehaviourScript gen_to_be_invoked = (NewBehaviourScript)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.builtinZombie);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bindedZombie(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NewBehaviourScript gen_to_be_invoked = (NewBehaviourScript)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.bindedZombie);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_text1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NewBehaviourScript gen_to_be_invoked = (NewBehaviourScript)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.text1 = (UnityEngine.UI.Text)translator.GetObject(L, 2, typeof(UnityEngine.UI.Text));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_text2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NewBehaviourScript gen_to_be_invoked = (NewBehaviourScript)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.text2 = (UnityEngine.UI.Text)translator.GetObject(L, 2, typeof(UnityEngine.UI.Text));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_text3(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NewBehaviourScript gen_to_be_invoked = (NewBehaviourScript)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.text3 = (UnityEngine.UI.Text)translator.GetObject(L, 2, typeof(UnityEngine.UI.Text));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_builtinZombie(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NewBehaviourScript gen_to_be_invoked = (NewBehaviourScript)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.builtinZombie = (UnityEngine.UI.Text)translator.GetObject(L, 2, typeof(UnityEngine.UI.Text));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bindedZombie(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                NewBehaviourScript gen_to_be_invoked = (NewBehaviourScript)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.bindedZombie = (UnityEngine.UI.Text)translator.GetObject(L, 2, typeof(UnityEngine.UI.Text));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
