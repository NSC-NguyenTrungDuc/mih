using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY8002U01GetLayJissekiDataArgs : IContractArgs
    {
    protected bool Equals(PHY8002U01GetLayJissekiDataArgs other)
    {
        return string.Equals(_fkocs, other._fkocs) && string.Equals(_inOutGubun, other._inOutGubun);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY8002U01GetLayJissekiDataArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_fkocs != null ? _fkocs.GetHashCode() : 0)*397) ^ (_inOutGubun != null ? _inOutGubun.GetHashCode() : 0);
        }
    }

    private String _fkocs;
        private String _inOutGubun;

        public String Fkocs
        {
            get { return this._fkocs; }
            set { this._fkocs = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public PHY8002U01GetLayJissekiDataArgs() { }

        public PHY8002U01GetLayJissekiDataArgs(String fkocs, String inOutGubun)
        {
            this._fkocs = fkocs;
            this._inOutGubun = inOutGubun;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY8002U01GetLayJissekiDataRequest();
        }
    }
}