using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM102USaveLayoutArgs : IContractArgs
    {
        protected bool Equals(ADM102USaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && Equals(_inputList, other._inputList);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM102USaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_inputList != null ? _inputList.GetHashCode() : 0);
            }
        }

        private String _userId;
        private List<ADM102UGrdListItemInfo> _inputList = new List<ADM102UGrdListItemInfo>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<ADM102UGrdListItemInfo> InputList
        {
            get { return this._inputList; }
            set { this._inputList = value; }
        }

        public ADM102USaveLayoutArgs() { }

        public ADM102USaveLayoutArgs(String userId, List<ADM102UGrdListItemInfo> inputList)
        {
            this._userId = userId;
            this._inputList = inputList;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM102USaveLayoutRequest();
        }
    }
}