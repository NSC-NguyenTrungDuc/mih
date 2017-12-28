using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01PrintNameArgs : IContractArgs
	{
        protected bool Equals(DrgsDRG5100P01PrintNameArgs other)
        {
            return string.Equals(_ipAddr, other._ipAddr);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DrgsDRG5100P01PrintNameArgs) obj);
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

		public DrgsDRG5100P01PrintNameArgs() { }

		public DrgsDRG5100P01PrintNameArgs(String ipAddr)
		{
			this._ipAddr = ipAddr;
		}

		public IExtensible GetRequestInstance()
		{
			return new DrgsDRG5100P01PrintNameRequest();
		}
	}
}