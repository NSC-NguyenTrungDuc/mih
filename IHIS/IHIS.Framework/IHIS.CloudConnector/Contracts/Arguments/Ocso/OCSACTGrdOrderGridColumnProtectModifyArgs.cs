using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCSACTGrdOrderGridColumnProtectModifyArgs : IContractArgs
    {
    protected bool Equals(OCSACTGrdOrderGridColumnProtectModifyArgs other)
    {
        return string.Equals(_inOutGubun, other._inOutGubun) && string.Equals(_pkocs, other._pkocs);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSACTGrdOrderGridColumnProtectModifyArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_inOutGubun != null ? _inOutGubun.GetHashCode() : 0)*397) ^ (_pkocs != null ? _pkocs.GetHashCode() : 0);
        }
    }

    private String _inOutGubun;
        private String _pkocs;

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public String Pkocs
        {
            get { return this._pkocs; }
            set { this._pkocs = value; }
        }

        public OCSACTGrdOrderGridColumnProtectModifyArgs() { }

        public OCSACTGrdOrderGridColumnProtectModifyArgs(String inOutGubun, String pkocs)
        {
            this._inOutGubun = inOutGubun;
            this._pkocs = pkocs;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACTGrdOrderGridColumnProtectModifyRequest();
        }
    }
}