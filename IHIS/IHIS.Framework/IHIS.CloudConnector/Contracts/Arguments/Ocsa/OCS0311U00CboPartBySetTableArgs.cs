using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0311U00CboPartBySetTableArgs : IContractArgs
    {
    protected bool Equals(OCS0311U00CboPartBySetTableArgs other)
    {
        return string.Equals(_currGroupId, other._currGroupId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0311U00CboPartBySetTableArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_currGroupId != null ? _currGroupId.GetHashCode() : 0);
    }

    private String _currGroupId;

        public String CurrGroupId
        {
            get { return this._currGroupId; }
            set { this._currGroupId = value; }
        }

        public OCS0311U00CboPartBySetTableArgs() { }

        public OCS0311U00CboPartBySetTableArgs(String currGroupId)
        {
            this._currGroupId = currGroupId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0311U00CboPartBySetTableRequest();
        }
    }
}