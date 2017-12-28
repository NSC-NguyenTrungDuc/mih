using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL3010U01GrdPaArgs : IContractArgs
    {
        protected bool Equals(CPL3010U01GrdPaArgs other)
        {
            return _cbxJubsuDate.Equals(other._cbxJubsuDate) && string.Equals(_fromPartJubsuDate, other._fromPartJubsuDate) && string.Equals(_toPartJubsuDate, other._toPartJubsuDate) && string.Equals(_fromSeq, other._fromSeq) && string.Equals(_toSeq, other._toSeq) && string.Equals(_fromSpecimenSer, other._fromSpecimenSer) && string.Equals(_toSpecimenSer, other._toSpecimenSer) && string.Equals(_uitakCode, other._uitakCode) && string.Equals(_centerCode, other._centerCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3010U01GrdPaArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _cbxJubsuDate.GetHashCode();
                hashCode = (hashCode*397) ^ (_fromPartJubsuDate != null ? _fromPartJubsuDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toPartJubsuDate != null ? _toPartJubsuDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fromSeq != null ? _fromSeq.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toSeq != null ? _toSeq.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fromSpecimenSer != null ? _fromSpecimenSer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toSpecimenSer != null ? _toSpecimenSer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_uitakCode != null ? _uitakCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_centerCode != null ? _centerCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private Boolean _cbxJubsuDate;
        private String _fromPartJubsuDate;
        private String _toPartJubsuDate;
        private String _fromSeq;
        private String _toSeq;
        private String _fromSpecimenSer;
        private String _toSpecimenSer;
        private String _uitakCode;
        private String _centerCode;

        public Boolean CbxJubsuDate
        {
            get { return this._cbxJubsuDate; }
            set { this._cbxJubsuDate = value; }
        }

        public String FromPartJubsuDate
        {
            get { return this._fromPartJubsuDate; }
            set { this._fromPartJubsuDate = value; }
        }

        public String ToPartJubsuDate
        {
            get { return this._toPartJubsuDate; }
            set { this._toPartJubsuDate = value; }
        }

        public String FromSeq
        {
            get { return this._fromSeq; }
            set { this._fromSeq = value; }
        }

        public String ToSeq
        {
            get { return this._toSeq; }
            set { this._toSeq = value; }
        }

        public String FromSpecimenSer
        {
            get { return this._fromSpecimenSer; }
            set { this._fromSpecimenSer = value; }
        }

        public String ToSpecimenSer
        {
            get { return this._toSpecimenSer; }
            set { this._toSpecimenSer = value; }
        }

        public String UitakCode
        {
            get { return this._uitakCode; }
            set { this._uitakCode = value; }
        }

        public String CenterCode
        {
            get { return this._centerCode; }
            set { this._centerCode = value; }
        }

        public CPL3010U01GrdPaArgs() { }

        public CPL3010U01GrdPaArgs(Boolean cbxJubsuDate, String fromPartJubsuDate, String toPartJubsuDate, String fromSeq, String toSeq, String fromSpecimenSer, String toSpecimenSer, String uitakCode, String centerCode)
        {
            this._cbxJubsuDate = cbxJubsuDate;
            this._fromPartJubsuDate = fromPartJubsuDate;
            this._toPartJubsuDate = toPartJubsuDate;
            this._fromSeq = fromSeq;
            this._toSeq = toSeq;
            this._fromSpecimenSer = fromSpecimenSer;
            this._toSpecimenSer = toSpecimenSer;
            this._uitakCode = uitakCode;
            this._centerCode = centerCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3010U01GrdPaRequest();
        }
    }
}