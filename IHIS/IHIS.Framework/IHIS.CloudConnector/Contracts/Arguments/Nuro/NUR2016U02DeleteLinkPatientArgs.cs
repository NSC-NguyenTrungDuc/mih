using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NUR2016U02DeleteLinkPatientArgs : IContractArgs
    {
        protected bool Equals(NUR2016U02DeleteLinkPatientArgs other)
        {
            return string.Equals(_bunho, other._bunho) && Equals(_linkPatItem, other._linkPatItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUR2016U02DeleteLinkPatientArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_linkPatItem != null ? _linkPatItem.GetHashCode() : 0);
            }
        }

        private String _bunho;
        private List<NUR2016U02DeleteLinkPatientInfo> _linkPatItem = new List<NUR2016U02DeleteLinkPatientInfo>();

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public List<NUR2016U02DeleteLinkPatientInfo> LinkPatItem
        {
            get { return this._linkPatItem; }
            set { this._linkPatItem = value; }
        }

        public NUR2016U02DeleteLinkPatientArgs() { }

        public NUR2016U02DeleteLinkPatientArgs(String bunho, List<NUR2016U02DeleteLinkPatientInfo> linkPatItem)
        {
            this._bunho = bunho;
            this._linkPatItem = linkPatItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR2016U02DeleteLinkPatientRequest();
        }
    }
}