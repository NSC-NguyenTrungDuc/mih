using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuri;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using NUR1016U00GrdNUR1016ListItemInfo = IHIS.CloudConnector.Contracts.Models.Nuri.NUR1016U00GrdNUR1016ListItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuri
{
    [Serializable]
	public class NUR1016U00PrNurAlergyMappingArgs : IContractArgs
	{
        protected bool Equals(NUR1016U00PrNurAlergyMappingArgs other)
        {
            return Equals(_grdNUR1016List, other._grdNUR1016List) && string.Equals(_bunho, other._bunho) && string.Equals(_userId, other._userId) && string.Equals(_tableId, other._tableId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUR1016U00PrNurAlergyMappingArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_grdNUR1016List != null ? _grdNUR1016List.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_tableId != null ? _tableId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private List<NUR1016U00GrdNUR1016ListItemInfo> _grdNUR1016List = new List<NUR1016U00GrdNUR1016ListItemInfo>();
		private String _bunho;
		private String _userId;
		private String _tableId;

		public List<NUR1016U00GrdNUR1016ListItemInfo> GrdNUR1016List
		{
			get { return this._grdNUR1016List; }
			set { this._grdNUR1016List = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String TableId
		{
			get { return this._tableId; }
			set { this._tableId = value; }
		}

		public NUR1016U00PrNurAlergyMappingArgs() { }

		public NUR1016U00PrNurAlergyMappingArgs(List<NUR1016U00GrdNUR1016ListItemInfo> grdNUR1016List, String bunho, String userId, String tableId)
		{
			this._grdNUR1016List = grdNUR1016List;
			this._bunho = bunho;
			this._userId = userId;
			this._tableId = tableId;
		}

		public IExtensible GetRequestInstance()
		{
			return new NUR1016U00PrNurAlergyMappingRequest();
		}
	}
}