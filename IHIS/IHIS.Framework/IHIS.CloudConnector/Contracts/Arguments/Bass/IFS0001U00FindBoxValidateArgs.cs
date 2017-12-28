using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0001U00FindBoxValidateArgs : IContractArgs
    {
        protected bool Equals(IFS0001U00FindBoxValidateArgs other)
        {
            return string.Equals(_codeType, other._codeType) && string.Equals(_codeName, other._codeName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0001U00FindBoxValidateArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_codeType != null ? _codeType.GetHashCode() : 0)*397) ^ (_codeName != null ? _codeName.GetHashCode() : 0);
            }
        }

        private String _codeType;
        private String _codeName;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public IFS0001U00FindBoxValidateArgs() { }

        public IFS0001U00FindBoxValidateArgs(String codeType, String codeName)
        {
            this._codeType = codeType;
            this._codeName = codeName;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0001U00FindBoxValidateRequest();
        }
    }
}