using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL0108U00GrdMasterArgs : IContractArgs
    {
        protected bool Equals(CPL0108U00GrdMasterArgs other)
        {
            return string.Equals(_codeTypeName, other._codeTypeName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0108U00GrdMasterArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_codeTypeName != null ? _codeTypeName.GetHashCode() : 0);
        }

        private String _codeTypeName;

        public String CodeTypeName
        {
            get { return this._codeTypeName; }
            set { this._codeTypeName = value; }
        }

        public CPL0108U00GrdMasterArgs() { }

        public CPL0108U00GrdMasterArgs(String codeTypeName)
        {
            this._codeTypeName = codeTypeName;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL0108U00GrdMasterRequest();
        }
    }
}