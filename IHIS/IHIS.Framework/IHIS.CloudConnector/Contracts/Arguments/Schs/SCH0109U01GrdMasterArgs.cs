using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
    public class SCH0109U01GrdMasterArgs : IContractArgs
    {
    protected bool Equals(SCH0109U01GrdMasterArgs other)
    {
        return string.Equals(_codeType, other._codeType) && string.Equals(_codeTypeName, other._codeTypeName);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH0109U01GrdMasterArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_codeType != null ? _codeType.GetHashCode() : 0)*397) ^ (_codeTypeName != null ? _codeTypeName.GetHashCode() : 0);
        }
    }

    private String _codeType;
        private String _codeTypeName;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String CodeTypeName
        {
            get { return this._codeTypeName; }
            set { this._codeTypeName = value; }
        }

        public SCH0109U01GrdMasterArgs() { }

        public SCH0109U01GrdMasterArgs(String codeType, String codeTypeName)
        {
            this._codeType = codeType;
            this._codeTypeName = codeTypeName;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SCH0109U01GrdMasterRequest();
        }
    }
}