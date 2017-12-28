using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class RES1001U00FbxHospCodeLinkArgs : IContractArgs
    {
        protected bool Equals(RES1001U00FbxHospCodeLinkArgs other)
        {
            return string.Equals(_bunho, other._bunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RES1001U00FbxHospCodeLinkArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_bunho != null ? _bunho.GetHashCode() : 0);
        }

        private String _bunho;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public RES1001U00FbxHospCodeLinkArgs() { }

        public RES1001U00FbxHospCodeLinkArgs(String bunho)
        {
            this._bunho = bunho;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.RES1001U00FbxHospCodeLinkRequest();
        }
    }
}