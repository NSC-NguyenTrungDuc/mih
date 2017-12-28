using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM103RegSystemFormSaveLayoutArgs : IContractArgs
    {
        protected bool Equals(ADM103RegSystemFormSaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && Equals(_sysId, other._sysId) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM103RegSystemFormSaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sysId != null ? _sysId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private List<DataStringListItemInfo> _sysId = new List<DataStringListItemInfo>();
        private String _hospCode;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<DataStringListItemInfo> SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public ADM103RegSystemFormSaveLayoutArgs() { }

        public ADM103RegSystemFormSaveLayoutArgs(String userId, List<DataStringListItemInfo> sysId, String hospCode)
        {
            this._userId = userId;
            this._sysId = sysId;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM103RegSystemFormSaveLayoutRequest();
        }
    }
}