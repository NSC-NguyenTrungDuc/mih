using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Endo
{
    [Serializable]
    public class END1001U02DsvDwArgs : IContractArgs
    {
        protected bool Equals(END1001U02DsvDwArgs other)
        {
            return string.Equals(_fkocs, other._fkocs) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((END1001U02DsvDwArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_fkocs != null ? _fkocs.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            }
        }

        private String _fkocs;
        private String _hospCode;

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

        public END1001U02DsvDwArgs() { }

        public END1001U02DsvDwArgs(String fkocs, String hospCode)
        {
            this._fkocs = fkocs;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.END1001U02DsvDwRequest();
        }
    }
}