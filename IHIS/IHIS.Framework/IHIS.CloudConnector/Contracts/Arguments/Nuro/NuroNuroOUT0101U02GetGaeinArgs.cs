using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroNuroOUT0101U02GetGaeinArgs : IContractArgs
	{
        protected bool Equals(NuroNuroOUT0101U02GetGaeinArgs other)
        {
            return string.Equals(_johap, other._johap) && string.Equals(_gaein, other._gaein);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroNuroOUT0101U02GetGaeinArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_johap != null ? _johap.GetHashCode() : 0)*397) ^ (_gaein != null ? _gaein.GetHashCode() : 0);
            }
        }

        private String _johap;
		private String _gaein;

		public String Johap
		{
			get { return this._johap; }
			set { this._johap = value; }
		}

		public String Gaein
		{
			get { return this._gaein; }
			set { this._gaein = value; }
		}

		public NuroNuroOUT0101U02GetGaeinArgs() { }

		public NuroNuroOUT0101U02GetGaeinArgs(String johap, String gaein)
		{
			this._johap = johap;
			this._gaein = gaein;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroNuroOUT0101U02GetGaeinRequest();
		}
	}
}