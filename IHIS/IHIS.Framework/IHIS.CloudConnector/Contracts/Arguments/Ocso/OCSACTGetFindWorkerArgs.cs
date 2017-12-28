using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCSACTGetFindWorkerArgs : IContractArgs
    {
    protected bool Equals(OCSACTGetFindWorkerArgs other)
    {
        return string.Equals(_colName, other._colName) && string.Equals(_arg1, other._arg1);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSACTGetFindWorkerArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_colName != null ? _colName.GetHashCode() : 0)*397) ^ (_arg1 != null ? _arg1.GetHashCode() : 0);
        }
    }

    private String _colName;
        private String _arg1;

        public String ColName
        {
            get { return this._colName; }
            set { this._colName = value; }
        }

        public String Arg1
        {
            get { return this._arg1; }
            set { this._arg1 = value; }
        }

        public OCSACTGetFindWorkerArgs() { }

        public OCSACTGetFindWorkerArgs(String colName, String arg1)
        {
            this._colName = colName;
            this._arg1 = arg1;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACTGetFindWorkerRequest();
        }
    }
}