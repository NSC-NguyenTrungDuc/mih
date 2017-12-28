using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT1001U01LoadOUT0105Args : IContractArgs
    {
        protected bool Equals(NuroOUT1001U01LoadOUT0105Args other)
        {
            return string.Equals(_gongbiCode, other._gongbiCode) && string.Equals(_fkout1001, other._fkout1001);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01LoadOUT0105Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_gongbiCode != null ? _gongbiCode.GetHashCode() : 0)*397) ^ (_fkout1001 != null ? _fkout1001.GetHashCode() : 0);
            }
        }

        private String _gongbiCode;
        private String _fkout1001;

        public String GongbiCode
        {
            get { return this._gongbiCode; }
            set { this._gongbiCode = value; }
        }

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public NuroOUT1001U01LoadOUT0105Args() { }

        public NuroOUT1001U01LoadOUT0105Args(String gongbiCode, String fkout1001)
        {
            this._gongbiCode = gongbiCode;
            this._fkout1001 = fkout1001;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1001U01LoadOUT0105Request();
        }
    }
}
