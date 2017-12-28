using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL2010U00SetPrintArgs : IContractArgs
    {
        protected bool Equals(CPL2010U00SetPrintArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_bPrintName, other._bPrintName) && string.Equals(_ipAddr, other._ipAddr);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL2010U00SetPrintArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bPrintName != null ? _bPrintName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_ipAddr != null ? _ipAddr.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private String _bPrintName;
        private String _ipAddr;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String BPrintName
        {
            get { return this._bPrintName; }
            set { this._bPrintName = value; }
        }

        public String IpAddr
        {
            get { return this._ipAddr; }
            set { this._ipAddr = value; }
        }

        public CPL2010U00SetPrintArgs() { }

        public CPL2010U00SetPrintArgs(String userId, String bPrintName, String ipAddr)
        {
            this._userId = userId;
            this._bPrintName = bPrintName;
            this._ipAddr = ipAddr;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010U00SetPrintRequest();
        }
    }
}