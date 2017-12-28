using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0000Q00LayResultListTempArgs : IContractArgs
	{
        protected bool Equals(CPL0000Q00LayResultListTempArgs other)
        {
            return string.Equals(_gubunFlag, other._gubunFlag) && string.Equals(_bunho, other._bunho) && string.Equals(_orderDate, other._orderDate) && string.Equals(_jundalGubun, other._jundalGubun) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_resultDate, other._resultDate) && string.Equals(_jubsuDate, other._jubsuDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0000Q00LayResultListTempArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_gubunFlag != null ? _gubunFlag.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jundalGubun != null ? _jundalGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resultDate != null ? _resultDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuDate != null ? _jubsuDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _gubunFlag;
		private String _bunho;
		private String _orderDate;
		private String _jundalGubun;
		private String _gwa;
		private String _doctor;
		private String _resultDate;
		private String _jubsuDate;

		public String GubunFlag
		{
			get { return this._gubunFlag; }
			set { this._gubunFlag = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public String JundalGubun
		{
			get { return this._jundalGubun; }
			set { this._jundalGubun = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String ResultDate
		{
			get { return this._resultDate; }
			set { this._resultDate = value; }
		}

		public String JubsuDate
		{
			get { return this._jubsuDate; }
			set { this._jubsuDate = value; }
		}

		public CPL0000Q00LayResultListTempArgs() { }

		public CPL0000Q00LayResultListTempArgs(String gubunFlag, String bunho, String orderDate, String jundalGubun, String gwa, String doctor, String resultDate, String jubsuDate)
		{
			this._gubunFlag = gubunFlag;
			this._bunho = bunho;
			this._orderDate = orderDate;
			this._jundalGubun = jundalGubun;
			this._gwa = gwa;
			this._doctor = doctor;
			this._resultDate = resultDate;
			this._jubsuDate = jubsuDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0000Q00LayResultListTempRequest();
		}
	}
}