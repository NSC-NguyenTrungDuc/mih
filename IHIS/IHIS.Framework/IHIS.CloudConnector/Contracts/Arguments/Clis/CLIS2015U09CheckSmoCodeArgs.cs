using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U09CheckSmoCodeArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U09CheckSmoCodeArgs other)
        {
            return string.Equals(_smoCode, other._smoCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U09CheckSmoCodeArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_smoCode != null ? _smoCode.GetHashCode() : 0);
        }

        private String _smoCode;

        public String SmoCode
        {
            get { return this._smoCode; }
            set { this._smoCode = value; }
        }

        public CLIS2015U09CheckSmoCodeArgs() { }

        public CLIS2015U09CheckSmoCodeArgs(String smoCode)
        {
            this._smoCode = smoCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U09CheckSmoCodeRequest();
        }
    }
}