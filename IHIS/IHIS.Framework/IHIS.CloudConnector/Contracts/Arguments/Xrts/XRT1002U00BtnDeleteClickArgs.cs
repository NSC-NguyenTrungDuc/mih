using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT1002U00BtnDeleteClickArgs : IContractArgs
    {
    protected bool Equals(XRT1002U00BtnDeleteClickArgs other)
    {
        return string.Equals(_fkocs, other._fkocs);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT1002U00BtnDeleteClickArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_fkocs != null ? _fkocs.GetHashCode() : 0);
    }

    private String _fkocs;

        public String Fkocs
        {
            get { return this._fkocs; }
            set { this._fkocs = value; }
        }

        public XRT1002U00BtnDeleteClickArgs() { }

        public XRT1002U00BtnDeleteClickArgs(String fkocs)
        {
            this._fkocs = fkocs;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT1002U00BtnDeleteClickRequest();
        }
    }
}