using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using MultiResultViewGrdSigeyulInfo = IHIS.CloudConnector.Contracts.Models.Cpls.MultiResultViewGrdSigeyulInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class MultiResultViewGetJubsuSigeyulArgs : IContractArgs
	{
        protected bool Equals(MultiResultViewGetJubsuSigeyulArgs other)
        {
            return Equals(_grdSigeyulItem, other._grdSigeyulItem) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MultiResultViewGetJubsuSigeyulArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_grdSigeyulItem != null ? _grdSigeyulItem.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            }
        }

        private List<MultiResultViewGrdSigeyulInfo> _grdSigeyulItem = new List<MultiResultViewGrdSigeyulInfo>();
		private String _userId;

		public List<MultiResultViewGrdSigeyulInfo> GrdSigeyulItem
		{
			get { return this._grdSigeyulItem; }
			set { this._grdSigeyulItem = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public MultiResultViewGetJubsuSigeyulArgs() { }

		public MultiResultViewGetJubsuSigeyulArgs(List<MultiResultViewGrdSigeyulInfo> grdSigeyulItem, String userId)
		{
			this._grdSigeyulItem = grdSigeyulItem;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new MultiResultViewGetJubsuSigeyulRequest();
		}
	}
}