using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG9001R02Lay9001Args : IContractArgs
	{
        protected bool Equals(DRG9001R02Lay9001Args other)
        {
            return string.Equals(_date, other._date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG9001R02Lay9001Args) obj);
        }

        public override int GetHashCode()
        {
            return (_date != null ? _date.GetHashCode() : 0);
        }

        private String _date;

		public String Date
		{
			get { return this._date; }
			set { this._date = value; }
		}

		public DRG9001R02Lay9001Args() { }

		public DRG9001R02Lay9001Args(String date)
		{
			this._date = date;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRG9001R02Lay9001Request();
		}
	}
}