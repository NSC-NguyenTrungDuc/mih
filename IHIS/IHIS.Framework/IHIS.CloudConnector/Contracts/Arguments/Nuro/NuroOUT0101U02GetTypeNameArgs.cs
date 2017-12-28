using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT0101U02GetTypeNameArgs : IContractArgs
    {
        protected bool Equals(NuroOUT0101U02GetTypeNameArgs other)
        {
            return string.Equals(_typeCode, other._typeCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT0101U02GetTypeNameArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_typeCode != null ? _typeCode.GetHashCode() : 0);
        }

        private String _typeCode;

        public String TypeCode
        {
            get { return this._typeCode; }
            set { this._typeCode = value; }
        }

        public NuroOUT0101U02GetTypeNameArgs() { }

        public NuroOUT0101U02GetTypeNameArgs(String typeCode)
        {
            this._typeCode = typeCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroOUT0101U02GetTypeNameRequest();
        }
    }
}