using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using LoadOftenUsedTabInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.LoadOftenUsedTabInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    [Serializable]
	public class OCS0103U12MakeSangyongTabArgs : IContractArgs
	{
	    protected bool Equals(OCS0103U12MakeSangyongTabArgs other)
	    {
	        return Equals(_requestInfo, other._requestInfo);
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((OCS0103U12MakeSangyongTabArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return (_requestInfo != null ? _requestInfo.GetHashCode() : 0);
	    }

	    private LoadOftenUsedTabInfo _requestInfo;

		public LoadOftenUsedTabInfo RequestInfo
		{
			get { return this._requestInfo; }
			set { this._requestInfo = value; }
		}

		public OCS0103U12MakeSangyongTabArgs() { }

		public OCS0103U12MakeSangyongTabArgs(LoadOftenUsedTabInfo requestInfo)
		{
			this._requestInfo = requestInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U12MakeSangyongTabRequest();
		}
	}
}