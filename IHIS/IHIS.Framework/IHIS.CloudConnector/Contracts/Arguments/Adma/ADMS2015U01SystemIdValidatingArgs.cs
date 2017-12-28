using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADMS2015U01SystemIdValidatingArgs : IContractArgs
	{
        protected bool Equals(ADMS2015U01SystemIdValidatingArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_sysId, other._sysId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADMS2015U01SystemIdValidatingArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_hospCode != null ? _hospCode.GetHashCode() : 0)*397) ^ (_sysId != null ? _sysId.GetHashCode() : 0);
            }
        }

        private String _hospCode;
		private String _sysId;

		public String HospCode
		{
			get { return this._hospCode; }
			set { this._hospCode = value; }
		}

		public String SysId
		{
			get { return this._sysId; }
			set { this._sysId = value; }
		}

		public ADMS2015U01SystemIdValidatingArgs() { }

		public ADMS2015U01SystemIdValidatingArgs(String hospCode, String sysId)
		{
			this._hospCode = hospCode;
			this._sysId = sysId;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADMS2015U01SystemIdValidatingRequest();
		}
	}
}