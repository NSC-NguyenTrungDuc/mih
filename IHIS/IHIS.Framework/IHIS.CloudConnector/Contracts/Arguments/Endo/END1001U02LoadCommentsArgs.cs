using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Endo
{
    [Serializable]
    public class END1001U02LoadCommentsArgs : IContractArgs
    {
        protected bool Equals(END1001U02LoadCommentsArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_bunho, other._bunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((END1001U02LoadCommentsArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_hospCode != null ? _hospCode.GetHashCode() : 0)*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            }
        }

        private String _hospCode;
        private String _bunho;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public END1001U02LoadCommentsArgs() { }

        public END1001U02LoadCommentsArgs(String hospCode, String bunho)
        {
            this._hospCode = hospCode;
            this._bunho = bunho;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.END1001U02LoadCommentsRequest();
        }
    }
}