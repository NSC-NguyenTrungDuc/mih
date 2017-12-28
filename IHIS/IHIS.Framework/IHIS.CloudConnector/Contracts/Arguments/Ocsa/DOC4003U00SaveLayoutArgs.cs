using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class DOC4003U00SaveLayoutArgs : IContractArgs
    {
    protected bool Equals(DOC4003U00SaveLayoutArgs other)
    {
        return string.Equals(_hospCode, other._hospCode) && string.Equals(_userId, other._userId) && Equals(_saveLayoutItem, other._saveLayoutItem);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((DOC4003U00SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_saveLayoutItem != null ? _saveLayoutItem.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _hospCode;
        private String _userId;
        private List<DOC4003U00GrdDOC4003Info> _saveLayoutItem = new List<DOC4003U00GrdDOC4003Info>();

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<DOC4003U00GrdDOC4003Info> SaveLayoutItem
        {
            get { return this._saveLayoutItem; }
            set { this._saveLayoutItem = value; }
        }

        public DOC4003U00SaveLayoutArgs() { }

        public DOC4003U00SaveLayoutArgs(String hospCode, String userId, List<DOC4003U00GrdDOC4003Info> saveLayoutItem)
        {
            this._hospCode = hospCode;
            this._userId = userId;
            this._saveLayoutItem = saveLayoutItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.DOC4003U00SaveLayoutRequest();
        }
    }
}