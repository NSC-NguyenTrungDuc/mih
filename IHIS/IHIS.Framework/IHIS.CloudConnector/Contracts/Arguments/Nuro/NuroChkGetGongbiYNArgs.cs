using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroChkGetGongbiYNArgs : IContractArgs
	{
        protected bool Equals(NuroChkGetGongbiYNArgs other)
        {
            return string.Equals(_gubun, other._gubun) && string.Equals(_date, other._date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroChkGetGongbiYNArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_gubun != null ? _gubun.GetHashCode() : 0)*397) ^ (_date != null ? _date.GetHashCode() : 0);
            }
        }

        private String _gubun;
		private String _date;

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String Date
		{
			get { return this._date; }
			set { this._date = value; }
		}

		public NuroChkGetGongbiYNArgs() { }

		public NuroChkGetGongbiYNArgs(String gubun, String date)
		{
			this._gubun = gubun;
			this._date = date;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroChkGetGongbiYNRequest();
		}
	}
}