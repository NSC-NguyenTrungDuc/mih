using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG9040U01GrdOrderOutArgs : IContractArgs
	{
        protected bool Equals(DRG9040U01GrdOrderOutArgs other)
        {
            return string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate) && string.Equals(_bunho, other._bunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG9040U01GrdOrderOutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_fromDate != null ? _fromDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _fromDate;
		private String _toDate;
		private String _bunho;

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

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public DRG9040U01GrdOrderOutArgs() { }

		public DRG9040U01GrdOrderOutArgs(String fromDate, String toDate, String bunho)
		{
			this._fromDate = fromDate;
			this._toDate = toDate;
			this._bunho = bunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRG9040U01GrdOrderOutRequest();
		}
	}
}