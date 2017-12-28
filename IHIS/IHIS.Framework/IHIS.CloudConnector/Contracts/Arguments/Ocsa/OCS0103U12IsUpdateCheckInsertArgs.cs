using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using OCS0103U12IsUpdateCheckInsertInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.OCS0103U12IsUpdateCheckInsertInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U12IsUpdateCheckInsertArgs : IContractArgs
	{
    protected bool Equals(OCS0103U12IsUpdateCheckInsertArgs other)
    {
        return Equals(_insertInfo, other._insertInfo);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U12IsUpdateCheckInsertArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_insertInfo != null ? _insertInfo.GetHashCode() : 0);
    }

    private List<OCS0103U12IsUpdateCheckInsertInfo> _insertInfo = new List<OCS0103U12IsUpdateCheckInsertInfo>();

		public List<OCS0103U12IsUpdateCheckInsertInfo> InsertInfo
		{
			get { return this._insertInfo; }
			set { this._insertInfo = value; }
		}

		public OCS0103U12IsUpdateCheckInsertArgs() { }

		public OCS0103U12IsUpdateCheckInsertArgs(List<OCS0103U12IsUpdateCheckInsertInfo> insertInfo)
		{
			this._insertInfo = insertInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U12IsUpdateCheckInsertRequest();
		}
	}
}