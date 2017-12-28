using System;
using ProtoBuf;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OcsoOCS1003Q05ComboListArgs : IContractArgs
	{
    protected bool Equals(OcsoOCS1003Q05ComboListArgs other)
    {
        return Equals(_cboItem, other._cboItem);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsoOCS1003Q05ComboListArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_cboItem != null ? _cboItem.GetHashCode() : 0);
    }

    private List<ComboDataSourceInfo> _cboItem = new List<ComboDataSourceInfo>();

		public List<ComboDataSourceInfo> CboItem
		{
			get { return this._cboItem; }
			set { this._cboItem = value; }
		}

		public OcsoOCS1003Q05ComboListArgs() { }

		public OcsoOCS1003Q05ComboListArgs(List<ComboDataSourceInfo> cboItem)
		{
			this._cboItem = cboItem;
		}

		public IExtensible GetRequestInstance()
		{
			return new IHIS.CloudConnector.Messaging.OcsoOCS1003Q05ComboListRequest();
		}
	}
}