using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL2010U00OrderCancelExecuteArgs : IContractArgs
    {
        protected bool Equals(CPL2010U00OrderCancelExecuteArgs other)
        {
            return string.Equals(_pkcpl2010, other._pkcpl2010) && string.Equals(_specimenSer, other._specimenSer) && string.Equals(_fkocs1003, other._fkocs1003);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL2010U00OrderCancelExecuteArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_pkcpl2010 != null ? _pkcpl2010.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_specimenSer != null ? _specimenSer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fkocs1003 != null ? _fkocs1003.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _pkcpl2010;
        private String _specimenSer;
        private String _fkocs1003;

        public String Pkcpl2010
        {
            get { return this._pkcpl2010; }
            set { this._pkcpl2010 = value; }
        }

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public String Fkocs1003
        {
            get { return this._fkocs1003; }
            set { this._fkocs1003 = value; }
        }

        public CPL2010U00OrderCancelExecuteArgs() { }

        public CPL2010U00OrderCancelExecuteArgs(String pkcpl2010, String specimenSer, String fkocs1003)
        {
            this._pkcpl2010 = pkcpl2010;
            this._specimenSer = specimenSer;
            this._fkocs1003 = fkocs1003;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010U00OrderCancelExecuteRequest();
        }
    }
}