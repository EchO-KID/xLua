using UnityEngine;
using System.Collections;
using Ice;
using System.Threading;
using OW;   //! for test

//! 客户端
public class NetworkClient
{
	private static NetworkClient _instance = null;

	public static NetworkClient Instance
	{
		get {
			if (null == _instance) {
				_instance = new NetworkClient ();

			}
			return _instance;
		}

		set {
			Debug.LogError ("Should not assign to Instance");
			_instance = value;
		}
	}

	private OW.IGameInterfacePrx gameInterfacePrx;

	//! 初始化ICE配置
	public void Init()
	{

		Debug.Log("NetWorkClient.init");

		Ice.Communicator communicator = null;

		try
		{
			Ice.InitializationData initData = new Ice.InitializationData();
			initData.properties = Ice.Util.createProperties();
			communicator = Ice.Util.initialize(initData);


			communicator.getProperties().setProperty("Discover.Proxy", "discover:udp -h 224.0.0.5 -p 10000"); //! 
			communicator.getProperties().setProperty("LookupHost.Endpoints", "tcp");                          //! 

			communicator.getProperties().setProperty("Ice.Warn.Connections", "1");


			//! 适配器
			Ice.ObjectAdapter adapter = communicator.createObjectAdapter("LookupHost");

			//			DiscoverReplyI replyI  = new DiscoverReplyI();
			//			DiscoverReplyPrx reply = DiscoverReplyPrxHelper.uncheckedCast(adapter.addWithUUID(replyI));

			//! 启动适配器
			adapter.activate();

			DiscoverPrx discover = DiscoverPrxHelper.uncheckedCast(communicator.propertyToProxy("Discover.Proxy").ice_datagram());

			//			discover.begin_LookupHost().whenCompleted(
			//				(int ret, OW.GameHostInfo info, OW.IGameInterfacePrx gameInterface) => 
			//				{
			//					Debug.Log("discover ret:" + ret +  " host:" + info.ToString());
			//					this.gameInterfacePrx = gameInterface;
			//				},
			//				(Ice.Exception ex) =>
			//				{
			//					Debug.Log("discover exception:" + ex.ToString());
			//				}
			//			);

			GameHostInfo info;
			IGameInterfacePrx gameInterfacePrx;
			discover.LookupHost(out info, out gameInterfacePrx);


			//! discover.lookup(reply);      //! interface

			//! Ice.ObjectPrx obj = replyI.waitReply(2000);
			//! 
			//! if ( obj == null )
			//! {
			//! 	Debug.Log("Ice replyI obj is null");
			//! }
			//! HelloPrx hello = HelloPrxHelper.checkedCast(obj);
			//! if ( null == hello )
			//! {
			//! 	Debug.Log("invalid reply");
			//! }
			//! else
			//! {
			//! 	hello.sayHello();         //! interface
			//! }

		}
		catch(System.Exception ex)
		{
			Debug.Log ("ice exception: " + ex.ToString());
		}		
	}

	//! 寻找主机
	public void LookupHost()
	{

	}

}