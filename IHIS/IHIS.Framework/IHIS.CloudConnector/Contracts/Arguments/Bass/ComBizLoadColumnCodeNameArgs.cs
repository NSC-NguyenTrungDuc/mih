using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class ComBizLoadColumnCodeNameArgs : IContractArgs
    {
        protected bool Equals(ComBizLoadColumnCodeNameArgs other)
        {
            return string.Equals(_colName, other._colName) && string.Equals(_argu1, other._argu1) && string.Equals(_argu2, other._argu2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComBizLoadColumnCodeNameArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_colName != null ? _colName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_argu1 != null ? _argu1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_argu2 != null ? _argu2.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _colName;
        private String _argu1;
        private String _argu2;

        public String ColName
        {
            get { return this._colName; }
            set { this._colName = value; }
        }

        public String Argu1
        {
            get { return this._argu1; }
            set { this._argu1 = value; }
        }

        public String Argu2
        {
            get { return this._argu2; }
            set { this._argu2 = value; }
        }

        public ComBizLoadColumnCodeNameArgs() { }

        public ComBizLoadColumnCodeNameArgs(String colName, String argu1, String argu2)
        {
            this._colName = colName;
            this._argu1 = argu1;
            this._argu2 = argu2;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ComBizLoadColumnCodeNameRequest();
        }
    }
}