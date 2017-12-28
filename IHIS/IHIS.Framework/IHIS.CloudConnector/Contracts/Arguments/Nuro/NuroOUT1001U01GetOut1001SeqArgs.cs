using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT1001U01GetOut1001SeqArgs : IContractArgs
    {
        protected bool Equals(NuroOUT1001U01GetOut1001SeqArgs other)
        {
            return string.Equals(_hospCodeLink, other._hospCodeLink) && _tabIsAll.Equals(other._tabIsAll);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01GetOut1001SeqArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0)*397) ^ _tabIsAll.GetHashCode();
            }
        }

        private String _hospCodeLink;
        private Boolean _tabIsAll;

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public Boolean TabIsAll
        {
            get { return this._tabIsAll; }
            set { this._tabIsAll = value; }
        }

        public NuroOUT1001U01GetOut1001SeqArgs() { }

        public NuroOUT1001U01GetOut1001SeqArgs(String hospCodeLink, Boolean tabIsAll)
        {
            this._hospCodeLink = hospCodeLink;
            this._tabIsAll = tabIsAll;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroOUT1001U01GetOut1001SeqRequest();
        }
    }
}