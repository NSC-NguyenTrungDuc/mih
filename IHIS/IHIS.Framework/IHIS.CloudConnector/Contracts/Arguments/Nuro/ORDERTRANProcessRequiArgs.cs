using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class ORDERTRANProcessRequiArgs : IContractArgs
    {
        protected bool Equals(ORDERTRANProcessRequiArgs other)
        {
            return Equals(_inputList, other._inputList);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ORDERTRANProcessRequiArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_inputList != null ? _inputList.GetHashCode() : 0);
        }

        private List<ORDERTRANProcessRequiInfo> _inputList = new List<ORDERTRANProcessRequiInfo>();

        public List<ORDERTRANProcessRequiInfo> InputList
        {
            get { return this._inputList; }
            set { this._inputList = value; }
        }

        public ORDERTRANProcessRequiArgs() { }

        public ORDERTRANProcessRequiArgs(List<ORDERTRANProcessRequiInfo> inputList)
        {
            this._inputList = inputList;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANProcessRequiRequest();
        }
    }
}