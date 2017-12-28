using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0803U00GetCodeNameArgs : IContractArgs
    {
    protected bool Equals(OCS0803U00GetCodeNameArgs other)
    {
        return string.Equals(_codeMode, other._codeMode) && string.Equals(_code, other._code) && string.Equals(_patStatus, other._patStatus);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0803U00GetCodeNameArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_codeMode != null ? _codeMode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_code != null ? _code.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_patStatus != null ? _patStatus.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _codeMode;
        private String _code;
        private String _patStatus;

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

        public String PatStatus
        {
            get { return this._patStatus; }
            set { this._patStatus = value; }
        }

        public OCS0803U00GetCodeNameArgs() { }

        public OCS0803U00GetCodeNameArgs(String codeMode, String code, String patStatus)
        {
            this._codeMode = codeMode;
            this._code = code;
            this._patStatus = patStatus;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0803U00GetCodeNameRequest();
        }
    }
}