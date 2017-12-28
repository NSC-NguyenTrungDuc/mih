using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class ORDERTRANInsertOcsTempArgs : IContractArgs
    {
        protected bool Equals(ORDERTRANInsertOcsTempArgs other)
        {
            return Equals(_inputInfo, other._inputInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ORDERTRANInsertOcsTempArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_inputInfo != null ? _inputInfo.GetHashCode() : 0);
        }

        private List<ORDERTRANInsertOcsTempInfo> _inputInfo = new List<ORDERTRANInsertOcsTempInfo>();

        public List<ORDERTRANInsertOcsTempInfo> InputInfo
        {
            get { return this._inputInfo; }
            set { this._inputInfo = value; }
        }

        public ORDERTRANInsertOcsTempArgs() { }

        public ORDERTRANInsertOcsTempArgs(List<ORDERTRANInsertOcsTempInfo> inputInfo)
        {
            this._inputInfo = inputInfo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANInsertOcsTempRequest();
        }
    }
}