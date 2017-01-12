/*
 * Tencent is pleased to support the open source community by making xLua available.
 * Copyright (C) 2016 THL A29 Limited, a Tencent company. All rights reserved.
 * Licensed under the MIT License (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
 * http://opensource.org/licenses/MIT
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XLua;
using System;
using UnityEngine.UI;

[System.Serializable]
public class Injection
{
    public string name;
    public GameObject value;
}

//! 添加标签 lua调用 C#
[LuaCallCSharp]
public class LuaBehaviour : MonoBehaviour {
    public TextAsset luaScript;
    public Injection[] injections;   //! injections 数组， lua可以获取

	public int rotateSpeed = 100; 

    internal static LuaEnv luaEnv = new LuaEnv(); //all lua behaviour shared one luaenv only!
    internal static float lastGCTime = 0;
    internal const float GCInterval = 1;//1 second 

    private Action luaStart;       //! lua 脚本中的Start方法
    private Action luaUpdate;      //! lua 脚本中的Update方法
    private Action luaOnDestroy;   //! lua 脚本中的OnDestroy方法


    private LuaTable scriptEnv;    //! lua vm

    void Awake()
    {
        scriptEnv = luaEnv.NewTable();  //! 创建 lua VM

        LuaTable meta = luaEnv.NewTable();   //! 元表
        meta.Set("__index", luaEnv.Global);
        scriptEnv.SetMetaTable(meta);
        meta.Dispose();

        scriptEnv.Set("self", this);
        foreach (var injection in injections)
        {
            scriptEnv.Set(injection.name, injection.value);
        }

        luaEnv.DoString(luaScript.text, "LuaBehaviour", scriptEnv);  //! 执行 lua文件

        Action luaAwake = scriptEnv.Get<Action>("awake");   //! 获取 lua 中的 Action awake
		scriptEnv.Get("start", out luaStart);               //! 获取 lua 中的 Action start
		scriptEnv.Get("update", out luaUpdate);             //! 获取 lua 中的 Action update  
		scriptEnv.Get("ondestroy", out luaOnDestroy);       //! 获取 lua 中的 Action ondestroy
		scriptEnv.Set("speed", 1000);

		int speed = 0;
		scriptEnv.Get ("speed", out speed);
		Debug.Log ("Speed From Lua:" + speed);

        if (luaAwake != null)
        {
            luaAwake();
        }

    }

	// Use this for initialization
	void Start ()
    {
        if (luaStart != null)
        {

			//! self:GetComponent("Button").onClick:AddListener(function()
			//! print("clicked, you input is '" ..input:GetComponent("InputField").text .."'")
			//! end)
			//! this.GetComponent<Button> ().onClick.AddListener (delegate() {
			//! 	Debug.Log("In C#, OnClick Button");	
			//! });
            luaStart();        //! 调用 lua 脚本中的 Start
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
		//! for test 每帧设置speed
		scriptEnv.Set("speed", rotateSpeed);

        if (luaUpdate != null)
        {
			luaUpdate(); //! 调用 lua 脚本中的 Start
        }
        if (Time.time - LuaBehaviour.lastGCTime > GCInterval)
        {
            luaEnv.Tick();
            LuaBehaviour.lastGCTime = Time.time;
        }
	}

    void OnDestroy()
    {
        if (luaOnDestroy != null)
        {
			luaOnDestroy(); //! 调用 lua 脚本中的 OnDestroy
        }
        luaOnDestroy = null;
        luaUpdate = null;
        luaStart = null;
        scriptEnv.Dispose();  //! 释放lua vm
        injections = null; 
    }
}
