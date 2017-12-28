using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class CboAvgTimeArgs : IContractArgs
    {
        protected bool Equals(CboAvgTimeArgs other)
        {
            return string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CboAvgTimeArgs) obj);
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

        public CboAvgTimeArgs() { }

        public CboAvgTimeArgs(String hospCode)
        {
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CboAvgTimeRequest();
        }
    }
}