using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using INJ0101U00GrdDetailInfo = IHIS.CloudConnector.Contracts.Models.Injs.INJ0101U00GrdDetailInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class INJ0101U00GrdDetailSaveLayoutArgs : IContractArgs
	{
        protected bool Equals(INJ0101U00GrdDetailSaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && Equals(_grdList, other._grdList);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ0101U00GrdDetailSaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_grdList != null ? _grdList.GetHashCode() : 0);
            }
        }

        private String _userId;
		private List<INJ0101U00GrdDetailInfo> _grdList = new List<INJ0101U00GrdDetailInfo>();

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public List<INJ0101U00GrdDetailInfo> GrdList
		{
			get { return this._grdList; }
			set { this._grdList = value; }
		}

		public INJ0101U00GrdDetailSaveLayoutArgs() { }

		public INJ0101U00GrdDetailSaveLayoutArgs(String userId, List<INJ0101U00GrdDetailInfo> grdList)
		{
			this._userId = userId;
			this._grdList = grdList;
		}

		public IExtensible GetRequestInstance()
		{
			return new INJ0101U00GrdDetailSaveLayoutRequest();
		}
	}
}