using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL3020U02ResultMapGrdRsltArgs : IContractArgs
    {
        protected bool Equals(CPL3020U02ResultMapGrdRsltArgs other)
        {
            return string.Equals(_jangbiCode, other._jangbiCode) && string.Equals(_resultDate, other._resultDate) && string.Equals(_sampleId, other._sampleId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U02ResultMapGrdRsltArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_jangbiCode != null ? _jangbiCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resultDate != null ? _resultDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sampleId != null ? _sampleId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _jangbiCode;
        private String _resultDate;
        private String _sampleId;

        public String JangbiCode
        {
            get { return this._jangbiCode; }
            set { this._jangbiCode = value; }
        }

        public String ResultDate
        {
            get { return this._resultDate; }
            set { this._resultDate = value; }
        }

        public String SampleId
        {
            get { return this._sampleId; }
            set { this._sampleId = value; }
        }

        public CPL3020U02ResultMapGrdRsltArgs() { }

        public CPL3020U02ResultMapGrdRsltArgs(String jangbiCode, String resultDate, String sampleId)
        {
            this._jangbiCode = jangbiCode;
            this._resultDate = resultDate;
            this._sampleId = sampleId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3020U02ResultMapGrdRsltRequest();
        }
    }
}