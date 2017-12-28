using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3020U00GrdPaArgs : IContractArgs
	{
        protected bool Equals(CPL3020U00GrdPaArgs other)
        {
            return string.Equals(_gubun, other._gubun) && string.Equals(_jundalGubun, other._jundalGubun) && string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U00GrdPaArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jundalGubun != null ? _jundalGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fromDate != null ? _fromDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _gubun;
		private String _jundalGubun;
		private String _fromDate;
		private String _toDate;

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String JundalGubun
		{
			get { return this._jundalGubun; }
			set { this._jundalGubun = value; }
		}

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

		public CPL3020U00GrdPaArgs() { }

		public CPL3020U00GrdPaArgs(String gubun, String jundalGubun, String fromDate, String toDate)
		{
			this._gubun = gubun;
			this._jundalGubun = jundalGubun;
			this._fromDate = fromDate;
			this._toDate = toDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3020U00GrdPaRequest();
		}
	}
}