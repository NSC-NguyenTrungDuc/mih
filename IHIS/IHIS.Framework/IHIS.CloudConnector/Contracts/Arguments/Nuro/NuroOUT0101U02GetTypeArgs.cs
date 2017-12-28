using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroOUT0101U02GetTypeArgs : IContractArgs
	{
        protected bool Equals(NuroOUT0101U02GetTypeArgs other)
        {
            return string.Equals(_johapGubun, other._johapGubun) && string.Equals(_find1, other._find1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT0101U02GetTypeArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_johapGubun != null ? _johapGubun.GetHashCode() : 0)*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
            }
        }

        private String _johapGubun;
		private String _find1;

		public String JohapGubun
		{
			get { return this._johapGubun; }
			set { this._johapGubun = value; }
		}

		public String Find1
		{
			get { return this._find1; }
			set { this._find1 = value; }
		}

		public NuroOUT0101U02GetTypeArgs() { }

		public NuroOUT0101U02GetTypeArgs(String johapGubun, String find1)
		{
			this._johapGubun = johapGubun;
			this._find1 = find1;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroOUT0101U02GetTypeRequest();
		}
	}
}