using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0223U00ExecutionArgs : IContractArgs
    {
    protected bool Equals(OCS0223U00ExecutionArgs other)
    {
        return Equals(_info, other._info) && string.Equals(_userId, other._userId) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0223U00ExecutionArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_info != null ? _info.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private List<OCS0223U00GrdOCS0223Info> _info = new List<OCS0223U00GrdOCS0223Info>();
        private String _userId;
        private String _hospCode;

        public List<OCS0223U00GrdOCS0223Info> Info
        {
            get { return this._info; }
            set { this._info = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0223U00ExecutionArgs() { }

        public OCS0223U00ExecutionArgs(List<OCS0223U00GrdOCS0223Info> info, String userId, String hospCode)
        {
            this._info = info;
            this._userId = userId;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0223U00ExecutionRequest();
        }
    }
}