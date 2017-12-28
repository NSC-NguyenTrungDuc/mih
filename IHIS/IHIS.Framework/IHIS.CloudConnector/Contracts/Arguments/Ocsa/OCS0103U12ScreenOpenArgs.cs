using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using ComboDataSourceInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.ComboDataSourceInfo;
using OcsOrderBizGetUserOptionInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.OcsOrderBizGetUserOptionInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U12ScreenOpenArgs : IContractArgs
	{
    protected bool Equals(OCS0103U12ScreenOpenArgs other)
    {
        return Equals(_getUserOption, other._getUserOption) && Equals(_comboInfo, other._comboInfo) && string.Equals(_bunho, other._bunho) && string.Equals(_pkinp1001, other._pkinp1001) && string.Equals(_inputTab, other._inputTab);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U12ScreenOpenArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_getUserOption != null ? _getUserOption.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_comboInfo != null ? _comboInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkinp1001 != null ? _pkinp1001.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            return hashCode;
        }
    }

    private OcsOrderBizGetUserOptionInfo _getUserOption;
		private List<ComboDataSourceInfo> _comboInfo = new List<ComboDataSourceInfo>();
		private String _bunho;
		private String _pkinp1001;
		private String _inputTab;

		public OcsOrderBizGetUserOptionInfo GetUserOption
		{
			get { return this._getUserOption; }
			set { this._getUserOption = value; }
		}

		public List<ComboDataSourceInfo> ComboInfo
		{
			get { return this._comboInfo; }
			set { this._comboInfo = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Pkinp1001
		{
			get { return this._pkinp1001; }
			set { this._pkinp1001 = value; }
		}

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public OCS0103U12ScreenOpenArgs() { }

		public OCS0103U12ScreenOpenArgs(OcsOrderBizGetUserOptionInfo getUserOption, List<ComboDataSourceInfo> comboInfo, String bunho, String pkinp1001, String inputTab)
		{
			this._getUserOption = getUserOption;
			this._comboInfo = comboInfo;
			this._bunho = bunho;
			this._pkinp1001 = pkinp1001;
			this._inputTab = inputTab;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U12ScreenOpenRequest();
		}
	}
}