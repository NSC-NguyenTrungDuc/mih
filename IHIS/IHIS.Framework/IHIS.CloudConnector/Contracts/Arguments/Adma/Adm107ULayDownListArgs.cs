using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class Adm107ULayDownListArgs : IContractArgs
    {
        protected bool Equals(Adm107ULayDownListArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_sysId, other._sysId) && string.Equals(_upprMenu, other._upprMenu) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Adm107ULayDownListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sysId != null ? _sysId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_upprMenu != null ? _upprMenu.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private String _sysId;
        private String _upprMenu;
        private String _hospCode;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String UpprMenu
        {
            get { return this._upprMenu; }
            set { this._upprMenu = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public Adm107ULayDownListArgs() { }

        public Adm107ULayDownListArgs(String userId, String sysId, String upprMenu, String hospCode)
        {
            this._userId = userId;
            this._sysId = sysId;
            this._upprMenu = upprMenu;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Adm107ULayDownListRequest();
        }
    }
}