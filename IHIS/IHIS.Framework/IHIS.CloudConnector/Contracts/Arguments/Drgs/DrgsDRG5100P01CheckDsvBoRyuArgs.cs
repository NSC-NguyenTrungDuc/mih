using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01CheckDsvBoRyuArgs : IContractArgs
	{
        protected bool Equals(DrgsDRG5100P01CheckDsvBoRyuArgs other)
        {
            return string.Equals(_boryuYn, other._boryuYn) && string.Equals(_drgBunho, other._drgBunho) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_bunho, other._bunho) && string.Equals(_orderDate, other._orderDate) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DrgsDRG5100P01CheckDsvBoRyuArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_boryuYn != null ? _boryuYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_drgBunho != null ? _drgBunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _boryuYn;
		private String _drgBunho;
		private String _gwa;
		private String _doctor;
		private String _bunho;
		private String _orderDate;
		private String _userId;

		public String BoryuYn
		{
			get { return this._boryuYn; }
			set { this._boryuYn = value; }
		}

		public String DrgBunho
		{
			get { return this._drgBunho; }
			set { this._drgBunho = value; }
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

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public DrgsDRG5100P01CheckDsvBoRyuArgs() { }

		public DrgsDRG5100P01CheckDsvBoRyuArgs(String boryuYn, String drgBunho, String gwa, String doctor, String bunho, String orderDate, String userId)
		{
			this._boryuYn = boryuYn;
			this._drgBunho = drgBunho;
			this._gwa = gwa;
			this._doctor = doctor;
			this._bunho = bunho;
			this._orderDate = orderDate;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new DrgsDRG5100P01CheckDsvBoRyuRequest();
		}
	}
}