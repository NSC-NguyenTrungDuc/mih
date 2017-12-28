using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class InjsINJ1001U01CplOrderStatusArgs : IContractArgs
	{
        protected bool Equals(InjsINJ1001U01CplOrderStatusArgs other)
        {
            return string.Equals(_gubun, other._gubun) && string.Equals(_bunho, other._bunho) && string.Equals(_date, other._date) && string.Equals(_jundalPart, other._jundalPart);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((InjsINJ1001U01CplOrderStatusArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_date != null ? _date.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _gubun;
		private String _bunho;
		private String _date;
		private String _jundalPart;

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

		public String Date
		{
			get { return this._date; }
			set { this._date = value; }
		}

		public String JundalPart
		{
			get { return this._jundalPart; }
			set { this._jundalPart = value; }
		}

		public InjsINJ1001U01CplOrderStatusArgs() { }

		public InjsINJ1001U01CplOrderStatusArgs(String gubun, String bunho, String date, String jundalPart)
		{
			this._gubun = gubun;
			this._bunho = bunho;
			this._date = date;
			this._jundalPart = jundalPart;
		}

		public IExtensible GetRequestInstance()
		{
			return new InjsINJ1001U01CplOrderStatusRequest();
		}
	}
}