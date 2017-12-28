using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0210U00DupCheckArgs : IContractArgs
	{
        protected bool Equals(BAS0210U00DupCheckArgs other)
        {
            return string.Equals(_gubun, other._gubun) && string.Equals(_startDate, other._startDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0210U00DupCheckArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_gubun != null ? _gubun.GetHashCode() : 0)*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
            }
        }

        private String _gubun;
		private String _startDate;

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String StartDate
		{
			get { return this._startDate; }
			set { this._startDate = value; }
		}

		public BAS0210U00DupCheckArgs() { }

		public BAS0210U00DupCheckArgs(String gubun, String startDate)
		{
			this._gubun = gubun;
			this._startDate = startDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0210U00DupCheckRequest();
		}
	}
}