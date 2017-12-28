using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuri
{
    [Serializable]
	public class NuriNUR1016U00ManageAllergyListArgs : IContractArgs
	{
        protected bool Equals(NuriNUR1016U00ManageAllergyListArgs other)
        {
            return string.Equals(_bunho, other._bunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuriNUR1016U00ManageAllergyListArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_bunho != null ? _bunho.GetHashCode() : 0);
        }

        private String _bunho;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public NuriNUR1016U00ManageAllergyListArgs() { }

		public NuriNUR1016U00ManageAllergyListArgs(String bunho)
		{
			this._bunho = bunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuriNUR1016U00ManageAllergyListRequest();
		}
	}
}