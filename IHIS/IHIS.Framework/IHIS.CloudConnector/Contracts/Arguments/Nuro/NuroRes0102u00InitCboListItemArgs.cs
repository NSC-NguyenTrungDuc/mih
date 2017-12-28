using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroRes0102u00InitCboListItemArgs : IContractArgs
    {
        protected bool Equals(NuroRes0102u00InitCboListItemArgs other)
        {
            return string.Equals(_comingDate, other._comingDate) && string.Equals(_codeType, other._codeType) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRes0102u00InitCboListItemArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_comingDate != null ? _comingDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _comingDate;
        private String _codeType;
        private String _hospCode;

        public String ComingDate
        {
            get { return this._comingDate; }
            set { this._comingDate = value; }
        }

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public NuroRes0102u00InitCboListItemArgs() { }

        public NuroRes0102u00InitCboListItemArgs(String comingDate, String codeType, String hospCode)
        {
            this._comingDate = comingDate;
            this._codeType = codeType;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroRes0102u00InitCboListItemRequest();
        }
    }
}