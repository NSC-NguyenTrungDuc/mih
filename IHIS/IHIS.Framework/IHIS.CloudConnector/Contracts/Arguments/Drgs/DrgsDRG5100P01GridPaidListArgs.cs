using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01GridPaidListArgs : IContractArgs
	{
        protected bool Equals(DrgsDRG5100P01GridPaidListArgs other)
        {
            return string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate) && string.Equals(_gwa, other._gwa) && string.Equals(_wonyoiYn, other._wonyoiYn) && string.Equals(_gubun, other._gubun) && string.Equals(_bunho, other._bunho) && _xrbOrderValue.Equals(other._xrbOrderValue);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DrgsDRG5100P01GridPaidListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_fromDate != null ? _fromDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_wonyoiYn != null ? _wonyoiYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _xrbOrderValue.GetHashCode();
                return hashCode;
            }
        }

        private String _fromDate;
		private String _toDate;
		private String _gwa;
		private String _wonyoiYn;
		private String _gubun;
		private String _bunho;
		private Boolean _xrbOrderValue;

		public String FromDate
		{
			get { return this._fromDate; }
			set { this._fromDate = value; }
		}

		public String ToDate
		{
			get { return this._toDate; }
			set { this._toDate = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String WonyoiYn
		{
			get { return this._wonyoiYn; }
			set { this._wonyoiYn = value; }
		}

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public Boolean XrbOrderValue
		{
			get { return this._xrbOrderValue; }
			set { this._xrbOrderValue = value; }
		}

		public DrgsDRG5100P01GridPaidListArgs() { }

		public DrgsDRG5100P01GridPaidListArgs(String fromDate, String toDate, String gwa, String wonyoiYn, String gubun, String bunho, Boolean xrbOrderValue)
		{
			this._fromDate = fromDate;
			this._toDate = toDate;
			this._gwa = gwa;
			this._wonyoiYn = wonyoiYn;
			this._gubun = gubun;
			this._bunho = bunho;
			this._xrbOrderValue = xrbOrderValue;
		}

		public IExtensible GetRequestInstance()
		{
			return new DrgsDRG5100P01GridPaidListRequest();
		}
	}
}