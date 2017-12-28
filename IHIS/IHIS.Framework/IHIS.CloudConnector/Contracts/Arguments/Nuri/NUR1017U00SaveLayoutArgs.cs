using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using NUR1017U00GrdNUR1017ListItemInfo = IHIS.CloudConnector.Contracts.Models.Nuri.NUR1017U00GrdNUR1017ListItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuri
{
    [Serializable]
	public class NUR1017U00SaveLayoutArgs : IContractArgs
	{
        protected bool Equals(NUR1017U00SaveLayoutArgs other)
        {
            return Equals(_grdList, other._grdList) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUR1017U00SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_grdList != null ? _grdList.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            }
        }

        private List<NUR1017U00GrdNUR1017ListItemInfo> _grdList = new List<NUR1017U00GrdNUR1017ListItemInfo>();
		private String _userId;

		public List<NUR1017U00GrdNUR1017ListItemInfo> GrdList
		{
			get { return this._grdList; }
			set { this._grdList = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public NUR1017U00SaveLayoutArgs() { }

		public NUR1017U00SaveLayoutArgs(List<NUR1017U00GrdNUR1017ListItemInfo> grdList, String userId)
		{
			this._grdList = grdList;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new NUR1017U00SaveLayoutRequest();
		}
	}
}