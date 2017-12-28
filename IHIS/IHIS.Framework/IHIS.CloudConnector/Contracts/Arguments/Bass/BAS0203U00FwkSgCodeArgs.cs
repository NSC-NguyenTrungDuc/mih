using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0203U00FwkSgCodeArgs : IContractArgs
    {
        protected bool Equals(BAS0203U00FwkSgCodeArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_find1, other._find1) && string.Equals(_jyDate, other._jyDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0203U00FwkSgCodeArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jyDate != null ? _jyDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
        private String _find1;
        private String _jyDate;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public String JyDate
        {
            get { return this._jyDate; }
            set { this._jyDate = value; }
        }

        public BAS0203U00FwkSgCodeArgs() { }

        public BAS0203U00FwkSgCodeArgs(String hospCode, String find1, String jyDate)
        {
            this._hospCode = hospCode;
            this._find1 = find1;
            this._jyDate = jyDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0203U00FwkSgCodeRequest();
        }
    }
}