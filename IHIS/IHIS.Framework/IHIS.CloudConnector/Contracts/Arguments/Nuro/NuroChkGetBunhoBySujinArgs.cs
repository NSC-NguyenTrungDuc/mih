using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroChkGetBunhoBySujinArgs : IContractArgs
	{
        protected bool Equals(NuroChkGetBunhoBySujinArgs other)
        {
            return string.Equals(_naewonDate, other._naewonDate) && string.Equals(_sujinNo, other._sujinNo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroChkGetBunhoBySujinArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_naewonDate != null ? _naewonDate.GetHashCode() : 0)*397) ^ (_sujinNo != null ? _sujinNo.GetHashCode() : 0);
            }
        }

        private String _naewonDate;
		private String _sujinNo;

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String SujinNo
		{
			get { return this._sujinNo; }
			set { this._sujinNo = value; }
		}

		public NuroChkGetBunhoBySujinArgs() { }

		public NuroChkGetBunhoBySujinArgs(String naewonDate, String sujinNo)
		{
			this._naewonDate = naewonDate;
			this._sujinNo = sujinNo;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroChkGetBunhoBySujinRequest();
		}
	}
}