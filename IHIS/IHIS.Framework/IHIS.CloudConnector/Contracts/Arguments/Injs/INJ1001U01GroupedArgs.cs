using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class INJ1001U01GroupedArgs : IContractArgs
	{
        protected bool Equals(INJ1001U01GroupedArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_orderDate, other._orderDate) && string.Equals(_postOrderYn, other._postOrderYn) && string.Equals(_preOrderYn, other._preOrderYn) && string.Equals(_reserDate, other._reserDate) && string.Equals(_actingFlag, other._actingFlag) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_actingDate, other._actingDate) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ1001U01GroupedArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_postOrderYn != null ? _postOrderYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_preOrderYn != null ? _preOrderYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_actingFlag != null ? _actingFlag.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_actingDate != null ? _actingDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
		private String _orderDate;
		private String _postOrderYn;
		private String _preOrderYn;
		private String _reserDate;
		private String _actingFlag;
		private String _gwa;
		private String _doctor;
		private String _actingDate;
		private String _hospCode;

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

		public String PostOrderYn
		{
			get { return this._postOrderYn; }
			set { this._postOrderYn = value; }
		}

		public String PreOrderYn
		{
			get { return this._preOrderYn; }
			set { this._preOrderYn = value; }
		}

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public String ActingFlag
		{
			get { return this._actingFlag; }
			set { this._actingFlag = value; }
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

		public String ActingDate
		{
			get { return this._actingDate; }
			set { this._actingDate = value; }
		}

		public String HospCode
		{
			get { return this._hospCode; }
			set { this._hospCode = value; }
		}

		public INJ1001U01GroupedArgs() { }

		public INJ1001U01GroupedArgs(String bunho, String orderDate, String postOrderYn, String preOrderYn, String reserDate, String actingFlag, String gwa, String doctor, String actingDate, String hospCode)
		{
			this._bunho = bunho;
			this._orderDate = orderDate;
			this._postOrderYn = postOrderYn;
			this._preOrderYn = preOrderYn;
			this._reserDate = reserDate;
			this._actingFlag = actingFlag;
			this._gwa = gwa;
			this._doctor = doctor;
			this._actingDate = actingDate;
			this._hospCode = hospCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new INJ1001U01GroupedRequest();
		}
	}
}