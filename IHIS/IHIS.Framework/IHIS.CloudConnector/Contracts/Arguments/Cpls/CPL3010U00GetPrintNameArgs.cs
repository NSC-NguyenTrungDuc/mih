using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3010U00GetPrintNameArgs : IContractArgs
	{
        protected bool Equals(CPL3010U00GetPrintNameArgs other)
        {
            return string.Equals(_ipAddr, other._ipAddr);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3010U00GetPrintNameArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_ipAddr != null ? _ipAddr.GetHashCode() : 0);
        }

        private String _ipAddr;

		public String IpAddr
		{
			get { return this._ipAddr; }
			set { this._ipAddr = value; }
		}

		public CPL3010U00GetPrintNameArgs() { }

		public CPL3010U00GetPrintNameArgs(String ipAddr)
		{
			this._ipAddr = ipAddr;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3010U00GetPrintNameRequest();
		}
	}
}