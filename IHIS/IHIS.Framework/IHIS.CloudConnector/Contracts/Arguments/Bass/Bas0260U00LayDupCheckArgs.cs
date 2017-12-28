using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class Bas0260U00LayDupCheckArgs : IContractArgs
    {
        protected bool Equals(Bas0260U00LayDupCheckArgs other)
        {
            return string.Equals(_code, other._code) && string.Equals(_startDate, other._startDate) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Bas0260U00LayDupCheckArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_code != null ? _code.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _code;
        private String _startDate;
        private String _hospCode;

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
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

        public Bas0260U00LayDupCheckArgs() { }

        public Bas0260U00LayDupCheckArgs(String code, String startDate, String hospCode)
        {
            this._code = code;
            this._startDate = startDate;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Bas0260U00LayDupCheckRequest();
        }
    }
}