using UnityEngine;
using System;
using System.Collections.Generic;
using LuaFramework;

using System.Reflection;

public static class CustomSettings
{
    public static string FrameworkPath = AppConst.FrameworkRoot;
    public static string saveDir = FrameworkPath + "/ToLua/Source/Generate/";
    public static string luaDir = FrameworkPath + "/Hotfix/Lua/";
    public static string toluaBaseType = FrameworkPath + "/ToLua/BaseType/";
	public static string toluaLuaDir = FrameworkPath + "/ToLua/Lua";
}
