using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0311Q00CboSetPartArgs : IContractArgs
    {
    protected bool Equals(OCS0311Q00CboSetPartArgs other)
    {
        return string.Equals(_setTable, other._setTable);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0311Q00CboSetPartArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_setTable != null ? _setTable.GetHashCode() : 0);
    }

    private String _setTable;

        public String SetTable
        {
            get { return this._setTable; }
            set { this._setTable = value; }
        }

        public OCS0311Q00CboSetPartArgs() { }

        public OCS0311Q00CboSetPartArgs(String setTable)
        {
            this._setTable = setTable;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0311Q00CboSetPartRequest();
        }
    }
}