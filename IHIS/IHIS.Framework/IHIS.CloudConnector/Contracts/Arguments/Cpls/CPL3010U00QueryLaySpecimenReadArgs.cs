using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3010U00QueryLaySpecimenReadArgs : IContractArgs
	{
        protected bool Equals(CPL3010U00QueryLaySpecimenReadArgs other)
        {
            return string.Equals(_specimenReadValue, other._specimenReadValue) && string.Equals(_partJubsuja, other._partJubsuja) && string.Equals(_gumJubsuDate, other._gumJubsuDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3010U00QueryLaySpecimenReadArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_specimenReadValue != null ? _specimenReadValue.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_partJubsuja != null ? _partJubsuja.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gumJubsuDate != null ? _gumJubsuDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _specimenReadValue;
		private String _partJubsuja;
		private String _gumJubsuDate;

		public String SpecimenReadValue
		{
			get { return this._specimenReadValue; }
			set { this._specimenReadValue = value; }
		}

		public String PartJubsuja
		{
			get { return this._partJubsuja; }
			set { this._partJubsuja = value; }
		}

		public String GumJubsuDate
		{
			get { return this._gumJubsuDate; }
			set { this._gumJubsuDate = value; }
		}

		public CPL3010U00QueryLaySpecimenReadArgs() { }

		public CPL3010U00QueryLaySpecimenReadArgs(String specimenReadValue, String partJubsuja, String gumJubsuDate)
		{
			this._specimenReadValue = specimenReadValue;
			this._partJubsuja = partJubsuja;
			this._gumJubsuDate = gumJubsuDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3010U00QueryLaySpecimenReadRequest();
		}
	}
}