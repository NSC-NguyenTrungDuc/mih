using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
    public class ComboADM1110GetByColNameArgs : IContractArgs
    {
        protected bool Equals(ComboADM1110GetByColNameArgs other)
        {
            return string.Equals(_colName, other._colName) && _getAll.Equals(other._getAll) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComboADM1110GetByColNameArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_colName != null ? _colName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _getAll.GetHashCode();
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _colName;
        private Boolean _getAll;
        private String _hospCode;

        public String ColName
        {
            get { return this._colName; }
            set { this._colName = value; }
        }

        public Boolean GetAll
        {
            get { return this._getAll; }
            set { this._getAll = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public ComboADM1110GetByColNameArgs() { }

        public ComboADM1110GetByColNameArgs(String colName, Boolean getAll, String hospCode)
        {
            this._colName = colName;
            this._getAll = getAll;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ComboADM1110GetByColNameRequest();
        }
    }
}