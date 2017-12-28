using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM106USaveLayoutArgs : IContractArgs
    {
        protected bool Equals(ADM106USaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_userTrm, other._userTrm) && Equals(_inputList, other._inputList);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM106USaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userTrm != null ? _userTrm.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_inputList != null ? _inputList.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private String _userTrm;
        private List<ADM106UMakeQueryListItemInfo> _inputList = new List<ADM106UMakeQueryListItemInfo>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String UserTrm
        {
            get { return this._userTrm; }
            set { this._userTrm = value; }
        }

        public List<ADM106UMakeQueryListItemInfo> InputList
        {
            get { return this._inputList; }
            set { this._inputList = value; }
        }

        public ADM106USaveLayoutArgs() { }

        public ADM106USaveLayoutArgs(String userId, String userTrm, List<ADM106UMakeQueryListItemInfo> inputList)
        {
            this._userId = userId;
            this._userTrm = userTrm;
            this._inputList = inputList;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM106USaveLayoutRequest();
        }
    }
}