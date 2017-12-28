using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class INJ1001U01FormJusaBedLayHosilListArgs : IContractArgs
	{
        protected bool Equals(INJ1001U01FormJusaBedLayHosilListArgs other)
        {
            return string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ1001U01FormJusaBedLayHosilListArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_hospCode != null ? _hospCode.GetHashCode() : 0);
        }

        private String _hospCode;

		public String HospCode
		{
			get { return this._hospCode; }
			set { this._hospCode = value; }
		}

		public INJ1001U01FormJusaBedLayHosilListArgs() { }

		public INJ1001U01FormJusaBedLayHosilListArgs(String hospCode)
		{
			this._hospCode = hospCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new INJ1001U01FormJusaBedLayHosilListRequest();
		}
	}
}