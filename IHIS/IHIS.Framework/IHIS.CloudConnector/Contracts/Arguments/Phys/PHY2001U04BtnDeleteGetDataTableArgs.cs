using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04BtnDeleteGetDataTableArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04BtnDeleteGetDataTableArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_pkout1001, other._pkout1001);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04BtnDeleteGetDataTableArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
        }
    }

    private String _bunho;
        private String _pkout1001;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public PHY2001U04BtnDeleteGetDataTableArgs() { }

        public PHY2001U04BtnDeleteGetDataTableArgs(String bunho, String pkout1001)
        {
            this._bunho = bunho;
            this._pkout1001 = pkout1001;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04BtnDeleteGetDataTableRequest();
        }
    }
}