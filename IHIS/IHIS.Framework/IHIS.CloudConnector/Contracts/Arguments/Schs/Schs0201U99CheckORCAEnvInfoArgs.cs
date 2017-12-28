using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
    public class Schs0201U99CheckORCAEnvInfoArgs : IContractArgs
    {
    protected bool Equals(Schs0201U99CheckORCAEnvInfoArgs other)
    {
        return string.Equals(_hospCode, other._hospCode) && string.Equals(_codeType, other._codeType) && string.Equals(_doctor, other._doctor) && string.Equals(_gwa, other._gwa) && string.Equals(_bunhoLink, other._bunhoLink) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_jundalTable, other._jundalTable) && string.Equals(_jundalPart, other._jundalPart) && string.Equals(_reserDate, other._reserDate) && string.Equals(_reserTime, other._reserTime) && string.Equals(_inputGubun, other._inputGubun);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Schs0201U99CheckORCAEnvInfoArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunhoLink != null ? _bunhoLink.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalTable != null ? _jundalTable.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_reserTime != null ? _reserTime.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputGubun != null ? _inputGubun.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _hospCode;
        private String _codeType;
        private String _doctor;
        private String _gwa;
        private String _bunhoLink;
        private String _naewonDate;
        private String _hangmogCode;
        private String _jundalTable;
        private String _jundalPart;
        private String _reserDate;
        private String _reserTime;
        private String _inputGubun;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String BunhoLink
        {
            get { return this._bunhoLink; }
            set { this._bunhoLink = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String JundalTable
        {
            get { return this._jundalTable; }
            set { this._jundalTable = value; }
        }

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String ReserTime
        {
            get { return this._reserTime; }
            set { this._reserTime = value; }
        }

        public String InputGubun
        {
            get { return this._inputGubun; }
            set { this._inputGubun = value; }
        }

        public Schs0201U99CheckORCAEnvInfoArgs() { }

        public Schs0201U99CheckORCAEnvInfoArgs(String hospCode, String codeType, String doctor, String gwa, String bunhoLink, String naewonDate, String hangmogCode, String jundalTable, String jundalPart, String reserDate, String reserTime, String inputGubun)
        {
            this._hospCode = hospCode;
            this._codeType = codeType;
            this._doctor = doctor;
            this._gwa = gwa;
            this._bunhoLink = bunhoLink;
            this._naewonDate = naewonDate;
            this._hangmogCode = hangmogCode;
            this._jundalTable = jundalTable;
            this._jundalPart = jundalPart;
            this._reserDate = reserDate;
            this._reserTime = reserTime;
            this._inputGubun = inputGubun;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Schs0201U99CheckORCAEnvInfoRequest();
        }
    }
}