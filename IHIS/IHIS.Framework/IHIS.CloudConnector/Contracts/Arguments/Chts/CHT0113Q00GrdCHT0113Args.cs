using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    [Serializable]
	public class CHT0113Q00GrdCHT0113Args : IContractArgs
	{
        protected bool Equals(CHT0113Q00GrdCHT0113Args other)
        {
            return string.Equals(_disabilityName, other._disabilityName) && string.Equals(_date, other._date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CHT0113Q00GrdCHT0113Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_disabilityName != null ? _disabilityName.GetHashCode() : 0)*397) ^ (_date != null ? _date.GetHashCode() : 0);
            }
        }

        private String _disabilityName;
		private String _date;

		public String DisabilityName
		{
			get { return this._disabilityName; }
			set { this._disabilityName = value; }
		}

		public String Date
		{
			get { return this._date; }
			set { this._date = value; }
		}

		public CHT0113Q00GrdCHT0113Args() { }

		public CHT0113Q00GrdCHT0113Args(String disabilityName, String date)
		{
			this._disabilityName = disabilityName;
			this._date = date;
		}

		public IExtensible GetRequestInstance()
		{
			return new CHT0113Q00GrdCHT0113Request();
		}
	}
}