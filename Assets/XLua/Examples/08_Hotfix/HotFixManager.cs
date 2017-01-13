using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using UnityEngine;
using XLua;
using LuaFramework;

public class HotFixManager : MonoBehaviour {

	protected static bool initialize = false;
	private List<string> downloadFiles = new List<string>();

	LuaEnv luaenv = new LuaEnv();  //! 创建 xlua vm

	void Awake(){

		DontDestroyOnLoad (gameObject);
		Init ();

	}

	void Init(){

		CheckExtractResource ();

		//! check resource
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Application.targetFrameRate = AppConst.GameFrameRate;
	}

	void CheckExtractResource(){

		bool isExists = Directory.Exists (Util.DataPath) &&
		              Directory.Exists (Util.DataPath + "Lua/") && File.Exists (Util.DataPath + "files.txt");
		if (isExists || AppConst.DebugMode) {
			StartCoroutine(OnUpdateResource());
			return;   //文件已经解压过了，自己可添加检查文件列表逻辑
		}
		StartCoroutine(OnExtractResource());    //启动释放协成 

	}

	IEnumerator OnExtractResource() {
		string dataPath = Util.DataPath;  //数据目录
		string resPath = Util.AppContentPath (); //游戏包资源目录

		if (Directory.Exists (dataPath))
			Directory.Delete (dataPath, true);
		Directory.CreateDirectory (dataPath);

		string infile = resPath + "files.txt";
		string outfile = dataPath + "files.txt";
		if (File.Exists (outfile))
			File.Delete (outfile);

		string message = "正在解包文件:>files.txt";
		Debug.Log (message);
		//! facade.SendMessageCommand(NotiConst.UPDATE_MESSAGE, message);   //! 发送更新 消息

		if (Application.platform == RuntimePlatform.Android) {
			WWW www 	= new WWW(infile);
			yield return www;

			if (www.isDone) {
				File.WriteAllBytes(outfile, www.bytes);
			}
			yield return 0;
		} else File.Copy(infile, outfile, true);
		yield return new WaitForEndOfFrame();

		//释放所有文件到数据目录
		string[] files = File.ReadAllLines(outfile);
		foreach (var file in files) {
			string[] fs = file.Split('|');
			infile = resPath + fs[0];  //
			outfile = dataPath + fs[0];

			message = "正在解包文件:>" + fs[0];
			Debug.Log("正在解包文件:>" + infile);
			//! facade.SendMessageCommand(NotiConst.UPDATE_MESSAGE, message);

			string dir = Path.GetDirectoryName(outfile);
			if (!Directory.Exists(dir)) 
				Directory.CreateDirectory(dir);

			if (Application.platform == RuntimePlatform.Android) {
				WWW www = new WWW(infile);
				yield return www;

				if (www.isDone) {
					File.WriteAllBytes(outfile, www.bytes);
				}
				yield return 0;
			} else {
				if (File.Exists(outfile)) {
					File.Delete(outfile);
				}
				File.Copy(infile, outfile, true);
			}
			yield return new WaitForEndOfFrame();
		}
		message = "解包完成!!!";
		//! facade.SendMessageCommand(NotiConst.UPDATE_MESSAGE, message);

		yield return new WaitForSeconds(0.1f);
		message = string.Empty;

		//释放完成，开始启动更新资源
		StartCoroutine(OnUpdateResource());
	}

	/// <summary>
	/// 启动更新下载，这里只是个思路演示，此处可启动线程下载更新
	/// </summary>
	IEnumerator OnUpdateResource() {
		downloadFiles.Clear();

		if (!AppConst.UpdateMode) {
			OnDownloadComplete();
			yield break;
		}

		string dataPath = Util.DataPath;  //数据目录
		string url = AppConst.WebUrl;
		string random = DateTime.Now.ToString("yyyymmddhhmmss");
		string listUrl = url + "files.txt?v=" + random;     //! 
		Debug.LogWarning("LoadUpdate---->>>" + listUrl);

		WWW www = new WWW(listUrl);          //! 获取补丁文件列表
		yield return www;


		if (www.error != null) {
			OnUpdateFailed(string.Empty);
			yield break;
		}
		if (!Directory.Exists(dataPath)) {
			Directory.CreateDirectory(dataPath);
		}
		File.WriteAllBytes(dataPath + "files.txt", www.bytes);  //! 存储 files.txt

		string filesText = www.text;
		string[] files = filesText.Split('\n');

		string message = string.Empty;
		for (int i = 0; i < files.Length; i++) {
			if (string.IsNullOrEmpty(files[i])) 
				continue;
			string[] keyValue = files[i].Split('|');
			string f = keyValue[0];        //! 文件
			string localfile = (dataPath + f).Trim();  //! 本地路径
			string path = Path.GetDirectoryName(localfile); //! 获取本地文件目录
			if (!Directory.Exists(path)) {
				Directory.CreateDirectory(path);
			}
			string fileUrl = url + keyValue[0] + "?v=" + random;  
			bool canUpdate = !File.Exists(localfile); //! 本地是否存在
			if (!canUpdate) {
				string remoteMd5 = keyValue[1].Trim();    //! filelist 中的 md5
				string localMd5 = Util.md5file(localfile); //! 本地文件的md5
				canUpdate = !remoteMd5.Equals(localMd5);  //! 如果不等，则更新
				if (canUpdate) 
					File.Delete(localfile);
			}
			if (canUpdate) {   //本地缺少文件
				Debug.Log(fileUrl);    //! 
				message = "downloading>>" + fileUrl;
				//! facade.SendMessageCommand(NotiConst.UPDATE_MESSAGE, message);
				/*
                    www = new WWW(fileUrl); yield return www;
                    if (www.error != null) {
                        OnUpdateFailed(path);   //
                        yield break;
                    }
                    File.WriteAllBytes(localfile, www.bytes);
                     * */
				//这里都是资源文件，用线程下载
				BeginDownload(fileUrl, localfile);
				while (!(IsDownOK(localfile))) { 
					yield return new WaitForEndOfFrame(); 
				}
			}
		}
		yield return new WaitForEndOfFrame();
		message = "更新完成!!";
		Debug.Log (message);
		//! facade.SendMessageCommand(NotiConst.UPDATE_MESSAGE, message);    //! dispatch Update message 

		OnDownloadComplete();  //! 
	}

