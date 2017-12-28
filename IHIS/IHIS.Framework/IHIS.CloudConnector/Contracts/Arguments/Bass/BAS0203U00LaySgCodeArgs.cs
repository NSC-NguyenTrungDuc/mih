using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0203U00LaySgCodeArgs : IContractArgs
    {
        protected bool Equals(BAS0203U00LaySgCodeArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_sgYmd, other._sgYmd) && string.Equals(_sgCode, other._sgCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0203U00LaySgCodeArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sgYmd != null ? _sgYmd.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sgCode != null ? _sgCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
        private String _sgYmd;
        private String _sgCode;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String SgYmd
        {
            get { return this._sgYmd; }
            set { this._sgYmd = value; }
        }

        public String SgCode
        {
            get { return this._sgCode; }
            set { this._sgCode = value; }
        }

        public BAS0203U00LaySgCodeArgs() { }

        public BAS0203U00LaySgCodeArgs(String hospCode, String sgYmd, String sgCode)
        {
            this._hospCode = hospCode;
            this._sgYmd = sgYmd;
            this._sgCode = sgCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0203U00LaySgCodeRequest();
        }
    }
}