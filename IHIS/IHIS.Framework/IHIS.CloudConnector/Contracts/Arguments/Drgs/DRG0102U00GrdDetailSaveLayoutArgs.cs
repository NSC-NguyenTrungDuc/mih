using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using DRG0102U00GrdDetailInfo = IHIS.CloudConnector.Contracts.Models.Drgs.DRG0102U00GrdDetailInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG0102U00GrdDetailSaveLayoutArgs : IContractArgs
	{
        protected bool Equals(DRG0102U00GrdDetailSaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && Equals(_inputList, other._inputList);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG0102U00GrdDetailSaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_inputList != null ? _inputList.GetHashCode() : 0);
            }
        }

        private String _userId;
		private List<DRG0102U00GrdDetailInfo> _inputList = new List<DRG0102U00GrdDetailInfo>();

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public List<DRG0102U00GrdDetailInfo> InputList
		{
			get { return this._inputList; }
			set { this._inputList = value; }
		}

		public DRG0102U00GrdDetailSaveLayoutArgs() { }

		public DRG0102U00GrdDetailSaveLayoutArgs(String userId, List<DRG0102U00GrdDetailInfo> inputList)
		{
			this._userId = userId;
			this._inputList = inputList;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRG0102U00GrdDetailSaveLayoutRequest();
		}
	}
}