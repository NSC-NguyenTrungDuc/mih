using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Endo
{
    [Serializable]
    public class END1001U02GrdPaStatusArgs : IContractArgs
    {
        protected bool Equals(END1001U02GrdPaStatusArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_hospCode, other._hospCode) && string.Equals(_hangmogCode, other._hangmogCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((END1001U02GrdPaStatusArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
        private String _hospCode;
        private String _hangmogCode;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
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

        public END1001U02GrdPaStatusArgs() { }

        public END1001U02GrdPaStatusArgs(String bunho, String hospCode, String hangmogCode)
        {
            this._bunho = bunho;
            this._hospCode = hospCode;
            this._hangmogCode = hangmogCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.END1001U02GrdPaStatusRequest();
        }
    }
}