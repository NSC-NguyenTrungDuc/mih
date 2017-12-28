using System;
using IHIS.CloudConnector.Contracts.Models.Outs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Outs
{[Serializable]
    public class OUT1001P03GrdAfterJubsuArgs : IContractArgs
    {
    protected bool Equals(OUT1001P03GrdAfterJubsuArgs other)
    {
        return string.Equals(_ioGubun, other._ioGubun) && string.Equals(_bunho, other._bunho);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OUT1001P03GrdAfterJubsuArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_ioGubun != null ? _ioGubun.GetHashCode() : 0)*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
        }
    }

    private String _ioGubun;
        private String _bunho;

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public OUT1001P03GrdAfterJubsuArgs() { }

        public OUT1001P03GrdAfterJubsuArgs(String ioGubun, String bunho)
        {
            this._ioGubun = ioGubun;
            this._bunho = bunho;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OUT1001P03GrdAfterJubsuRequest();
        }
    }
}