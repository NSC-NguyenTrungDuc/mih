using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U09SaveArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U09SaveArgs other)
        {
            return Equals(_dt, other._dt);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U09SaveArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_dt != null ? _dt.GetHashCode() : 0);
        }

        private List<CLIS2015U09ItemInfo> _dt = new List<CLIS2015U09ItemInfo>();

        public List<CLIS2015U09ItemInfo> Dt
        {
            get { return this._dt; }
            set { this._dt = value; }
        }

        public CLIS2015U09SaveArgs() { }

        public CLIS2015U09SaveArgs(List<CLIS2015U09ItemInfo> dt)
        {
            this._dt = dt;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U09SaveRequest();
        }
    }
}