using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0001U00FbxDodobuHyeunFindClickArgs : IContractArgs
    {
        protected bool Equals(BAS0001U00FbxDodobuHyeunFindClickArgs other)
        {
            return string.Equals(_codeType, other._codeType) && string.Equals(_find1, other._find1) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0001U00FbxDodobuHyeunFindClickArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_codeType != null ? _codeType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _codeType;
        private String _find1;
        private String _hospCode;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public BAS0001U00FbxDodobuHyeunFindClickArgs() { }

        public BAS0001U00FbxDodobuHyeunFindClickArgs(String codeType, String find1, String hospCode)
        {
            this._codeType = codeType;
            this._find1 = find1;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0001U00FbxDodobuHyeunFindClickRequest();
        }
    }
}