using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0110U00FwkCommonArgs : IContractArgs
    {
        protected bool Equals(BAS0110U00FwkCommonArgs other)
        {
            return string.Equals(_find1, other._find1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0110U00FwkCommonArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_find1 != null ? _find1.GetHashCode() : 0);
        }

        private String _find1;

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public BAS0110U00FwkCommonArgs() { }

        public BAS0110U00FwkCommonArgs(String find1)
        {
            this._find1 = find1;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0110U00FwkCommonRequest();
        }
    }
}