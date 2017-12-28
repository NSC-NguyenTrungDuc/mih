using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0001U00FindBoxInitArgs : IContractArgs
    {
        protected bool Equals(IFS0001U00FindBoxInitArgs other)
        {
            return string.Equals(_code, other._code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0001U00FindBoxInitArgs) obj);
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

        public IFS0001U00FindBoxInitArgs() { }

        public IFS0001U00FindBoxInitArgs(String code)
        {
            this._code = code;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0001U00FindBoxInitRequest();
        }
    }
}