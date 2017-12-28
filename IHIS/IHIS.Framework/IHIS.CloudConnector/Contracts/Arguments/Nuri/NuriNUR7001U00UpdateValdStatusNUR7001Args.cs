using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuri
{
    [Serializable]
	public class NuriNUR7001U00UpdateValdStatusNUR7001Args : IContractArgs
	{
        protected bool Equals(NuriNUR7001U00UpdateValdStatusNUR7001Args other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_bunho, other._bunho) && string.Equals(_measureDate, other._measureDate) && string.Equals(_seq, other._seq);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuriNUR7001U00UpdateValdStatusNUR7001Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_measureDate != null ? _measureDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_seq != null ? _seq.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
		private String _bunho;
		private String _measureDate;
		private String _seq;

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String MeasureDate
		{
			get { return this._measureDate; }
			set { this._measureDate = value; }
		}

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
		}

		public NuriNUR7001U00UpdateValdStatusNUR7001Args() { }

		public NuriNUR7001U00UpdateValdStatusNUR7001Args(String userId, String bunho, String measureDate, String seq)
		{
			this._userId = userId;
			this._bunho = bunho;
			this._measureDate = measureDate;
			this._seq = seq;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuriNUR7001U00UpdateValdStatusNUR7001Request();
		}
	}
}