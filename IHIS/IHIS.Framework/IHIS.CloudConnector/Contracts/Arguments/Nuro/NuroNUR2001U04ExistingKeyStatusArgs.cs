using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroNUR2001U04ExistingKeyStatusArgs : IContractArgs
    {
        protected bool Equals(NuroNUR2001U04ExistingKeyStatusArgs other)
        {
            return string.Equals(_pkout1001, other._pkout1001);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroNUR2001U04ExistingKeyStatusArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
        }

        private string _pkout1001;

        public string Pkout1001
        {
            get { return _pkout1001; }
            set { _pkout1001 = value; }
        }

        public NuroNUR2001U04ExistingKeyStatusArgs(string pkout1001)
        {
            _pkout1001 = pkout1001;
        }

        public NuroNUR2001U04ExistingKeyStatusArgs()
        {
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroNUR2001U04ExistingKeyStatusRequest();
        }
    }
}
