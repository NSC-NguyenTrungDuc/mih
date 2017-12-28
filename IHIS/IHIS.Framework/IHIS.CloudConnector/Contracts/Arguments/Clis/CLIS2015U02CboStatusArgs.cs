using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U02CboStatusArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U02CboStatusArgs other)
        {
            return _isAll.Equals(other._isAll);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U02CboStatusArgs) obj);
        }

        public override int GetHashCode()
        {
            return _isAll.GetHashCode();
        }

        private Boolean _isAll;

        public Boolean IsAll
        {
            get { return this._isAll; }
            set { this._isAll = value; }
        }

        public CLIS2015U02CboStatusArgs() { }

        public CLIS2015U02CboStatusArgs(Boolean isAll)
        {
            this._isAll = isAll;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U02CboStatusRequest();
        }
    }
}