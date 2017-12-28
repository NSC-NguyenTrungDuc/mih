using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0311U00GridListArgs : IContractArgs
    {
        protected bool Equals(BAS0311U00GridListArgs other)
        {
            return string.Equals(_fHospCode, other._fHospCode) && string.Equals(_fSgCode, other._fSgCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0311U00GridListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_fHospCode != null ? _fHospCode.GetHashCode() : 0)*397) ^ (_fSgCode != null ? _fSgCode.GetHashCode() : 0);
            }
        }

        private String _fHospCode;
        private String _fSgCode;

        public String FHospCode
        {
            get { return this._fHospCode; }
            set { this._fHospCode = value; }
        }

        public String FSgCode
        {
            get { return this._fSgCode; }
            set { this._fSgCode = value; }
        }

        public BAS0311U00GridListArgs() { }

        public BAS0311U00GridListArgs(String fHospCode, String fSgCode)
        {
            this._fHospCode = fHospCode;
            this._fSgCode = fSgCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0311U00GridListRequest();
        }
    }
}