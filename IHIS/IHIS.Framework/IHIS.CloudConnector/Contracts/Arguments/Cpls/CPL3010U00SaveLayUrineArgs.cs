using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using CPL3010U00LayUrineInfo = IHIS.CloudConnector.Contracts.Models.Cpls.CPL3010U00LayUrineInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3010U00SaveLayUrineArgs : IContractArgs
	{
        protected bool Equals(CPL3010U00SaveLayUrineArgs other)
        {
            return Equals(_urineInfo, other._urineInfo) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3010U00SaveLayUrineArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_urineInfo != null ? _urineInfo.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            }
        }

        private List<CPL3010U00LayUrineInfo> _urineInfo = new List<CPL3010U00LayUrineInfo>();
		private String _userId;

		public List<CPL3010U00LayUrineInfo> UrineInfo
		{
			get { return this._urineInfo; }
			set { this._urineInfo = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public CPL3010U00SaveLayUrineArgs() { }

		public CPL3010U00SaveLayUrineArgs(List<CPL3010U00LayUrineInfo> urineInfo, String userId)
		{
			this._urineInfo = urineInfo;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3010U00SaveLayUrineRequest();
		}
	}
}