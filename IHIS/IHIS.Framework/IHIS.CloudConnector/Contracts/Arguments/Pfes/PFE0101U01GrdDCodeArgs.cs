using System;
using IHIS.CloudConnector.Contracts.Models.Pfes;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Pfes
{[Serializable]
    public class PFE0101U01GrdDCodeArgs : IContractArgs
    {
    protected bool Equals(PFE0101U01GrdDCodeArgs other)
    {
        return string.Equals(_codeType, other._codeType) && string.Equals(_code, other._code) && string.Equals(_codeName, other._codeName);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PFE0101U01GrdDCodeArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_codeType != null ? _codeType.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_code != null ? _code.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_codeName != null ? _codeName.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _codeType;
        private String _code;
        private String _codeName;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public PFE0101U01GrdDCodeArgs() { }

        public PFE0101U01GrdDCodeArgs(String codeType, String code, String codeName)
        {
            this._codeType = codeType;
            this._code = code;
            this._codeName = codeName;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PFE0101U01GrdDCodeRequest();
        }
    }
}