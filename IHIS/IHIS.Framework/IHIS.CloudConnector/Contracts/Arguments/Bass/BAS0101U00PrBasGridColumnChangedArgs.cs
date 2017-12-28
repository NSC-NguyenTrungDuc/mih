using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0101U00PrBasGridColumnChangedArgs : IContractArgs
    {
        protected bool Equals(BAS0101U00PrBasGridColumnChangedArgs other)
        {
            return string.Equals(_masterCheck, other._masterCheck) && string.Equals(_codeType, other._codeType) && string.Equals(_colId, other._colId) && string.Equals(_error, other._error);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0101U00PrBasGridColumnChangedArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_masterCheck != null ? _masterCheck.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_colId != null ? _colId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_error != null ? _error.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _masterCheck;
        private String _codeType;
        private String _colId;
        private String _error;

        public String MasterCheck
        {
            get { return this._masterCheck; }
            set { this._masterCheck = value; }
        }

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String ColId
        {
            get { return this._colId; }
            set { this._colId = value; }
        }

        public String Error
        {
            get { return this._error; }
            set { this._error = value; }
        }

        public BAS0101U00PrBasGridColumnChangedArgs() { }

        public BAS0101U00PrBasGridColumnChangedArgs(String masterCheck, String codeType, String colId, String error)
        {
            this._masterCheck = masterCheck;
            this._codeType = codeType;
            this._colId = colId;
            this._error = error;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0101U00PrBasGridColumnChangedRequest();
        }
    }
}