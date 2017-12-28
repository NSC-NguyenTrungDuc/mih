using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{ [Serializable]
    public class PHY8002U01GrdPHY8004Args : IContractArgs
    {
    protected bool Equals(PHY8002U01GrdPHY8004Args other)
    {
        return string.Equals(_fkOcsIrai, other._fkOcsIrai);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY8002U01GrdPHY8004Args) obj);
    }

    public override int GetHashCode()
    {
        return (_fkOcsIrai != null ? _fkOcsIrai.GetHashCode() : 0);
    }

    private String _fkOcsIrai;

        public String FkOcsIrai
        {
            get { return this._fkOcsIrai; }
            set { this._fkOcsIrai = value; }
        }

        public PHY8002U01GrdPHY8004Args() { }

        public PHY8002U01GrdPHY8004Args(String fkOcsIrai)
        {
            this._fkOcsIrai = fkOcsIrai;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY8002U01GrdPHY8004Request();
        }
    }
}