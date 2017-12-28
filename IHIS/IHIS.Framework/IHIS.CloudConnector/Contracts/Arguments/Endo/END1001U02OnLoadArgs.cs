using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Endo
{
    [Serializable]
    public class END1001U02OnLoadArgs : IContractArgs
    {
        protected bool Equals(END1001U02OnLoadArgs other)
        {
            return string.Equals(_fkocs, other._fkocs) && string.Equals(_hospCode, other._hospCode) && string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_bunho, other._bunho) && string.Equals(_code, other._code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((END1001U02OnLoadArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_fkocs != null ? _fkocs.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_code != null ? _code.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _fkocs;
        private String _hospCode;
        private String _hangmogCode;
        private String _bunho;
        private String _code;

        public String Fkocs
        {
            get { return this._fkocs; }
            set { this._fkocs = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public END1001U02OnLoadArgs() { }

        public END1001U02OnLoadArgs(String fkocs, String hospCode, String hangmogCode, String bunho, String code)
        {
            this._fkocs = fkocs;
            this._hospCode = hospCode;
            this._hangmogCode = hangmogCode;
            this._bunho = bunho;
            this._code = code;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.END1001U02OnLoadRequest();
        }
    }
}