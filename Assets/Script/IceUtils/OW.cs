// **********************************************************************
//
// Copyright (c) 2003-2016 ZeroC, Inc. All rights reserved.
//
// This copy of Ice is licensed to you under the terms described in the
// ICE_LICENSE file included in this distribution.
//
// **********************************************************************
//
// Ice version 3.6.2
//
// <auto-generated>
//
// Generated from file `OW.ice'
//
// Warning: do not edit this file.
//
// </auto-generated>
//


using _System = global::System;
using _Microsoft = global::Microsoft;

#pragma warning disable 1591

namespace IceCompactId
{
}

namespace OW
{
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1715")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1722")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724")]
#if !SILVERLIGHT
    [_System.Serializable]
#endif
    public partial class GameHostInfo : _System.ICloneable
    {
        #region Slice data members

        [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
        public string hostName;

        [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
        public int playerMaxCount;

        #endregion

        #region Constructors

        [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
        public GameHostInfo()
        {
            hostName = "";
        }

        [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
        public GameHostInfo(string hostName, int playerMaxCount)
        {
            this.hostName = hostName;
            this.playerMaxCount = playerMaxCount;
        }

        #endregion

        #region ICloneable members

        [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
        public object Clone()
        {
            return MemberwiseClone();
        }

        #endregion

        #region Object members

        [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
        public override int GetHashCode()
        {
            int h__ = 5381;
            IceInternal.HashUtil.hashAdd(ref h__, "::OW::GameHostInfo");
            IceInternal.HashUtil.hashAdd(ref h__, hostName);
            IceInternal.HashUtil.hashAdd(ref h__, playerMaxCount);
            return h__;
        }

        [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
        public override bool Equals(object other__)
        {
            if(object.ReferenceEquals(this, other__))
            {
                return true;
            }
            if(other__ == null)
            {
                return false;
            }
            if(GetType() != other__.GetType())
            {
                return false;
            }
            GameHostInfo o__ = (GameHostInfo)other__;
            if(hostName == null)
            {
                if(o__.hostName != null)
                {
                    return false;
                }
            }
            else
            {
                if(!hostName.Equals(o__.hostName))
                {
                    return false;
                }
            }
            if(!playerMaxCount.Equals(o__.playerMaxCount))
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Comparison members

        [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
        public static bool operator==(GameHostInfo lhs__, GameHostInfo rhs__)
        {
            return Equals(lhs__, rhs__);
        }

        [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
        public static bool operator!=(GameHostInfo lhs__, GameHostInfo rhs__)
        {
            return !Equals(lhs__, rhs__);
        }

        #endregion

        #region Marshalling support

        [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
        public void write__(IceInternal.BasicStream os__)
        {
            os__.writeString(hostName);
            os__.writeInt(playerMaxCount);
        }

        [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
        public void read__(IceInternal.BasicStream is__)
        {
            hostName = is__.readString();
            playerMaxCount = is__.readInt();
        }
        [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
        public static void write__(IceInternal.BasicStream os__, GameHostInfo v__)
        {
            if(v__ == null)
            {
                nullMarshalValue__.write__(os__);
            }
            else
            {
                v__.write__(os__);
            }
        }

        [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
        public static GameHostInfo read__(IceInternal.BasicStream is__, GameHostInfo v__)
        {
            if(v__ == null)
            {
                v__ = new GameHostInfo();
            }
            v__.read__(is__);
            return v__;
        }
        
        private static readonly GameHostInfo nullMarshalValue__ = new GameHostInfo();

        #endregion
    }

    [_System.Runtime.InteropServices.ComVisible(false)]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1715")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1722")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724")]
    public partial interface IGameInterface : Ice.Object, IGameInterfaceOperations_, IGameInterfaceOperationsNC_
    {
    }

    [_System.Runtime.InteropServices.ComVisible(false)]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1715")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1722")]
    [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724")]
    public partial interface Discover : Ice.Object, DiscoverOperations_, DiscoverOperationsNC_
    {
    }
}

namespace OW
{
    [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
    public delegate void Callback_IGameInterface_qryGameInfo(int ret__, OW.GameHostInfo gameInfo);

    [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
    public delegate void Callback_Discover_LookupHost(int ret__, OW.GameHostInfo info, OW.IGameInterfacePrx gameInterface);
}

namespace OW
{
    [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
    public interface IGameInterfacePrx : Ice.ObjectPrx
    {
        int qryGameInfo(out OW.GameHostInfo gameInfo);

        int qryGameInfo(out OW.GameHostInfo gameInfo, _System.Collections.Generic.Dictionary<string, string> ctx__);

        Ice.AsyncResult<OW.Callback_IGameInterface_qryGameInfo> begin_qryGameInfo();

        Ice.AsyncResult<OW.Callback_IGameInterface_qryGameInfo> begin_qryGameInfo(_System.Collections.Generic.Dictionary<string, string> ctx__);

        Ice.AsyncResult begin_qryGameInfo(Ice.AsyncCallback cb__, object cookie__);

        Ice.AsyncResult begin_qryGameInfo(_System.Collections.Generic.Dictionary<string, string> ctx__, Ice.AsyncCallback cb__, object cookie__);

        int end_qryGameInfo(out OW.GameHostInfo gameInfo, Ice.AsyncResult r__);
    }

    [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
    public interface DiscoverPrx : Ice.ObjectPrx
    {
        int LookupHost(out OW.GameHostInfo info, out OW.IGameInterfacePrx gameInterface);

        int LookupHost(out OW.GameHostInfo info, out OW.IGameInterfacePrx gameInterface, _System.Collections.Generic.Dictionary<string, string> ctx__);

        Ice.AsyncResult<OW.Callback_Discover_LookupHost> begin_LookupHost();

        Ice.AsyncResult<OW.Callback_Discover_LookupHost> begin_LookupHost(_System.Collections.Generic.Dictionary<string, string> ctx__);

        Ice.AsyncResult begin_LookupHost(Ice.AsyncCallback cb__, object cookie__);

        Ice.AsyncResult begin_LookupHost(_System.Collections.Generic.Dictionary<string, string> ctx__, Ice.AsyncCallback cb__, object cookie__);

        int end_LookupHost(out OW.GameHostInfo info, out OW.IGameInterfacePrx gameInterface, Ice.AsyncResult r__);
    }
}

namespace OW
{
    [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
    public interface IGameInterfaceOperations_
    {
        void qryGameInfo_async(OW.AMD_IGameInterface_qryGameInfo cb__, Ice.Current current__);
    }

    [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
    public interface IGameInterfaceOperationsNC_
    {
        void qryGameInfo_async(OW.AMD_IGameInterface_qryGameInfo cb__);
    }

    [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
    public interface DiscoverOperations_
    {
        void LookupHost_async(OW.AMD_Discover_LookupHost cb__, Ice.Current current__);
    }

    [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
    public interface DiscoverOperationsNC_
    {
        void LookupHost_async(OW.AMD_Discover_LookupHost cb__);
    }
}

namespace OW
{
    [_System.Runtime.InteropServices.ComVisible(false)]
    [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
    public sealed class IGameInterfacePrxHelper : Ice.ObjectPrxHelperBase, IGameInterfacePrx
    {
        #region Synchronous operations

        public int qryGameInfo(out OW.GameHostInfo gameInfo)
        {
            return this.qryGameInfo(out gameInfo, null, false);
        }

        public int qryGameInfo(out OW.GameHostInfo gameInfo, _System.Collections.Generic.Dictionary<string, string> ctx__)
        {
            return this.qryGameInfo(out gameInfo, ctx__, true);
        }

        private int qryGameInfo(out OW.GameHostInfo gameInfo, _System.Collections.Generic.Dictionary<string, string> context__, bool explicitCtx__)
        {
            checkTwowayOnly__(__qryGameInfo_name);
            return end_qryGameInfo(out gameInfo, begin_qryGameInfo(context__, explicitCtx__, true, null, null));
        }

        #endregion

        #region Asynchronous operations

        public Ice.AsyncResult<OW.Callback_IGameInterface_qryGameInfo> begin_qryGameInfo()
        {
            return begin_qryGameInfo(null, false, false, null, null);
        }

        public Ice.AsyncResult<OW.Callback_IGameInterface_qryGameInfo> begin_qryGameInfo(_System.Collections.Generic.Dictionary<string, string> ctx__)
        {
            return begin_qryGameInfo(ctx__, true, false, null, null);
        }

        public Ice.AsyncResult begin_qryGameInfo(Ice.AsyncCallback cb__, object cookie__)
        {
            return begin_qryGameInfo(null, false, false, cb__, cookie__);
        }

        public Ice.AsyncResult begin_qryGameInfo(_System.Collections.Generic.Dictionary<string, string> ctx__, Ice.AsyncCallback cb__, object cookie__)
        {
            return begin_qryGameInfo(ctx__, true, false, cb__, cookie__);
        }

        private const string __qryGameInfo_name = "qryGameInfo";

        public int end_qryGameInfo(out OW.GameHostInfo gameInfo, Ice.AsyncResult r__)
        {
            IceInternal.OutgoingAsync outAsync__ = IceInternal.OutgoingAsync.check(r__, this, __qryGameInfo_name);
            try
            {
                if(!outAsync__.wait())
                {
                    try
                    {
                        outAsync__.throwUserException();
                    }
                    catch(Ice.UserException ex__)
                    {
                        throw new Ice.UnknownUserException(ex__.ice_name(), ex__);
                    }
                }
                int ret__;
                IceInternal.BasicStream is__ = outAsync__.startReadParams();
                gameInfo = null;
                gameInfo = OW.GameHostInfo.read__(is__, gameInfo);
                ret__ = is__.readInt();
                outAsync__.endReadParams();
                return ret__;
            }
            finally
            {
                outAsync__.cacheMessageBuffers();
            }
        }

        private Ice.AsyncResult<OW.Callback_IGameInterface_qryGameInfo> begin_qryGameInfo(_System.Collections.Generic.Dictionary<string, string> ctx__, bool explicitContext__, bool synchronous__, Ice.AsyncCallback cb__, object cookie__)
        {
            checkAsyncTwowayOnly__(__qryGameInfo_name);
            IceInternal.TwowayOutgoingAsync<OW.Callback_IGameInterface_qryGameInfo> result__ =  getTwowayOutgoingAsync<OW.Callback_IGameInterface_qryGameInfo>(__qryGameInfo_name, qryGameInfo_completed__, cookie__);
            if(cb__ != null)
            {
                result__.whenCompletedWithAsyncCallback(cb__);
            }
            try
            {
                result__.prepare(__qryGameInfo_name, Ice.OperationMode.Normal, ctx__, explicitContext__, synchronous__);
                result__.writeEmptyParams();
                result__.invoke();
            }
            catch(Ice.Exception ex__)
            {
                result__.abort(ex__);
            }
            return result__;
        }

        private void qryGameInfo_completed__(Ice.AsyncResult r__, OW.Callback_IGameInterface_qryGameInfo cb__, Ice.ExceptionCallback excb__)
        {
            OW.GameHostInfo gameInfo;
            int ret__;
            try
            {
                ret__ = end_qryGameInfo(out gameInfo, r__);
            }
            catch(Ice.Exception ex__)
            {
                if(excb__ != null)
                {
                    excb__(ex__);
                }
                return;
            }
            if(cb__ != null)
            {
                cb__(ret__, gameInfo);
            }
        }

        #endregion

        #region Checked and unchecked cast operations

        public static IGameInterfacePrx checkedCast(Ice.ObjectPrx b)
        {
            if(b == null)
            {
                return null;
            }
            IGameInterfacePrx r = b as IGameInterfacePrx;
            if((r == null) && b.ice_isA(ice_staticId()))
            {
                IGameInterfacePrxHelper h = new IGameInterfacePrxHelper();
                h.copyFrom__(b);
                r = h;
            }
            return r;
        }

        public static IGameInterfacePrx checkedCast(Ice.ObjectPrx b, _System.Collections.Generic.Dictionary<string, string> ctx)
        {
            if(b == null)
            {
                return null;
            }
            IGameInterfacePrx r = b as IGameInterfacePrx;
            if((r == null) && b.ice_isA(ice_staticId(), ctx))
            {
                IGameInterfacePrxHelper h = new IGameInterfacePrxHelper();
                h.copyFrom__(b);
                r = h;
            }
            return r;
        }

        public static IGameInterfacePrx checkedCast(Ice.ObjectPrx b, string f)
        {
            if(b == null)
            {
                return null;
            }
            Ice.ObjectPrx bb = b.ice_facet(f);
            try
            {
                if(bb.ice_isA(ice_staticId()))
                {
                    IGameInterfacePrxHelper h = new IGameInterfacePrxHelper();
                    h.copyFrom__(bb);
                    return h;
                }
            }
            catch(Ice.FacetNotExistException)
            {
            }
            return null;
        }

        public static IGameInterfacePrx checkedCast(Ice.ObjectPrx b, string f, _System.Collections.Generic.Dictionary<string, string> ctx)
        {
            if(b == null)
            {
                return null;
            }
            Ice.ObjectPrx bb = b.ice_facet(f);
            try
            {
                if(bb.ice_isA(ice_staticId(), ctx))
                {
                    IGameInterfacePrxHelper h = new IGameInterfacePrxHelper();
                    h.copyFrom__(bb);
                    return h;
                }
            }
            catch(Ice.FacetNotExistException)
            {
            }
            return null;
        }

        public static IGameInterfacePrx uncheckedCast(Ice.ObjectPrx b)
        {
            if(b == null)
            {
                return null;
            }
            IGameInterfacePrx r = b as IGameInterfacePrx;
            if(r == null)
            {
                IGameInterfacePrxHelper h = new IGameInterfacePrxHelper();
                h.copyFrom__(b);
                r = h;
            }
            return r;
        }

        public static IGameInterfacePrx uncheckedCast(Ice.ObjectPrx b, string f)
        {
            if(b == null)
            {
                return null;
            }
            Ice.ObjectPrx bb = b.ice_facet(f);
            IGameInterfacePrxHelper h = new IGameInterfacePrxHelper();
            h.copyFrom__(bb);
            return h;
        }

        public static readonly string[] ids__ =
        {
            "::Ice::Object",
            "::OW::IGameInterface"
        };

        public static string ice_staticId()
        {
            return ids__[1];
        }

        #endregion

        #region Marshaling support

        public static void write__(IceInternal.BasicStream os__, IGameInterfacePrx v__)
        {
            os__.writeProxy(v__);
        }

        public static IGameInterfacePrx read__(IceInternal.BasicStream is__)
        {
            Ice.ObjectPrx proxy = is__.readProxy();
            if(proxy != null)
            {
                IGameInterfacePrxHelper result = new IGameInterfacePrxHelper();
                result.copyFrom__(proxy);
                return result;
            }
            return null;
        }

        #endregion
    }

    [_System.Runtime.InteropServices.ComVisible(false)]
    [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
    public sealed class DiscoverPrxHelper : Ice.ObjectPrxHelperBase, DiscoverPrx
    {
        #region Synchronous operations

        public int LookupHost(out OW.GameHostInfo info, out OW.IGameInterfacePrx gameInterface)
        {
            return this.LookupHost(out info, out gameInterface, null, false);
        }

        public int LookupHost(out OW.GameHostInfo info, out OW.IGameInterfacePrx gameInterface, _System.Collections.Generic.Dictionary<string, string> ctx__)
        {
            return this.LookupHost(out info, out gameInterface, ctx__, true);
        }

        private int LookupHost(out OW.GameHostInfo info, out OW.IGameInterfacePrx gameInterface, _System.Collections.Generic.Dictionary<string, string> context__, bool explicitCtx__)
        {
            checkTwowayOnly__(__LookupHost_name);
            return end_LookupHost(out info, out gameInterface, begin_LookupHost(context__, explicitCtx__, true, null, null));
        }

        #endregion

        #region Asynchronous operations

        public Ice.AsyncResult<OW.Callback_Discover_LookupHost> begin_LookupHost()
        {
            return begin_LookupHost(null, false, false, null, null);
        }

        public Ice.AsyncResult<OW.Callback_Discover_LookupHost> begin_LookupHost(_System.Collections.Generic.Dictionary<string, string> ctx__)
        {
            return begin_LookupHost(ctx__, true, false, null, null);
        }

        public Ice.AsyncResult begin_LookupHost(Ice.AsyncCallback cb__, object cookie__)
        {
            return begin_LookupHost(null, false, false, cb__, cookie__);
        }

        public Ice.AsyncResult begin_LookupHost(_System.Collections.Generic.Dictionary<string, string> ctx__, Ice.AsyncCallback cb__, object cookie__)
        {
            return begin_LookupHost(ctx__, true, false, cb__, cookie__);
        }

        private const string __LookupHost_name = "LookupHost";

        public int end_LookupHost(out OW.GameHostInfo info, out OW.IGameInterfacePrx gameInterface, Ice.AsyncResult r__)
        {
            IceInternal.OutgoingAsync outAsync__ = IceInternal.OutgoingAsync.check(r__, this, __LookupHost_name);
            try
            {
                if(!outAsync__.wait())
                {
                    try
                    {
                        outAsync__.throwUserException();
                    }
                    catch(Ice.UserException ex__)
                    {
                        throw new Ice.UnknownUserException(ex__.ice_name(), ex__);
                    }
                }
                int ret__;
                IceInternal.BasicStream is__ = outAsync__.startReadParams();
                info = null;
                info = OW.GameHostInfo.read__(is__, info);
                gameInterface = OW.IGameInterfacePrxHelper.read__(is__);
                ret__ = is__.readInt();
                outAsync__.endReadParams();
                return ret__;
            }
            finally
            {
                outAsync__.cacheMessageBuffers();
            }
        }

        private Ice.AsyncResult<OW.Callback_Discover_LookupHost> begin_LookupHost(_System.Collections.Generic.Dictionary<string, string> ctx__, bool explicitContext__, bool synchronous__, Ice.AsyncCallback cb__, object cookie__)
        {
            checkAsyncTwowayOnly__(__LookupHost_name);
            IceInternal.TwowayOutgoingAsync<OW.Callback_Discover_LookupHost> result__ =  getTwowayOutgoingAsync<OW.Callback_Discover_LookupHost>(__LookupHost_name, LookupHost_completed__, cookie__);
            if(cb__ != null)
            {
                result__.whenCompletedWithAsyncCallback(cb__);
            }
            try
            {
                result__.prepare(__LookupHost_name, Ice.OperationMode.Normal, ctx__, explicitContext__, synchronous__);
                result__.writeEmptyParams();
                result__.invoke();
            }
            catch(Ice.Exception ex__)
            {
                result__.abort(ex__);
            }
            return result__;
        }

        private void LookupHost_completed__(Ice.AsyncResult r__, OW.Callback_Discover_LookupHost cb__, Ice.ExceptionCallback excb__)
        {
            OW.GameHostInfo info;
            OW.IGameInterfacePrx gameInterface;
            int ret__;
            try
            {
                ret__ = end_LookupHost(out info, out gameInterface, r__);
            }
            catch(Ice.Exception ex__)
            {
                if(excb__ != null)
                {
                    excb__(ex__);
                }
                return;
            }
            if(cb__ != null)
            {
                cb__(ret__, info, gameInterface);
            }
        }

        #endregion

        #region Checked and unchecked cast operations

        public static DiscoverPrx checkedCast(Ice.ObjectPrx b)
        {
            if(b == null)
            {
                return null;
            }
            DiscoverPrx r = b as DiscoverPrx;
            if((r == null) && b.ice_isA(ice_staticId()))
            {
                DiscoverPrxHelper h = new DiscoverPrxHelper();
                h.copyFrom__(b);
                r = h;
            }
            return r;
        }

        public static DiscoverPrx checkedCast(Ice.ObjectPrx b, _System.Collections.Generic.Dictionary<string, string> ctx)
        {
            if(b == null)
            {
                return null;
            }
            DiscoverPrx r = b as DiscoverPrx;
            if((r == null) && b.ice_isA(ice_staticId(), ctx))
            {
                DiscoverPrxHelper h = new DiscoverPrxHelper();
                h.copyFrom__(b);
                r = h;
            }
            return r;
        }

        public static DiscoverPrx checkedCast(Ice.ObjectPrx b, string f)
        {
            if(b == null)
            {
                return null;
            }
            Ice.ObjectPrx bb = b.ice_facet(f);
            try
            {
                if(bb.ice_isA(ice_staticId()))
                {
                    DiscoverPrxHelper h = new DiscoverPrxHelper();
                    h.copyFrom__(bb);
                    return h;
                }
            }
            catch(Ice.FacetNotExistException)
            {
            }
            return null;
        }

        public static DiscoverPrx checkedCast(Ice.ObjectPrx b, string f, _System.Collections.Generic.Dictionary<string, string> ctx)
        {
            if(b == null)
            {
                return null;
            }
            Ice.ObjectPrx bb = b.ice_facet(f);
            try
            {
                if(bb.ice_isA(ice_staticId(), ctx))
                {
                    DiscoverPrxHelper h = new DiscoverPrxHelper();
                    h.copyFrom__(bb);
                    return h;
                }
            }
            catch(Ice.FacetNotExistException)
            {
            }
            return null;
        }

        public static DiscoverPrx uncheckedCast(Ice.ObjectPrx b)
        {
            if(b == null)
            {
                return null;
            }
            DiscoverPrx r = b as DiscoverPrx;
            if(r == null)
            {
                DiscoverPrxHelper h = new DiscoverPrxHelper();
                h.copyFrom__(b);
                r = h;
            }
            return r;
        }

        public static DiscoverPrx uncheckedCast(Ice.ObjectPrx b, string f)
        {
            if(b == null)
            {
                return null;
            }
            Ice.ObjectPrx bb = b.ice_facet(f);
            DiscoverPrxHelper h = new DiscoverPrxHelper();
            h.copyFrom__(bb);
            return h;
        }

        public static readonly string[] ids__ =
        {
            "::Ice::Object",
            "::OW::Discover"
        };

        public static string ice_staticId()
        {
            return ids__[1];
        }

        #endregion

        #region Marshaling support

        public static void write__(IceInternal.BasicStream os__, DiscoverPrx v__)
        {
            os__.writeProxy(v__);
        }

        public static DiscoverPrx read__(IceInternal.BasicStream is__)
        {
            Ice.ObjectPrx proxy = is__.readProxy();
            if(proxy != null)
            {
                DiscoverPrxHelper result = new DiscoverPrxHelper();
                result.copyFrom__(proxy);
                return result;
            }
            return null;
        }

        #endregion
    }
}

namespace OW
{
    [_System.Runtime.InteropServices.ComVisible(false)]
    [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
    public abstract class IGameInterfaceDisp_ : Ice.ObjectImpl, IGameInterface
    {
        #region Slice operations

        public void qryGameInfo_async(OW.AMD_IGameInterface_qryGameInfo cb__)
        {
            qryGameInfo_async(cb__, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void qryGameInfo_async(OW.AMD_IGameInterface_qryGameInfo cb__, Ice.Current current__);

        #endregion

        #region Slice type-related members

        public static new readonly string[] ids__ = 
        {
            "::Ice::Object",
            "::OW::IGameInterface"
        };

        public override bool ice_isA(string s)
        {
            return _System.Array.BinarySearch(ids__, s, IceUtilInternal.StringUtil.OrdinalStringComparer) >= 0;
        }

        public override bool ice_isA(string s, Ice.Current current__)
        {
            return _System.Array.BinarySearch(ids__, s, IceUtilInternal.StringUtil.OrdinalStringComparer) >= 0;
        }

        public override string[] ice_ids()
        {
            return ids__;
        }

        public override string[] ice_ids(Ice.Current current__)
        {
            return ids__;
        }

        public override string ice_id()
        {
            return ids__[1];
        }

        public override string ice_id(Ice.Current current__)
        {
            return ids__[1];
        }

        public static new string ice_staticId()
        {
            return ids__[1];
        }

        #endregion

        #region Operation dispatch

        [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
        public static Ice.DispatchStatus qryGameInfo___(IGameInterface obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            Ice.ObjectImpl.checkMode__(Ice.OperationMode.Normal, current__.mode);
            inS__.readEmptyParams();
            AMD_IGameInterface_qryGameInfo cb__ = new _AMD_IGameInterface_qryGameInfo(inS__);
            try
            {
                obj__.qryGameInfo_async(cb__, current__);
            }
            catch(_System.Exception ex__)
            {
                cb__.ice_exception(ex__);
            }
            return Ice.DispatchStatus.DispatchAsync;
        }

        private static string[] all__ =
        {
            "ice_id",
            "ice_ids",
            "ice_isA",
            "ice_ping",
            "qryGameInfo"
        };

        public override Ice.DispatchStatus dispatch__(IceInternal.Incoming inS__, Ice.Current current__)
        {
            int pos = _System.Array.BinarySearch(all__, current__.operation, IceUtilInternal.StringUtil.OrdinalStringComparer);
            if(pos < 0)
            {
                throw new Ice.OperationNotExistException(current__.id, current__.facet, current__.operation);
            }

            switch(pos)
            {
                case 0:
                {
                    return Ice.ObjectImpl.ice_id___(this, inS__, current__);
                }
                case 1:
                {
                    return Ice.ObjectImpl.ice_ids___(this, inS__, current__);
                }
                case 2:
                {
                    return Ice.ObjectImpl.ice_isA___(this, inS__, current__);
                }
                case 3:
                {
                    return Ice.ObjectImpl.ice_ping___(this, inS__, current__);
                }
                case 4:
                {
                    return qryGameInfo___(this, inS__, current__);
                }
            }

            _System.Diagnostics.Debug.Assert(false);
            throw new Ice.OperationNotExistException(current__.id, current__.facet, current__.operation);
        }

        #endregion

        #region Marshaling support

        protected override void writeImpl__(IceInternal.BasicStream os__)
        {
            os__.startWriteSlice(ice_staticId(), -1, true);
            os__.endWriteSlice();
        }

        protected override void readImpl__(IceInternal.BasicStream is__)
        {
            is__.startReadSlice();
            is__.endReadSlice();
        }

        #endregion
    }

    [_System.Runtime.InteropServices.ComVisible(false)]
    [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
    public abstract class DiscoverDisp_ : Ice.ObjectImpl, Discover
    {
        #region Slice operations

        public void LookupHost_async(OW.AMD_Discover_LookupHost cb__)
        {
            LookupHost_async(cb__, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void LookupHost_async(OW.AMD_Discover_LookupHost cb__, Ice.Current current__);

        #endregion

        #region Slice type-related members

        public static new readonly string[] ids__ = 
        {
            "::Ice::Object",
            "::OW::Discover"
        };

        public override bool ice_isA(string s)
        {
            return _System.Array.BinarySearch(ids__, s, IceUtilInternal.StringUtil.OrdinalStringComparer) >= 0;
        }

        public override bool ice_isA(string s, Ice.Current current__)
        {
            return _System.Array.BinarySearch(ids__, s, IceUtilInternal.StringUtil.OrdinalStringComparer) >= 0;
        }

        public override string[] ice_ids()
        {
            return ids__;
        }

        public override string[] ice_ids(Ice.Current current__)
        {
            return ids__;
        }

        public override string ice_id()
        {
            return ids__[1];
        }

        public override string ice_id(Ice.Current current__)
        {
            return ids__[1];
        }

        public static new string ice_staticId()
        {
            return ids__[1];
        }

        #endregion

        #region Operation dispatch

        [_System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
        public static Ice.DispatchStatus LookupHost___(Discover obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            Ice.ObjectImpl.checkMode__(Ice.OperationMode.Normal, current__.mode);
            inS__.readEmptyParams();
            AMD_Discover_LookupHost cb__ = new _AMD_Discover_LookupHost(inS__);
            try
            {
                obj__.LookupHost_async(cb__, current__);
            }
            catch(_System.Exception ex__)
            {
                cb__.ice_exception(ex__);
            }
            return Ice.DispatchStatus.DispatchAsync;
        }

        private static string[] all__ =
        {
            "LookupHost",
            "ice_id",
            "ice_ids",
            "ice_isA",
            "ice_ping"
        };

        public override Ice.DispatchStatus dispatch__(IceInternal.Incoming inS__, Ice.Current current__)
        {
            int pos = _System.Array.BinarySearch(all__, current__.operation, IceUtilInternal.StringUtil.OrdinalStringComparer);
            if(pos < 0)
            {
                throw new Ice.OperationNotExistException(current__.id, current__.facet, current__.operation);
            }

            switch(pos)
            {
                case 0:
                {
                    return LookupHost___(this, inS__, current__);
                }
                case 1:
                {
                    return Ice.ObjectImpl.ice_id___(this, inS__, current__);
                }
                case 2:
                {
                    return Ice.ObjectImpl.ice_ids___(this, inS__, current__);
                }
                case 3:
                {
                    return Ice.ObjectImpl.ice_isA___(this, inS__, current__);
                }
                case 4:
                {
                    return Ice.ObjectImpl.ice_ping___(this, inS__, current__);
                }
            }

            _System.Diagnostics.Debug.Assert(false);
            throw new Ice.OperationNotExistException(current__.id, current__.facet, current__.operation);
        }

        #endregion

        #region Marshaling support

        protected override void writeImpl__(IceInternal.BasicStream os__)
        {
            os__.startWriteSlice(ice_staticId(), -1, true);
            os__.endWriteSlice();
        }

        protected override void readImpl__(IceInternal.BasicStream is__)
        {
            is__.startReadSlice();
            is__.endReadSlice();
        }

        #endregion
    }
}

namespace OW
{
    [_System.Runtime.InteropServices.ComVisible(false)]
    [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
    public interface AMD_IGameInterface_qryGameInfo : Ice.AMDCallback
    {
        void ice_response(int ret__, OW.GameHostInfo gameInfo);
    }

    [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
    class _AMD_IGameInterface_qryGameInfo : IceInternal.IncomingAsync, AMD_IGameInterface_qryGameInfo
    {
        public _AMD_IGameInterface_qryGameInfo(IceInternal.Incoming inc) : base(inc)
        {
        }

        public void ice_response(int ret__, OW.GameHostInfo gameInfo)
        {
            if(validateResponse__(true))
            {
                try
                {
                    IceInternal.BasicStream os__ = startWriteParams__(Ice.FormatType.DefaultFormat);
                    OW.GameHostInfo.write__(os__, gameInfo);
                    os__.writeInt(ret__);
                    endWriteParams__(true);
                }
                catch(Ice.LocalException ex__)
                {
                    exception__(ex__);
                    return;
                }
                response__();
            }
        }
    }

    [_System.Runtime.InteropServices.ComVisible(false)]
    [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
    public interface AMD_Discover_LookupHost : Ice.AMDCallback
    {
        void ice_response(int ret__, OW.GameHostInfo info, OW.IGameInterfacePrx gameInterface);
    }

    [_System.CodeDom.Compiler.GeneratedCodeAttribute("slice2cs", "3.6.2")]
    class _AMD_Discover_LookupHost : IceInternal.IncomingAsync, AMD_Discover_LookupHost
    {
        public _AMD_Discover_LookupHost(IceInternal.Incoming inc) : base(inc)
        {
        }

        public void ice_response(int ret__, OW.GameHostInfo info, OW.IGameInterfacePrx gameInterface)
        {
            if(validateResponse__(true))
            {
                try
                {
                    IceInternal.BasicStream os__ = startWriteParams__(Ice.FormatType.DefaultFormat);
                    OW.GameHostInfo.write__(os__, info);
                    OW.IGameInterfacePrxHelper.write__(os__, gameInterface);
                    os__.writeInt(ret__);
                    endWriteParams__(true);
                }
                catch(Ice.LocalException ex__)
                {
                    exception__(ex__);
                    return;
                }
                response__();
            }
        }
    }
}
