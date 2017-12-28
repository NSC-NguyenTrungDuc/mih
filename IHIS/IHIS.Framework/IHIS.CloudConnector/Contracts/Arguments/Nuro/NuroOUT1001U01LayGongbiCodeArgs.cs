using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT1001U01LayGongbiCodeArgs : IContractArgs
    {
        protected bool Equals(NuroOUT1001U01LayGongbiCodeArgs other)
        {
            return string.Equals(_pkout1001, other._pkout1001);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01LayGongbiCodeArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
        }

        private String _pkout1001;

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public NuroOUT1001U01LayGongbiCodeArgs() { }

        public NuroOUT1001U01LayGongbiCodeArgs(String pkout1001)
        {
            this._pkout1001 = pkout1001;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1001U01LayGongbiCodeRequest();
        }
    }
}
