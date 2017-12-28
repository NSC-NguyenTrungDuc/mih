using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NUR2016U02GrdListArgs : IContractArgs
    {
        protected bool Equals(NUR2016U02GrdListArgs other)
        {
            return string.Equals(_bunho, other._bunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUR2016U02GrdListArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_bunho != null ? _bunho.GetHashCode() : 0);
        }

        private String _bunho;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public NUR2016U02GrdListArgs() { }

        public NUR2016U02GrdListArgs(String bunho)
        {
            this._bunho = bunho;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR2016U02GrdListRequest();
        }
    }
}