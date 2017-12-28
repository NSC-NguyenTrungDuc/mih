using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using ComboDataSourceInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.ComboDataSourceInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCSAPPROVEInitScreenArgs : IContractArgs
	{
    protected bool Equals(OCSAPPROVEInitScreenArgs other)
    {
        return Equals(_cboListInfo, other._cboListInfo);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSAPPROVEInitScreenArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_cboListInfo != null ? _cboListInfo.GetHashCode() : 0);
    }

    private List<ComboDataSourceInfo> _cboListInfo = new List<ComboDataSourceInfo>();

		public List<ComboDataSourceInfo> CboListInfo
		{
			get { return this._cboListInfo; }
			set { this._cboListInfo = value; }
		}

		public OCSAPPROVEInitScreenArgs() { }

		public OCSAPPROVEInitScreenArgs(List<ComboDataSourceInfo> cboListInfo)
		{
			this._cboListInfo = cboListInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCSAPPROVEInitScreenRequest();
		}
	}
}