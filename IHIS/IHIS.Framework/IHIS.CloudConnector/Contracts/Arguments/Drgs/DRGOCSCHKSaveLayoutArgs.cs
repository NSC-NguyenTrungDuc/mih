using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using DRGOCSCHKGrdOcsChkInfo = IHIS.CloudConnector.Contracts.Models.Drgs.DRGOCSCHKGrdOcsChkInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRGOCSCHKSaveLayoutArgs : IContractArgs
	{
        protected bool Equals(DRGOCSCHKSaveLayoutArgs other)
        {
            return Equals(_inputList, other._inputList) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRGOCSCHKSaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_inputList != null ? _inputList.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            }
        }

        private List<DRGOCSCHKGrdOcsChkInfo> _inputList = new List<DRGOCSCHKGrdOcsChkInfo>();
		private String _userId;

		public List<DRGOCSCHKGrdOcsChkInfo> InputList
		{
			get { return this._inputList; }
			set { this._inputList = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public DRGOCSCHKSaveLayoutArgs() { }

		public DRGOCSCHKSaveLayoutArgs(List<DRGOCSCHKGrdOcsChkInfo> inputList, String userId)
		{
			this._inputList = inputList;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRGOCSCHKSaveLayoutRequest();
		}
	}
}