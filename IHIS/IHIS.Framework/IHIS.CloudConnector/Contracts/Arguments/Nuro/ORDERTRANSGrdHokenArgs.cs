using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdHokenArgs : IContractArgs
    {
        protected bool Equals(ORDERTRANSGrdHokenArgs other)
        {
            return string.Equals(_actingDate, other._actingDate) && string.Equals(_gubun, other._gubun) && string.Equals(_hospCode, other._hospCode) && string.Equals(_bunho, other._bunho) && string.Equals(_sendYn, other._sendYn);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ORDERTRANSGrdHokenArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_actingDate != null ? _actingDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sendYn != null ? _sendYn.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _actingDate;
        private String _gubun;
        private String _hospCode;
        private String _bunho;
        private String _sendYn;

        public String ActingDate
        {
            get { return this._actingDate; }
            set { this._actingDate = value; }
        }

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String SendYn
        {
            get { return this._sendYn; }
            set { this._sendYn = value; }
        }

        public ORDERTRANSGrdHokenArgs() { }

        public ORDERTRANSGrdHokenArgs(String actingDate, String gubun, String hospCode, String bunho, String sendYn)
        {
            this._actingDate = actingDate;
            this._gubun = gubun;
            this._hospCode = hospCode;
            this._bunho = bunho;
            this._sendYn = sendYn;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANSGrdHokenRequest();
        }
    }
}