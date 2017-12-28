using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL3020U02GrdResultArgs : IContractArgs
    {
        protected bool Equals(CPL3020U02GrdResultArgs other)
        {
            return string.Equals(_labNo, other._labNo) && string.Equals(_specimenSer, other._specimenSer) && string.Equals(_jundalGubun, other._jundalGubun);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U02GrdResultArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_labNo != null ? _labNo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_specimenSer != null ? _specimenSer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jundalGubun != null ? _jundalGubun.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _labNo;
        private String _specimenSer;
        private String _jundalGubun;

        public String LabNo
        {
            get { return this._labNo; }
            set { this._labNo = value; }
        }

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public String JundalGubun
        {
            get { return this._jundalGubun; }
            set { this._jundalGubun = value; }
        }

        public CPL3020U02GrdResultArgs() { }

        public CPL3020U02GrdResultArgs(String labNo, String specimenSer, String jundalGubun)
        {
            this._labNo = labNo;
            this._specimenSer = specimenSer;
            this._jundalGubun = jundalGubun;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3020U02GrdResultRequest();
        }
    }
}