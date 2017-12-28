using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0803U00grdOCS0804Args : IContractArgs
    {
    protected bool Equals(OCS0803U00grdOCS0804Args other)
    {
        return string.Equals(_patStatusGr, other._patStatusGr);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0803U00grdOCS0804Args) obj);
    }

    public override int GetHashCode()
    {
        return (_patStatusGr != null ? _patStatusGr.GetHashCode() : 0);
    }

    private String _patStatusGr;

        public String PatStatusGr
        {
            get { return this._patStatusGr; }
            set { this._patStatusGr = value; }
        }

        public OCS0803U00grdOCS0804Args() { }

        public OCS0803U00grdOCS0804Args(String patStatusGr)
        {
            this._patStatusGr = patStatusGr;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0803U00grdOCS0804Request();
        }
    }
}