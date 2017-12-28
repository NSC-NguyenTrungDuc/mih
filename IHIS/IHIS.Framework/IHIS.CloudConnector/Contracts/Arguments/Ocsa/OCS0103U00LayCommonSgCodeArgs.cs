using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U00LayCommonSgCodeArgs : IContractArgs
    {
    protected bool Equals(OCS0103U00LayCommonSgCodeArgs other)
    {
        return string.Equals(_sgCode, other._sgCode) && string.Equals(_startDate, other._startDate) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U00LayCommonSgCodeArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_sgCode != null ? _sgCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _sgCode;
        private String _startDate;
        private String _hospCode;

        public String SgCode
        {
            get { return this._sgCode; }
            set { this._sgCode = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0103U00LayCommonSgCodeArgs() { }

        public OCS0103U00LayCommonSgCodeArgs(String sgCode, String startDate, String hospCode)
        {
            this._sgCode = sgCode;
            this._startDate = startDate;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U00LayCommonSgCodeRequest();
        }
    }
}