using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADMS2015U01LoadMenuItemArgs : IContractArgs
	{
        protected bool Equals(ADMS2015U01LoadMenuItemArgs other)
        {
            return string.Equals(_sysId, other._sysId) && string.Equals(_upprMenu, other._upprMenu) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADMS2015U01LoadMenuItemArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_sysId != null ? _sysId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_upprMenu != null ? _upprMenu.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _sysId;
		private String _upprMenu;
		private String _hospCode;

		public String SysId
		{
			get { return this._sysId; }
			set { this._sysId = value; }
		}

		public String UpprMenu
		{
			get { return this._upprMenu; }
			set { this._upprMenu = value; }
		}

		public String HospCode
		{
			get { return this._hospCode; }
			set { this._hospCode = value; }
		}

		public ADMS2015U01LoadMenuItemArgs() { }

		public ADMS2015U01LoadMenuItemArgs(String sysId, String upprMenu, String hospCode)
		{
			this._sysId = sysId;
			this._upprMenu = upprMenu;
			this._hospCode = hospCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADMS2015U01LoadMenuItemRequest();
		}
	}
}