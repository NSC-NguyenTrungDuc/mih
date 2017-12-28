using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class Adm107USaveLayoutArgs : IContractArgs
    {
        protected bool Equals(Adm107USaveLayoutArgs other)
        {
            return string.Equals(_mainUserId, other._mainUserId) && string.Equals(_fbxSysId, other._fbxSysId) && string.Equals(_hospCode, other._hospCode) && Equals(_saveLayoutItem, other._saveLayoutItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Adm107USaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_mainUserId != null ? _mainUserId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fbxSysId != null ? _fbxSysId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_saveLayoutItem != null ? _saveLayoutItem.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _mainUserId;
        private String _fbxSysId;
        private String _hospCode;
        private List<Adm107USaveLayoutInfo> _saveLayoutItem = new List<Adm107USaveLayoutInfo>();

        public String MainUserId
        {
            get { return this._mainUserId; }
            set { this._mainUserId = value; }
        }

        public String FbxSysId
        {
            get { return this._fbxSysId; }
            set { this._fbxSysId = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public List<Adm107USaveLayoutInfo> SaveLayoutItem
        {
            get { return this._saveLayoutItem; }
            set { this._saveLayoutItem = value; }
        }

        public Adm107USaveLayoutArgs() { }

        public Adm107USaveLayoutArgs(String mainUserId, String fbxSysId, String hospCode, List<Adm107USaveLayoutInfo> saveLayoutItem)
        {
            this._mainUserId = mainUserId;
            this._fbxSysId = fbxSysId;
            this._hospCode = hospCode;
            this._saveLayoutItem = saveLayoutItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Adm107USaveLayoutRequest();
        }
    }
}