using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class ORDERTRANOcs1003UpdateArgs : IContractArgs
    {
        protected bool Equals(ORDERTRANOcs1003UpdateArgs other)
        {
            return Equals(_saveLayoutItem, other._saveLayoutItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ORDERTRANOcs1003UpdateArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_saveLayoutItem != null ? _saveLayoutItem.GetHashCode() : 0);
        }

        private List<ORDERTRANOcs1003UpdateInfo> _saveLayoutItem = new List<ORDERTRANOcs1003UpdateInfo>();

        public List<ORDERTRANOcs1003UpdateInfo> SaveLayoutItem
        {
            get { return this._saveLayoutItem; }
            set { this._saveLayoutItem = value; }
        }

        public ORDERTRANOcs1003UpdateArgs() { }

        public ORDERTRANOcs1003UpdateArgs(List<ORDERTRANOcs1003UpdateInfo> saveLayoutItem)
        {
            this._saveLayoutItem = saveLayoutItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANOcs1003UpdateRequest();
        }
    }
}