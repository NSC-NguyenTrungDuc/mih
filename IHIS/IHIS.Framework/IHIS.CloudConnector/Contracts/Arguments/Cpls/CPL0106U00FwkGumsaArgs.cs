using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL0106U00FwkGumsaArgs : IContractArgs
    {
        protected bool Equals(CPL0106U00FwkGumsaArgs other)
        {
            return string.Equals(_find1, other._find1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0106U00FwkGumsaArgs) obj);
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

        public CPL0106U00FwkGumsaArgs() { }

        public CPL0106U00FwkGumsaArgs(String find1)
        {
            this._find1 = find1;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL0106U00FwkGumsaRequest();
        }
    }
}