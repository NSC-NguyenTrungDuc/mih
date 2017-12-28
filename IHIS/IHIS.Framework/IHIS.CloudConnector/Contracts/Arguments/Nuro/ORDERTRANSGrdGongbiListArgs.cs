using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdGongbiListArgs : IContractArgs
    {
        protected bool Equals(ORDERTRANSGrdGongbiListArgs other)
        {
            return string.Equals(_ioGubun, other._ioGubun) && string.Equals(_sendYn, other._sendYn) && string.Equals(_hospCode, other._hospCode) && string.Equals(_bunho, other._bunho) && string.Equals(_out1001, other._out1001) && string.Equals(_pkinp1002, other._pkinp1002) && string.Equals(_pkout, other._pkout);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ORDERTRANSGrdGongbiListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sendYn != null ? _sendYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_out1001 != null ? _out1001.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkinp1002 != null ? _pkinp1002.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkout != null ? _pkout.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _ioGubun;
        private String _sendYn;
        private String _hospCode;
        private String _bunho;
        private String _out1001;
        private String _pkinp1002;
        private String _pkout;

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public String SendYn
        {
            get { return this._sendYn; }
            set { this._sendYn = value; }
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

        public String Out1001
        {
            get { return this._out1001; }
            set { this._out1001 = value; }
        }

        public String Pkinp1002
        {
            get { return this._pkinp1002; }
            set { this._pkinp1002 = value; }
        }

        public String Pkout
        {
            get { return this._pkout; }
            set { this._pkout = value; }
        }

        public ORDERTRANSGrdGongbiListArgs() { }

        public ORDERTRANSGrdGongbiListArgs(String ioGubun, String sendYn, String hospCode, String bunho, String out1001, String pkinp1002, String pkout)
        {
            this._ioGubun = ioGubun;
            this._sendYn = sendYn;
            this._hospCode = hospCode;
            this._bunho = bunho;
            this._out1001 = out1001;
            this._pkinp1002 = pkinp1002;
            this._pkout = pkout;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANSGrdGongbiListRequest();
        }
    }
}