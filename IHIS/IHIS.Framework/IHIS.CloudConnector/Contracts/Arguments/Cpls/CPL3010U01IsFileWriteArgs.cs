using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL3010U01IsFileWriteArgs : IContractArgs
    {
        protected bool Equals(CPL3010U01IsFileWriteArgs other)
        {
            return string.Equals(_totalPa, other._totalPa) && string.Equals(_userId, other._userId) && Equals(_fileWriteLst, other._fileWriteLst);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3010U01IsFileWriteArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_totalPa != null ? _totalPa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fileWriteLst != null ? _fileWriteLst.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _totalPa;
        private String _userId;
        private List<CPL3010U01IsFileWriteInfo> _fileWriteLst = new List<CPL3010U01IsFileWriteInfo>();

        public String TotalPa
        {
            get { return this._totalPa; }
            set { this._totalPa = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<CPL3010U01IsFileWriteInfo> FileWriteLst
        {
            get { return this._fileWriteLst; }
            set { this._fileWriteLst = value; }
        }

        public CPL3010U01IsFileWriteArgs() { }

        public CPL3010U01IsFileWriteArgs(String totalPa, String userId, List<CPL3010U01IsFileWriteInfo> fileWriteLst)
        {
            this._totalPa = totalPa;
            this._userId = userId;
            this._fileWriteLst = fileWriteLst;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3010U01IsFileWriteRequest();
        }
    }
}