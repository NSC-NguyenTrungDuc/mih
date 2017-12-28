using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using NuriNUR7001U00MeasurePhysicalConditionListItemInfo = IHIS.CloudConnector.Contracts.Models.Nuri.NuriNUR7001U00MeasurePhysicalConditionListItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuri
{
    [Serializable]
	public class NuriNUR7001U00SaveLayoutArgs : IContractArgs
	{
        protected bool Equals(NuriNUR7001U00SaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && Equals(_listInfo, other._listInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuriNUR7001U00SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_listInfo != null ? _listInfo.GetHashCode() : 0);
            }
        }

        private String _userId;
		private List<NuriNUR7001U00MeasurePhysicalConditionListItemInfo> _listInfo = new List<NuriNUR7001U00MeasurePhysicalConditionListItemInfo>();

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public List<NuriNUR7001U00MeasurePhysicalConditionListItemInfo> ListInfo
		{
			get { return this._listInfo; }
			set { this._listInfo = value; }
		}

		public NuriNUR7001U00SaveLayoutArgs() { }

		public NuriNUR7001U00SaveLayoutArgs(String userId, List<NuriNUR7001U00MeasurePhysicalConditionListItemInfo> listInfo)
		{
			this._userId = userId;
			this._listInfo = listInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuriNUR7001U00SaveLayoutRequest();
		}
	}
}