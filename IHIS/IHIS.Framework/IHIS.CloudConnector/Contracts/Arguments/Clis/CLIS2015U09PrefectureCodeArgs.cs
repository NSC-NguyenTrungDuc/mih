using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U09PrefectureCodeArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U09PrefectureCodeArgs other)
        {
            return string.Equals(_codeType, other._codeType) && string.Equals(_find1, other._find1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U09PrefectureCodeArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_codeType != null ? _codeType.GetHashCode() : 0)*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
            }
        }

        private String _codeType;
        private String _find1;

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

        public CLIS2015U09PrefectureCodeArgs() { }

        public CLIS2015U09PrefectureCodeArgs(String codeType, String find1)
        {
            this._codeType = codeType;
            this._find1 = find1;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U09PrefectureCodeRequest();
        }
    }
}