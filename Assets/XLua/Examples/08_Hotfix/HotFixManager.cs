using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class HotFixManager : MonoBehaviour {

	LuaEnv luaenv = new LuaEnv();

	void Awake(){
		
	}

	// Use this for initialization
	void Start () {
		HotFix ();   //! 打补丁

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected void HotFix(){
		luaenv.DoString(@"
                local tick = 0
                xlua.hotfix(CS.HotfixTest, 'Update', function()
                    tick = tick + 1
                    if (tick % 50) == 0 then
                        print('<<<<<<<<Update in lua, tick = ' .. tick)
                    end
                end)
            ");
	}
}
