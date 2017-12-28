using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroOUT1001U01LoadCheckChojaeJpnArgs : IContractArgs
	{
        protected bool Equals(NuroOUT1001U01LoadCheckChojaeJpnArgs other)
        {
            return string.Equals(_naewonDate, other._naewonDate) && string.Equals(_bunho, other._bunho) && string.Equals(_gubun, other._gubun) && string.Equals(_gwa, other._gwa) && string.Equals(_jubsuNo, other._jubsuNo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01LoadCheckChojaeJpnArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuNo != null ? _jubsuNo.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _naewonDate;
		private String _bunho;
		private String _gubun;
		private String _gwa;
		private String _jubsuNo;

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String JubsuNo
		{
			get { return this._jubsuNo; }
			set { this._jubsuNo = value; }
		}

		public NuroOUT1001U01LoadCheckChojaeJpnArgs() { }

		public NuroOUT1001U01LoadCheckChojaeJpnArgs(String naewonDate, String bunho, String gubun, String gwa, String jubsuNo)
		{
			this._naewonDate = naewonDate;
			this._bunho = bunho;
			this._gubun = gubun;
			this._gwa = gwa;
			this._jubsuNo = jubsuNo;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroOUT1001U01LoadCheckChojaeJpnRequest();
		}
	}
}