using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY8002U01GrdPHY8003Args : IContractArgs
    {
    protected bool Equals(PHY8002U01GrdPHY8003Args other)
    {
        return string.Equals(_kanjaNo, other._kanjaNo) && string.Equals(_fkOcsIrai, other._fkOcsIrai);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY8002U01GrdPHY8003Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_kanjaNo != null ? _kanjaNo.GetHashCode() : 0)*397) ^ (_fkOcsIrai != null ? _fkOcsIrai.GetHashCode() : 0);
        }
    }

    private String _kanjaNo;
        private String _fkOcsIrai;

        public String KanjaNo
        {
            get { return this._kanjaNo; }
            set { this._kanjaNo = value; }
        }

        public String FkOcsIrai
        {
            get { return this._fkOcsIrai; }
            set { this._fkOcsIrai = value; }
        }

        public PHY8002U01GrdPHY8003Args() { }

        public PHY8002U01GrdPHY8003Args(String kanjaNo, String fkOcsIrai)
        {
            this._kanjaNo = kanjaNo;
            this._fkOcsIrai = fkOcsIrai;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY8002U01GrdPHY8003Request();
        }
    }
}