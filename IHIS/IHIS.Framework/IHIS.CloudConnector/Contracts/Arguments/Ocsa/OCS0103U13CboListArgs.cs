using System;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using ProtoBuf;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    [Serializable]
	public class OCS0103U13CboListArgs : IContractArgs
	{
        protected bool Equals(OCS0103U13CboListArgs other)
        {
            return Equals(this.GetHashCode(), other.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OCS0103U13CboListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                if (_comboItemListInfo == null) return hashCode;
                foreach (ComboDataSourceInfo item in _comboItemListInfo)
                {
                    hashCode = (hashCode * 397) ^ (item != null ? item.GetHashCode() : 0);
                }
                return hashCode;
            }
        }

        private List<ComboDataSourceInfo> _comboItemListInfo = new List<ComboDataSourceInfo>();

		public List<ComboDataSourceInfo> ComboItemListInfo
		{
			get { return this._comboItemListInfo; }
			set { this._comboItemListInfo = value; }
		}

		public OCS0103U13CboListArgs() { }

		public OCS0103U13CboListArgs(List<ComboDataSourceInfo> comboItemListInfo)
		{
			this._comboItemListInfo = comboItemListInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new IHIS.CloudConnector.Messaging.OCS0103U13CboListRequest();
		}
	}
}