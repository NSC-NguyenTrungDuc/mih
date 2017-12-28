using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT1001U01CheckYArgs : IContractArgs
    {
        protected bool Equals(NuroOUT1001U01CheckYArgs other)
        {
            return string.Equals(_pkout1001, other._pkout1001);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01CheckYArgs) obj);
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

        public NuroOUT1001U01CheckYArgs() { }

        public NuroOUT1001U01CheckYArgs(String pkout1001)
        {
            this._pkout1001 = pkout1001;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1001U01CheckYRequest();
        }
    }
}
