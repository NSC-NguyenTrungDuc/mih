using System;
using IHIS.CloudConnector.Contracts.Models.Chts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    [Serializable]
    public class CHT0110U00GetCodeNameArgs : IContractArgs
    {
        protected bool Equals(CHT0110U00GetCodeNameArgs other)
        {
            return string.Equals(_codeMode, other._codeMode) && string.Equals(_code, other._code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CHT0110U00GetCodeNameArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_codeMode != null ? _codeMode.GetHashCode() : 0)*397) ^ (_code != null ? _code.GetHashCode() : 0);
            }
        }

        private String _codeMode;
        private String _code;

        public String CodeMode
        {
            get { return this._codeMode; }
            set { this._codeMode = value; }
        }

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public CHT0110U00GetCodeNameArgs() { }

        public CHT0110U00GetCodeNameArgs(String codeMode, String code)
        {
            this._codeMode = codeMode;
            this._code = code;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CHT0110U00GetCodeNameRequest();
        }
    }
}