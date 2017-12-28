using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04BtnDeleteArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04BtnDeleteArgs other)
    {
        return string.Equals(_user, other._user) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_gubun, other._gubun) && string.Equals(_tuyakIlsu, other._tuyakIlsu) && string.Equals(_doctor, other._doctor) && string.Equals(_inOut, other._inOut) && string.Equals(_chartGwa, other._chartGwa) && string.Equals(_specialYn, other._specialYn) && string.Equals(_toiwonDate, other._toiwonDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04BtnDeleteArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_user != null ? _user.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gubun != null ? _gubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_tuyakIlsu != null ? _tuyakIlsu.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inOut != null ? _inOut.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_chartGwa != null ? _chartGwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_specialYn != null ? _specialYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_toiwonDate != null ? _toiwonDate.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _user;
        private String _naewonDate;
        private String _bunho;
        private String _gwa;
        private String _gubun;
        private String _tuyakIlsu;
        private String _doctor;
        private String _inOut;
        private String _chartGwa;
        private String _specialYn;
        private String _toiwonDate;

        public String User
        {
            get { return this._user; }
            set { this._user = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String TuyakIlsu
        {
            get { return this._tuyakIlsu; }
            set { this._tuyakIlsu = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String InOut
        {
            get { return this._inOut; }
            set { this._inOut = value; }
        }

        public String ChartGwa
        {
            get { return this._chartGwa; }
            set { this._chartGwa = value; }
        }

        public String SpecialYn
        {
            get { return this._specialYn; }
            set { this._specialYn = value; }
        }

        public String ToiwonDate
        {
            get { return this._toiwonDate; }
            set { this._toiwonDate = value; }
        }

        public PHY2001U04BtnDeleteArgs() { }

        public PHY2001U04BtnDeleteArgs(String user, String naewonDate, String bunho, String gwa, String gubun, String tuyakIlsu, String doctor, String inOut, String chartGwa, String specialYn, String toiwonDate)
        {
            this._user = user;
            this._naewonDate = naewonDate;
            this._bunho = bunho;
            this._gwa = gwa;
            this._gubun = gubun;
            this._tuyakIlsu = tuyakIlsu;
            this._doctor = doctor;
            this._inOut = inOut;
            this._chartGwa = chartGwa;
            this._specialYn = specialYn;
            this._toiwonDate = toiwonDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04BtnDeleteRequest();
        }
    }
}