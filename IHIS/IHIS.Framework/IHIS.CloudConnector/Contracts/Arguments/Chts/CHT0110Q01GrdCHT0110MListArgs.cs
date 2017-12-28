using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    [Serializable]
	public class CHT0110Q01GrdCHT0110MListArgs : IContractArgs
	{
        protected bool Equals(CHT0110Q01GrdCHT0110MListArgs other)
        {
            return string.Equals(_sangInx, other._sangInx) && string.Equals(_date, other._date) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CHT0110Q01GrdCHT0110MListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_sangInx != null ? _sangInx.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_date != null ? _date.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _sangInx;
		private String _date;
		private String _ioGubun;
		private String _userId;

		public String SangInx
		{
			get { return this._sangInx; }
			set { this._sangInx = value; }
		}

		public String Date
		{
			get { return this._date; }
			set { this._date = value; }
		}

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public CHT0110Q01GrdCHT0110MListArgs() { }

		public CHT0110Q01GrdCHT0110MListArgs(String sangInx, String date, String ioGubun, String userId)
		{
			this._sangInx = sangInx;
			this._date = date;
			this._ioGubun = ioGubun;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new CHT0110Q01GrdCHT0110MListRequest();
		}
	}
}