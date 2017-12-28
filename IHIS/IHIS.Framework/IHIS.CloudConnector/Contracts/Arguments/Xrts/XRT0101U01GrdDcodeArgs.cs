using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT0101U01GrdDcodeArgs : IContractArgs
    {
    protected bool Equals(XRT0101U01GrdDcodeArgs other)
    {
        return string.Equals(_codeType, other._codeType) && string.Equals(_code, other._code) && string.Equals(_codeName, other._codeName);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0101U01GrdDcodeArgs) obj);
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

        public XRT0101U01GrdDcodeArgs() { }

        public XRT0101U01GrdDcodeArgs(String codeType, String code, String codeName)
        {
            this._codeType = codeType;
            this._code = code;
            this._codeName = codeName;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT0101U01GrdDcodeRequest();
        }
    }
}