	//! 下载完成
	//! 后面该deletegate
	void OnDownloadComplete(){

		//! string strPath = Application.dataPath + "/Hotfix/Lua/HotfixTest.lua";
		//! Debug.Log ("file path:" + strPath);
		//! 
		//! //! for test 直接读取
		//! string strText = File.ReadAllText(strPath);
		//! Debug.Log ("read text:" + strText);
		//! luaenv.DoString (strText);

		string uri = Util.DataPath + "Lua/lua" + AppConst.ExtName;
		Debug.Log("LoadFile::>> " + uri);
		
		AssetBundle luaAB = LoadBundle ("Lua/lua");
	
		UnityEngine.Object obj1 = luaAB.LoadAsset ("HotfixTest.lua.bytes");

		if ( obj1!=null )  
			Debug.Log ("LoadAsset:\"HotfixTest.lua\" success!");     //! 是否成功加载HotfixTest

		//! read as TextAssets
		TextAsset txtAsset = luaAB.LoadAsset<TextAsset>("HotfixTest.lua.bytes");
		Debug.Log ("read lua text:" + txtAsset.text);

		luaenv.DoString (txtAsset.text);    //! 打补丁。


		//! 装载资源
		//! shared = AssetBundle.LoadFromFile(uri);
		//! shared.LoadAsset("Dialog", typeof(GameObject));

	}

	public AssetBundle LoadBundle(string name) {
		string uri = Util.DataPath + name.ToLower() + AppConst.ExtName;
		AssetBundle bundle = AssetBundle.LoadFromFile(uri); //�������ݵ��زİ�
		return bundle;
	}

	/// <summary>
	/// 是否下载完成
	/// </summary>
	bool IsDownOK(string file) {
		return downloadFiles.Contains(file);
	}

	/// <summary>
	/// 线程下载
	/// </summary>
	void BeginDownload(string url, string file) {     //线程下载
		object[] param = new object[2] {url, file};

		ThreadEvent ev = new ThreadEvent();
		ev.Key = NotiConst.UPDATE_DOWNLOAD;
		ev.evParams.AddRange(param);
		ThreadManager.Instance().AddEvent(ev, OnThreadCompleted);   //线程下载
	}

	/// <summary>
	/// 线程完成
	/// </summary>
	/// <param name="data"></param>
	void OnThreadCompleted(NotiData data) {
		switch (data.evName) {
		case NotiConst.UPDATE_EXTRACT:  //解压一个完成
			//
			break;
		case NotiConst.UPDATE_DOWNLOAD: //下载一个完成
			downloadFiles.Add(data.evParam.ToString());
			break;
		}
	}

	void OnUpdateFailed(string file) {
		string message = "更新失败!>" + file;
		//! facade.SendMessageCommand(NotiConst.UPDATE_MESSAGE, message);
	}

	/// <summary>
	/// 资源初始化结束
	/// </summary>
	public void OnResourceInited() {
		
		//! LuaManager.InitStart();
		//! LuaManager.DoFile("Logic/Game");            //加载游戏
		//! LuaManager.DoFile("Logic/Network");         //加载网络
		//! NetManager.OnInit();                        //初始化网络
		//! 
		//! Util.CallMethod("Game", "OnInitOK");          //初始化完成
		//! initialize = true;                          //初始化完 
		//! 
		//! //类对象池测试
		//! var classObjPool = ObjPoolManager.CreatePool<TestObjectClass>(OnPoolGetElement, OnPoolPushElement);
		//! //方法1
		//! //objPool.Release(new TestObjectClass("abcd", 100, 200f));
		//! //var testObj1 = objPool.Get();
		//! 
		//! //方法2
		//! ObjPoolManager.Release<TestObjectClass>(new TestObjectClass("abcd", 100, 200f));
		//! var testObj1 = ObjPoolManager.Get<TestObjectClass>();
		//! 
		//! Debugger.Log("TestObjectClass--->>>" + testObj1.ToString());
		//! 
		//! //游戏对象池测试
		//! var prefab = Resources.Load("TestGameObjectPrefab", typeof(GameObject)) as GameObject;
		//! var gameObjPool = ObjPoolManager.CreatePool("TestGameObject", 5, 10, prefab);
		//! 
		//! var gameObj = Instantiate(prefab) as GameObject;
		//! gameObj.name = "TestGameObject_01";
		//! gameObj.transform.localScale = Vector3.one;
		//! gameObj.transform.localPosition = Vector3.zero;
		//! 
		//! ObjPoolManager.Release("TestGameObject", gameObj);
		//! var backObj = ObjPoolManager.Get("TestGameObject");
		//! backObj.transform.SetParent(null);
		//! 
		//! Debug.Log("TestGameObject--->>>" + backObj);
	}

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {

	}

	/// <summary>
	/// 析构函数
	/// </summary>
	void OnDestroy() {

		//! 不需要
		//! if (NetManager != null) {
		//! 	NetManager.Unload();
		//! }
		//! if (LuaManager != null) {
		//! 	LuaManager.Close();
		//! }
		Debug.Log("~GameManager was destroyed");
	}

}
