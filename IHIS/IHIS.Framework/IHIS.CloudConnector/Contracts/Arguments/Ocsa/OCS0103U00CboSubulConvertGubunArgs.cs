using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    [Serializable]
    public class OCS0103U00CboSubulConvertGubunArgs : IContractArgs
    {
        protected bool Equals(OCS0103U00CboSubulConvertGubunArgs other)
        {
            return string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OCS0103U00CboSubulConvertGubunArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_hospCode != null ? _hospCode.GetHashCode() : 0);
        }

        private String _hospCode;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0103U00CboSubulConvertGubunArgs() { }

        public OCS0103U00CboSubulConvertGubunArgs(String hospCode)
        {
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U00CboSubulConvertGubunRequest();
        }
    }
}