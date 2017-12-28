using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04BtnDeleteExistYnArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04BtnDeleteExistYnArgs other)
    {
        return string.Equals(_pkout1001, other._pkout1001);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04BtnDeleteExistYnArgs) obj);
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

        public PHY2001U04BtnDeleteExistYnArgs() { }

        public PHY2001U04BtnDeleteExistYnArgs(String pkout1001)
        {
            this._pkout1001 = pkout1001;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04BtnDeleteExistYnRequest();
        }
    }
}