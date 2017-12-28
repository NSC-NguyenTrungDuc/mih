using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroGetZipNameArgs : IContractArgs
	{
        protected bool Equals(NuroGetZipNameArgs other)
        {
            return string.Equals(_zipCode1, other._zipCode1) && string.Equals(_zipCode2, other._zipCode2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroGetZipNameArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_zipCode1 != null ? _zipCode1.GetHashCode() : 0)*397) ^ (_zipCode2 != null ? _zipCode2.GetHashCode() : 0);
            }
        }

        private String _zipCode1;
		private String _zipCode2;

		public String ZipCode1
		{
			get { return this._zipCode1; }
			set { this._zipCode1 = value; }
		}

		public String ZipCode2
		{
			get { return this._zipCode2; }
			set { this._zipCode2 = value; }
		}

		public NuroGetZipNameArgs() { }

		public NuroGetZipNameArgs(String zipCode1, String zipCode2)
		{
			this._zipCode1 = zipCode1;
			this._zipCode2 = zipCode2;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroGetZipNameRequest();
		}
	}
}