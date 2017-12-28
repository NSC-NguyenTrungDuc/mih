using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroGetGwaNameBAS0260Args : IContractArgs
	{
        protected bool Equals(NuroGetGwaNameBAS0260Args other)
        {
            return string.Equals(_gwa, other._gwa) && string.Equals(_date, other._date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroGetGwaNameBAS0260Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_gwa != null ? _gwa.GetHashCode() : 0)*397) ^ (_date != null ? _date.GetHashCode() : 0);
            }
        }

        private String _gwa;
		private String _date;

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String Date
		{
			get { return this._date; }
			set { this._date = value; }
		}

		public NuroGetGwaNameBAS0260Args() { }

		public NuroGetGwaNameBAS0260Args(String gwa, String date)
		{
			this._gwa = gwa;
			this._date = date;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroGetGwaNameBAS0260Request();
		}
	}
}