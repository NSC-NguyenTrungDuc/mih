using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class ComBizGetFindWorkerArgs : IContractArgs
    {
        protected bool Equals(ComBizGetFindWorkerArgs other)
        {
            return string.Equals(_colName, other._colName) && string.Equals(_argu1, other._argu1) && string.Equals(_find1, other._find1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComBizGetFindWorkerArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_colName != null ? _colName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_argu1 != null ? _argu1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _colName;
        private String _argu1;
        private String _find1;

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

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public ComBizGetFindWorkerArgs() { }

        public ComBizGetFindWorkerArgs(String colName, String argu1, String find1)
        {
            this._colName = colName;
            this._argu1 = argu1;
            this._find1 = find1;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ComBizGetFindWorkerRequest();
        }
    }
}