using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class INJ1001FormJusaBedLayGroupedArgs : IContractArgs
	{
        protected bool Equals(INJ1001FormJusaBedLayGroupedArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_codeName, other._codeName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ1001FormJusaBedLayGroupedArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_hospCode != null ? _hospCode.GetHashCode() : 0)*397) ^ (_codeName != null ? _codeName.GetHashCode() : 0);
            }
        }

        private String _hospCode;
		private String _codeName;

		public String HospCode
		{
			get { return this._hospCode; }
			set { this._hospCode = value; }
		}

		public String CodeName
		{
			get { return this._codeName; }
			set { this._codeName = value; }
		}

		public INJ1001FormJusaBedLayGroupedArgs() { }

		public INJ1001FormJusaBedLayGroupedArgs(String hospCode, String codeName)
		{
			this._hospCode = hospCode;
			this._codeName = codeName;
		}

		public IExtensible GetRequestInstance()
		{
			return new INJ1001FormJusaBedLayGroupedRequest();
		}
	}
}