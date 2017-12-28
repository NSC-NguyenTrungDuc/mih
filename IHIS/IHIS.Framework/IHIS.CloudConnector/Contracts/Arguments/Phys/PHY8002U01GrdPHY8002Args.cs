using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY8002U01GrdPHY8002Args : IContractArgs
    {
    protected bool Equals(PHY8002U01GrdPHY8002Args other)
    {
        return string.Equals(_fkOcs, other._fkOcs);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY8002U01GrdPHY8002Args) obj);
    }

    public override int GetHashCode()
    {
        return (_fkOcs != null ? _fkOcs.GetHashCode() : 0);
    }

    private String _fkOcs;

        public String FkOcs
        {
            get { return this._fkOcs; }
            set { this._fkOcs = value; }
        }

        public PHY8002U01GrdPHY8002Args() { }

        public PHY8002U01GrdPHY8002Args(String fkOcs)
        {
            this._fkOcs = fkOcs;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY8002U01GrdPHY8002Request();
        }
    }
}