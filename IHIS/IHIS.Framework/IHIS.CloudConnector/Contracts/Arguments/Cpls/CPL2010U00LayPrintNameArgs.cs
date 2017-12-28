using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL2010U00LayPrintNameArgs : IContractArgs
    {
        protected bool Equals(CPL2010U00LayPrintNameArgs other)
        {
            return string.Equals(_ipAddress, other._ipAddress);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL2010U00LayPrintNameArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_ipAddress != null ? _ipAddress.GetHashCode() : 0);
        }

        private String _ipAddress;

        public String IpAddress
        {
            get { return this._ipAddress; }
            set { this._ipAddress = value; }
        }

        public CPL2010U00LayPrintNameArgs() { }

        public CPL2010U00LayPrintNameArgs(String ipAddress)
        {
            this._ipAddress = ipAddress;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010U00LayPrintNameRequest();
        }
    }
}