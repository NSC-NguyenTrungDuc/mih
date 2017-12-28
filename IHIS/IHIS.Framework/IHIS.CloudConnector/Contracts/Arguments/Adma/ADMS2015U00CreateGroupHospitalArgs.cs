using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using ADMS2015U00GroupHospitalInfo = IHIS.CloudConnector.Contracts.Models.Adma.ADMS2015U00GroupHospitalInfo;
using ADMS2015U00SystemHospitalInfo = IHIS.CloudConnector.Contracts.Models.Adma.ADMS2015U00SystemHospitalInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADMS2015U00CreateGroupHospitalArgs : IContractArgs
	{
        protected bool Equals(ADMS2015U00CreateGroupHospitalArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_hospCode, other._hospCode) && string.Equals(_groupId, other._groupId) && Equals(_groupListInfo, other._groupListInfo) && Equals(_systemListItem, other._systemListItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADMS2015U00CreateGroupHospitalArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_groupId != null ? _groupId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_groupListInfo != null ? _groupListInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_systemListItem != null ? _systemListItem.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
		private String _hospCode;
		private String _groupId;
		private List<ADMS2015U00GroupHospitalInfo> _groupListInfo = new List<ADMS2015U00GroupHospitalInfo>();
		private List<ADMS2015U00SystemHospitalInfo> _systemListItem = new List<ADMS2015U00SystemHospitalInfo>();

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String HospCode
		{
			get { return this._hospCode; }
			set { this._hospCode = value; }
		}

		public String GroupId
		{
			get { return this._groupId; }
			set { this._groupId = value; }
		}

		public List<ADMS2015U00GroupHospitalInfo> GroupListInfo
		{
			get { return this._groupListInfo; }
			set { this._groupListInfo = value; }
		}

		public List<ADMS2015U00SystemHospitalInfo> SystemListItem
		{
			get { return this._systemListItem; }
			set { this._systemListItem = value; }
		}

		public ADMS2015U00CreateGroupHospitalArgs() { }

		public ADMS2015U00CreateGroupHospitalArgs(String userId, String hospCode, String groupId, List<ADMS2015U00GroupHospitalInfo> groupListInfo, List<ADMS2015U00SystemHospitalInfo> systemListItem)
		{
			this._userId = userId;
			this._hospCode = hospCode;
			this._groupId = groupId;
			this._groupListInfo = groupListInfo;
			this._systemListItem = systemListItem;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADMS2015U00CreateGroupHospitalRequest();
		}
	}
}