using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroOUT0101U02GetInsurance2Args : IContractArgs
	{
        protected bool Equals(NuroOUT0101U02GetInsurance2Args other)
        {
            return string.Equals(_find1, other._find1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT0101U02GetInsurance2Args) obj);
        }

        public override int GetHashCode()
        {
            return (_find1 != null ? _find1.GetHashCode() : 0);
        }

        private String _find1;

		public String Find1
		{
			get { return this._find1; }
			set { this._find1 = value; }
		}

		public NuroOUT0101U02GetInsurance2Args() { }

		public NuroOUT0101U02GetInsurance2Args(String find1)
		{
			this._find1 = find1;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroOUT0101U02GetInsurance2Request();
		}
	}
}