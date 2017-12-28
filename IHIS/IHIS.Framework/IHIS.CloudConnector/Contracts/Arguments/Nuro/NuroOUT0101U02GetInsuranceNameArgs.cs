using System;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.NURO
{
    [Serializable]
    public class NuroOUT0101U02GetInsuranceNameArgs : IContractArgs
    {
        protected bool Equals(NuroOUT0101U02GetInsuranceNameArgs other)
        {
            return string.Equals(_gongbiCode, other._gongbiCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT0101U02GetInsuranceNameArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_gongbiCode != null ? _gongbiCode.GetHashCode() : 0);
        }

        private String _gongbiCode;

        public String GongbiCode
        {
            get { return this._gongbiCode; }
            set { this._gongbiCode = value; }
        }

        public NuroOUT0101U02GetInsuranceNameArgs() { }

        public NuroOUT0101U02GetInsuranceNameArgs(String gongbiCode)
        {
            this._gongbiCode = gongbiCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroOUT0101U02GetInsuranceNameRequest();
        }
    }
}