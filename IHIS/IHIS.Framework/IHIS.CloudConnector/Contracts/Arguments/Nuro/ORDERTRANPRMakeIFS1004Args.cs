using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class ORDERTRANPRMakeIFS1004Args : IContractArgs
    {
        protected bool Equals(ORDERTRANPRMakeIFS1004Args other)
        {
            return Equals(_inputInfo, other._inputInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ORDERTRANPRMakeIFS1004Args) obj);
        }

        public override int GetHashCode()
        {
            return (_inputInfo != null ? _inputInfo.GetHashCode() : 0);
        }

        private List<ORDERTRANPRMakeIFS1004Info> _inputInfo = new List<ORDERTRANPRMakeIFS1004Info>();

        public List<ORDERTRANPRMakeIFS1004Info> InputInfo
        {
            get { return this._inputInfo; }
            set { this._inputInfo = value; }
        }

        public ORDERTRANPRMakeIFS1004Args() { }

        public ORDERTRANPRMakeIFS1004Args(List<ORDERTRANPRMakeIFS1004Info> inputInfo)
        {
            this._inputInfo = inputInfo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANPRMakeIFS1004Request();
        }
    }
}