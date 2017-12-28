using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuri
{
    [Serializable]
	public class NuriNUR7001U00GetMaxSeqInNUR7001Args : IContractArgs
	{
        protected bool Equals(NuriNUR7001U00GetMaxSeqInNUR7001Args other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_measureDate, other._measureDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuriNUR7001U00GetMaxSeqInNUR7001Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_measureDate != null ? _measureDate.GetHashCode() : 0);
            }
        }

        private String _bunho;
		private String _measureDate;

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

		public NuriNUR7001U00GetMaxSeqInNUR7001Args() { }

		public NuriNUR7001U00GetMaxSeqInNUR7001Args(String bunho, String measureDate)
		{
			this._bunho = bunho;
			this._measureDate = measureDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuriNUR7001U00GetMaxSeqInNUR7001Request();
		}
	}
}