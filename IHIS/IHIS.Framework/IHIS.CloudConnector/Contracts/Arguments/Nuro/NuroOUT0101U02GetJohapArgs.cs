using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroOUT0101U02GetJohapArgs : IContractArgs
	{
        protected bool Equals(NuroOUT0101U02GetJohapArgs other)
        {
            return string.Equals(_johap, other._johap) && string.Equals(_date, other._date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT0101U02GetJohapArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_johap != null ? _johap.GetHashCode() : 0)*397) ^ (_date != null ? _date.GetHashCode() : 0);
            }
        }

        private String _johap;
		private String _date;

		public String Johap
		{
			get { return this._johap; }
			set { this._johap = value; }
		}

		public String Date
		{
			get { return this._date; }
			set { this._date = value; }
		}

		public NuroOUT0101U02GetJohapArgs() { }

		public NuroOUT0101U02GetJohapArgs(String johap, String date)
		{
			this._johap = johap;
			this._date = date;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroOUT0101U02GetJohapRequest();
		}
	}
}