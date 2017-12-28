using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using ADMS2015U01SettingMenuInfo = IHIS.CloudConnector.Contracts.Models.Adma.ADMS2015U01SettingMenuInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADMS2015U01SettingMenuArgs : IContractArgs
	{
        protected bool Equals(ADMS2015U01SettingMenuArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_systemId, other._systemId) && Equals(_menuInfo, other._menuInfo) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADMS2015U01SettingMenuArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_systemId != null ? _systemId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_menuInfo != null ? _menuInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
        private String _systemId;
        private List<ADMS2015U01SettingMenuInfo> _menuInfo = new List<ADMS2015U01SettingMenuInfo>();
        private String _userId;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String SystemId
        {
            get { return this._systemId; }
            set { this._systemId = value; }
        }

        public List<ADMS2015U01SettingMenuInfo> MenuInfo
        {
            get { return this._menuInfo; }
            set { this._menuInfo = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public ADMS2015U01SettingMenuArgs() { }

        public ADMS2015U01SettingMenuArgs(String hospCode, String systemId, List<ADMS2015U01SettingMenuInfo> menuInfo, String userId)
        {
            this._hospCode = hospCode;
            this._systemId = systemId;
            this._menuInfo = menuInfo;
            this._userId = userId;
        }

        public IExtensible GetRequestInstance()
        {
            return new ADMS2015U01SettingMenuRequest();
        }
	}
}