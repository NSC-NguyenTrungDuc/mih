using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0301U00FwkUserArgs : IContractArgs
    {
    protected bool Equals(OCS0301U00FwkUserArgs other)
    {
        return string.Equals(_queryMode, other._queryMode) && string.Equals(_find1, other._find1) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0301U00FwkUserArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_queryMode != null ? _queryMode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _queryMode;
        private String _find1;
        private String _hospCode;

        public String QueryMode
        {
            get { return this._queryMode; }
            set { this._queryMode = value; }
        }

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0301U00FwkUserArgs() { }

        public OCS0301U00FwkUserArgs(String queryMode, String find1, String hospCode)
        {
            this._queryMode = queryMode;
            this._find1 = find1;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0301U00FwkUserRequest();
        }
    }
}