using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U09CheckSmoCodeOnDeleteArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U09CheckSmoCodeOnDeleteArgs other)
        {
            return string.Equals(_clisSmoId, other._clisSmoId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U09CheckSmoCodeOnDeleteArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_clisSmoId != null ? _clisSmoId.GetHashCode() : 0);
        }

        private String _clisSmoId;

        public String ClisSmoId
        {
            get { return this._clisSmoId; }
            set { this._clisSmoId = value; }
        }

        public CLIS2015U09CheckSmoCodeOnDeleteArgs() { }

        public CLIS2015U09CheckSmoCodeOnDeleteArgs(String clisSmoId)
        {
            this._clisSmoId = clisSmoId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U09CheckSmoCodeOnDeleteRequest();
        }
    }
}