using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class RES1001U00CheckUsingOrcaArgs : IContractArgs
    {
        protected bool Equals(RES1001U00CheckUsingOrcaArgs other)
        {
            return string.Equals(_hospCodeLink, other._hospCodeLink);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RES1001U00CheckUsingOrcaArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
        }

        private String _hospCodeLink;

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public RES1001U00CheckUsingOrcaArgs() { }

        public RES1001U00CheckUsingOrcaArgs(String hospCodeLink)
        {
            this._hospCodeLink = hospCodeLink;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.RES1001U00CheckUsingOrcaRequest();
        }
    }
}