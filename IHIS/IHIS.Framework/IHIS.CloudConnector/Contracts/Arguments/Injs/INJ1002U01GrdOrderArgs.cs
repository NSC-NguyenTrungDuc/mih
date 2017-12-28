using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class INJ1002U01GrdOrderArgs : IContractArgs
	{
        protected bool Equals(INJ1002U01GrdOrderArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_reserDate, other._reserDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ1002U01GrdOrderArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
            }
        }

        private String _bunho;
		private String _reserDate;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public INJ1002U01GrdOrderArgs() { }

		public INJ1002U01GrdOrderArgs(String bunho, String reserDate)
		{
			this._bunho = bunho;
			this._reserDate = reserDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new INJ1002U01GrdOrderRequest();
		}
	}
}