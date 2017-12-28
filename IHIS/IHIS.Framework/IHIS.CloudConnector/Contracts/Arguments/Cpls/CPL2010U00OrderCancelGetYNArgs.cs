using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL2010U00OrderCancelGetYNArgs : IContractArgs
    {
        protected bool Equals(CPL2010U00OrderCancelGetYNArgs other)
        {
            return string.Equals(_fkocs1003, other._fkocs1003);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL2010U00OrderCancelGetYNArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_fkocs1003 != null ? _fkocs1003.GetHashCode() : 0);
        }

        private String _fkocs1003;

        public String Fkocs1003
        {
            get { return this._fkocs1003; }
            set { this._fkocs1003 = value; }
        }

        public CPL2010U00OrderCancelGetYNArgs() { }

        public CPL2010U00OrderCancelGetYNArgs(String fkocs1003)
        {
            this._fkocs1003 = fkocs1003;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010U00OrderCancelGetYNRequest();
        }
    }
}