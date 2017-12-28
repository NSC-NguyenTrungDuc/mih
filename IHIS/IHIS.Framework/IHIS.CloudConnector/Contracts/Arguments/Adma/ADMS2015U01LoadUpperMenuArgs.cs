using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADMS2015U01LoadUpperMenuArgs : IContractArgs
	{
        protected bool Equals(ADMS2015U01LoadUpperMenuArgs other)
        {
            return string.Equals(_sysId, other._sysId) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADMS2015U01LoadUpperMenuArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_sysId != null ? _sysId.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            }
        }

        private String _sysId;
		private String _hospCode;

		public String SysId
		{
			get { return this._sysId; }
			set { this._sysId = value; }
		}

		public String HospCode
		{
			get { return this._hospCode; }
			set { this._hospCode = value; }
		}

		public ADMS2015U01LoadUpperMenuArgs() { }

		public ADMS2015U01LoadUpperMenuArgs(String sysId, String hospCode)
		{
			this._sysId = sysId;
			this._hospCode = hospCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADMS2015U01LoadUpperMenuRequest();
		}
	}
}