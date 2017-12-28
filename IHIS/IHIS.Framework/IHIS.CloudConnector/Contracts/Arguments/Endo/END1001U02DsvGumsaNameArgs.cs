using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Endo
{
    [Serializable]
    public class END1001U02DsvGumsaNameArgs : IContractArgs
    {
        protected bool Equals(END1001U02DsvGumsaNameArgs other)
        {
            return string.Equals(_code, other._code) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((END1001U02DsvGumsaNameArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_code != null ? _code.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            }
        }

        private String _code;
        private String _hospCode;

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public END1001U02DsvGumsaNameArgs() { }

        public END1001U02DsvGumsaNameArgs(String code, String hospCode)
        {
            this._code = code;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.END1001U02DsvGumsaNameRequest();
        }
    }
}