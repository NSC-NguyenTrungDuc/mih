using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    [Serializable]
	public class CHT0117Q00GrdCHT0118Args : IContractArgs
	{
        protected bool Equals(CHT0117Q00GrdCHT0118Args other)
        {
            return string.Equals(_gubun, other._gubun) && string.Equals(_buwi, other._buwi) && string.Equals(_buwiName, other._buwiName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CHT0117Q00GrdCHT0118Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_buwi != null ? _buwi.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_buwiName != null ? _buwiName.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _gubun;
		private String _buwi;
		private String _buwiName;

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String Buwi
		{
			get { return this._buwi; }
			set { this._buwi = value; }
		}

		public String BuwiName
		{
			get { return this._buwiName; }
			set { this._buwiName = value; }
		}

		public CHT0117Q00GrdCHT0118Args() { }

		public CHT0117Q00GrdCHT0118Args(String gubun, String buwi, String buwiName)
		{
			this._gubun = gubun;
			this._buwi = buwi;
			this._buwiName = buwiName;
		}

		public IExtensible GetRequestInstance()
		{
			return new CHT0117Q00GrdCHT0118Request();
		}
	}
}