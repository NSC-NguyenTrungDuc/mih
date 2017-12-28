using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04GrdExcelArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04GrdExcelArgs other)
    {
        return string.Equals(_naewonDate, other._naewonDate) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_bunho, other._bunho) && string.Equals(_jubsuGubun, other._jubsuGubun) && string.Equals(_jinryoYn, other._jinryoYn) && string.Equals(_naewonYn, other._naewonYn);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04GrdExcelArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jubsuGubun != null ? _jubsuGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jinryoYn != null ? _jinryoYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonYn != null ? _naewonYn.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _naewonDate;
        private String _gwa;
        private String _doctor;
        private String _bunho;
        private String _jubsuGubun;
        private String _jinryoYn;
        private String _naewonYn;

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String JubsuGubun
        {
            get { return this._jubsuGubun; }
            set { this._jubsuGubun = value; }
        }

        public String JinryoYn
        {
            get { return this._jinryoYn; }
            set { this._jinryoYn = value; }
        }

        public String NaewonYn
        {
            get { return this._naewonYn; }
            set { this._naewonYn = value; }
        }

        public PHY2001U04GrdExcelArgs() { }

        public PHY2001U04GrdExcelArgs(String naewonDate, String gwa, String doctor, String bunho, String jubsuGubun, String jinryoYn, String naewonYn)
        {
            this._naewonDate = naewonDate;
            this._gwa = gwa;
            this._doctor = doctor;
            this._bunho = bunho;
            this._jubsuGubun = jubsuGubun;
            this._jinryoYn = jinryoYn;
            this._naewonYn = naewonYn;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04GrdExcelRequest();
        }
    }
}