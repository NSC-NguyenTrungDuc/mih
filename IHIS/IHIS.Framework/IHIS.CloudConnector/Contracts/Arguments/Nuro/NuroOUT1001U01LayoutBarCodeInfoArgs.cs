using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT1001U01LayoutBarCodeInfoArgs : IContractArgs
    {
        protected bool Equals(NuroOUT1001U01LayoutBarCodeInfoArgs other)
        {
            return string.Equals(_bunho, other._bunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01LayoutBarCodeInfoArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_bunho != null ? _bunho.GetHashCode() : 0);
        }

        private String _bunho;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public NuroOUT1001U01LayoutBarCodeInfoArgs() { }

        public NuroOUT1001U01LayoutBarCodeInfoArgs(String bunho)
        {
            this._bunho = bunho;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1001U01BarCodeInfoRequest();
        }
    }
}
