using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04SetSinryouryouAutoArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04SetSinryouryouAutoArgs other)
    {
        return string.Equals(_code1, other._code1) && string.Equals(_code2, other._code2) && string.Equals(_codeType, other._codeType);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04SetSinryouryouAutoArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_code1 != null ? _code1.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_code2 != null ? _code2.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _code1;
        private String _code2;
        private String _codeType;

        public String Code1
        {
            get { return this._code1; }
            set { this._code1 = value; }
        }

        public String Code2
        {
            get { return this._code2; }
            set { this._code2 = value; }
        }

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public PHY2001U04SetSinryouryouAutoArgs() { }

        public PHY2001U04SetSinryouryouAutoArgs(String code1, String code2, String codeType)
        {
            this._code1 = code1;
            this._code2 = code2;
            this._codeType = codeType;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04SetSinryouryouAutoRequest();
        }
    }
}