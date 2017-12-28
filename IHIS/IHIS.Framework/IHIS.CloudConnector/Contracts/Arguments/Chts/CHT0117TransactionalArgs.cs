using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using CHT0117GrdCHT0117InitListItemInfo = IHIS.CloudConnector.Contracts.Models.Chts.CHT0117GrdCHT0117InitListItemInfo;
using CHT0117GrdCHT0118InitListItemInfo = IHIS.CloudConnector.Contracts.Models.Chts.CHT0117GrdCHT0118InitListItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    [Serializable]
	public class CHT0117TransactionalArgs : IContractArgs
	{
        protected bool Equals(CHT0117TransactionalArgs other)
        {
            return Equals(_listInput1, other._listInput1) && Equals(_listInput2, other._listInput2) && string.Equals(_userId, other._userId) && string.Equals(_callerId, other._callerId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CHT0117TransactionalArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_listInput1 != null ? _listInput1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_listInput2 != null ? _listInput2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_callerId != null ? _callerId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private List<CHT0117GrdCHT0117InitListItemInfo> _listInput1 = new List<CHT0117GrdCHT0117InitListItemInfo>();
		private List<CHT0117GrdCHT0118InitListItemInfo> _listInput2 = new List<CHT0117GrdCHT0118InitListItemInfo>();
		private String _userId;
		private String _callerId;

		public List<CHT0117GrdCHT0117InitListItemInfo> ListInput1
		{
			get { return this._listInput1; }
			set { this._listInput1 = value; }
		}

		public List<CHT0117GrdCHT0118InitListItemInfo> ListInput2
		{
			get { return this._listInput2; }
			set { this._listInput2 = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String CallerId
		{
			get { return this._callerId; }
			set { this._callerId = value; }
		}

		public CHT0117TransactionalArgs() { }

		public CHT0117TransactionalArgs(List<CHT0117GrdCHT0117InitListItemInfo> listInput1, List<CHT0117GrdCHT0118InitListItemInfo> listInput2, String userId, String callerId)
		{
			this._listInput1 = listInput1;
			this._listInput2 = listInput2;
			this._userId = userId;
			this._callerId = callerId;
		}

		public IExtensible GetRequestInstance()
		{
			return new CHT0117TransactionalRequest();
		}
	}
}