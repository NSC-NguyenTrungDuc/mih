using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroNUR1001R00GetGwaDoctorTempListArgs : IContractArgs
	{
        protected bool Equals(NuroNUR1001R00GetGwaDoctorTempListArgs other)
        {
            return string.Equals(_gwa, other._gwa) && string.Equals(_month, other._month);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroNUR1001R00GetGwaDoctorTempListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_gwa != null ? _gwa.GetHashCode() : 0)*397) ^ (_month != null ? _month.GetHashCode() : 0);
            }
        }

        private String _gwa;
		private String _month;

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String Month
		{
			get { return this._month; }
			set { this._month = value; }
		}

		public NuroNUR1001R00GetGwaDoctorTempListArgs() { }

		public NuroNUR1001R00GetGwaDoctorTempListArgs(String gwa, String month)
		{
			this._gwa = gwa;
			this._month = month;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroNUR1001R00GetGwaDoctorTempListRequest();
		}
	}
}