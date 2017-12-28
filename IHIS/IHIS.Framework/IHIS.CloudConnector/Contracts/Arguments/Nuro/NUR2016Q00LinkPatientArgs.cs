using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NUR2016Q00LinkPatientArgs : IContractArgs
    {
        protected bool Equals(NUR2016Q00LinkPatientArgs other)
        {
            return Equals(_linkPatientItem, other._linkPatientItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUR2016Q00LinkPatientArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_linkPatientItem != null ? _linkPatientItem.GetHashCode() : 0);
        }

        private NUR2016Q00LinkPatientInfo _linkPatientItem;

        public NUR2016Q00LinkPatientInfo LinkPatientItem
        {
            get { return this._linkPatientItem; }
            set { this._linkPatientItem = value; }
        }

        public NUR2016Q00LinkPatientArgs() { }

        public NUR2016Q00LinkPatientArgs(NUR2016Q00LinkPatientInfo linkPatientItem)
        {
            this._linkPatientItem = linkPatientItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR2016Q00LinkPatientRequest();
        }
    }
}