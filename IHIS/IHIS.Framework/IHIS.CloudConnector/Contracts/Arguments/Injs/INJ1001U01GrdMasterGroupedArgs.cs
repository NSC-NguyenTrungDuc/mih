using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class INJ1001U01GrdMasterGroupedArgs : IContractArgs
	{
        protected bool Equals(INJ1001U01GrdMasterGroupedArgs other)
        {
            return string.Equals(_actingFlag, other._actingFlag) && string.Equals(_reserDate, other._reserDate) && string.Equals(_gwa, other._gwa);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ1001U01GrdMasterGroupedArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_actingFlag != null ? _actingFlag.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _actingFlag;
		private String _reserDate;
		private String _gwa;

		public String ActingFlag
		{
			get { return this._actingFlag; }
			set { this._actingFlag = value; }
		}

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public INJ1001U01GrdMasterGroupedArgs() { }

		public INJ1001U01GrdMasterGroupedArgs(String actingFlag, String reserDate, String gwa)
		{
			this._actingFlag = actingFlag;
			this._reserDate = reserDate;
			this._gwa = gwa;
		}

		public IExtensible GetRequestInstance()
		{
			return new INJ1001U01GrdMasterGroupedRequest();
		}
	}
}