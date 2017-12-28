using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL0106U00GridColumnChangeArgs : IContractArgs
    {
        protected bool Equals(CPL0106U00GridColumnChangeArgs other)
        {
            return string.Equals(_code, other._code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0106U00GridColumnChangeArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_code != null ? _code.GetHashCode() : 0);
        }

        private String _code;

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public CPL0106U00GridColumnChangeArgs() { }

        public CPL0106U00GridColumnChangeArgs(String code)
        {
            this._code = code;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL0106U00GridColumnChangeRequest();
        }
    }
}