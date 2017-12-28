using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroGetGubunNameArgs : IContractArgs
	{
        protected bool Equals(NuroGetGubunNameArgs other)
        {
            return string.Equals(_gubun, other._gubun) && string.Equals(_naewonDate, other._naewonDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroGetGubunNameArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_gubun != null ? _gubun.GetHashCode() : 0)*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            }
        }

        private String _gubun;
		private String _naewonDate;

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public NuroGetGubunNameArgs() { }

		public NuroGetGubunNameArgs(String gubun, String naewonDate)
		{
			this._gubun = gubun;
			this._naewonDate = naewonDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroGetGubunNameRequest();
		}
	}
}