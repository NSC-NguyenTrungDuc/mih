using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using NuroManagePatientInfo = IHIS.CloudConnector.Contracts.Models.Nuro.NuroManagePatientInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class OUT0101U04SaveLayoutArgs : IContractArgs
	{
        protected bool Equals(OUT0101U04SaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && Equals(_listInfo, other._listInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OUT0101U04SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_listInfo != null ? _listInfo.GetHashCode() : 0);
            }
        }

        private String _userId;
		private List<NuroManagePatientInfo> _listInfo = new List<NuroManagePatientInfo>();

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public List<NuroManagePatientInfo> ListInfo
		{
			get { return this._listInfo; }
			set { this._listInfo = value; }
		}

		public OUT0101U04SaveLayoutArgs() { }

		public OUT0101U04SaveLayoutArgs(String userId, List<NuroManagePatientInfo> listInfo)
		{
			this._userId = userId;
			this._listInfo = listInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new OUT0101U04SaveLayoutRequest();
		}
	}
}