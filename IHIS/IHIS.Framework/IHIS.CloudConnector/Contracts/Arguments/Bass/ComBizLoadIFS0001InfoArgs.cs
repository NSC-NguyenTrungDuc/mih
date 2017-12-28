using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class ComBizLoadIFS0001InfoArgs : IContractArgs
    {
        protected bool Equals(ComBizLoadIFS0001InfoArgs other)
        {
            return string.Equals(_codeType, other._codeType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComBizLoadIFS0001InfoArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_codeType != null ? _codeType.GetHashCode() : 0);
        }

        private String _codeType;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public ComBizLoadIFS0001InfoArgs() { }

        public ComBizLoadIFS0001InfoArgs(String codeType)
        {
            this._codeType = codeType;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ComBizLoadIFS0001InfoRequest();
        }
    }
}