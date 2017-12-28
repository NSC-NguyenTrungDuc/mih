using System;
using IHIS.CloudConnector.Contracts.Models.Outs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Outs
{[Serializable]
    public class OUT1001P03GrdBeforeOrderArgs : IContractArgs
    {
    protected bool Equals(OUT1001P03GrdBeforeOrderArgs other)
    {
        return string.Equals(_ioGubun, other._ioGubun) && string.Equals(_bunho, other._bunho) && string.Equals(_naewonKey, other._naewonKey);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OUT1001P03GrdBeforeOrderArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonKey != null ? _naewonKey.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _ioGubun;
        private String _bunho;
        private String _naewonKey;

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

        public String NaewonKey
        {
            get { return this._naewonKey; }
            set { this._naewonKey = value; }
        }

        public OUT1001P03GrdBeforeOrderArgs() { }

        public OUT1001P03GrdBeforeOrderArgs(String ioGubun, String bunho, String naewonKey)
        {
            this._ioGubun = ioGubun;
            this._bunho = bunho;
            this._naewonKey = naewonKey;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OUT1001P03GrdBeforeOrderRequest();
        }
    }
}