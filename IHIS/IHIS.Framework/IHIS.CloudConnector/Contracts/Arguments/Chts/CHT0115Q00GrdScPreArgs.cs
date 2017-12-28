using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    [Serializable]
	public class CHT0115Q00GrdScPreArgs : IContractArgs
	{
        protected bool Equals(CHT0115Q00GrdScPreArgs other)
        {
            return string.Equals(_susikDetailGubun, other._susikDetailGubun) && string.Equals(_susikName, other._susikName) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CHT0115Q00GrdScPreArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_susikDetailGubun != null ? _susikDetailGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_susikName != null ? _susikName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _susikDetailGubun;
		private String _susikName;
		private String _ioGubun;
		private String _userId;

		public String SusikDetailGubun
		{
			get { return this._susikDetailGubun; }
			set { this._susikDetailGubun = value; }
		}

		public String SusikName
		{
			get { return this._susikName; }
			set { this._susikName = value; }
		}

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public CHT0115Q00GrdScPreArgs() { }

		public CHT0115Q00GrdScPreArgs(String susikDetailGubun, String susikName, String ioGubun, String userId)
		{
			this._susikDetailGubun = susikDetailGubun;
			this._susikName = susikName;
			this._ioGubun = ioGubun;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new CHT0115Q00GrdScPreRequest();
		}
	}
}