using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCSAOCS0270Q00GridBAS0270Args : IContractArgs
    {
    protected bool Equals(OCSAOCS0270Q00GridBAS0270Args other)
    {
        return string.Equals(_allGubun, other._allGubun) && string.Equals(_gwa, other._gwa) && string.Equals(_doctorGrade, other._doctorGrade) && string.Equals(_query, other._query) && string.Equals(_osimGubun, other._osimGubun) && string.Equals(_date, other._date) && string.Equals(_hospCode, other._hospCode) && _reserOutYn.Equals(other._reserOutYn);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSAOCS0270Q00GridBAS0270Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_allGubun != null ? _allGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctorGrade != null ? _doctorGrade.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_query != null ? _query.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_osimGubun != null ? _osimGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_date != null ? _date.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ _reserOutYn.GetHashCode();
            return hashCode;
        }
    }

    private String _allGubun;
        private String _gwa;
        private String _doctorGrade;
        private String _query;
        private String _osimGubun;
        private String _date;
        private String _hospCode;
        private Boolean _reserOutYn;

        public String AllGubun
        {
            get { return this._allGubun; }
            set { this._allGubun = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String DoctorGrade
        {
            get { return this._doctorGrade; }
            set { this._doctorGrade = value; }
        }

        public String Query
        {
            get { return this._query; }
            set { this._query = value; }
        }

        public String OsimGubun
        {
            get { return this._osimGubun; }
            set { this._osimGubun = value; }
        }

        public String Date
        {
            get { return this._date; }
            set { this._date = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public Boolean ReserOutYn
        {
            get { return this._reserOutYn; }
            set { this._reserOutYn = value; }
        }

        public OCSAOCS0270Q00GridBAS0270Args() { }

        public OCSAOCS0270Q00GridBAS0270Args(String allGubun, String gwa, String doctorGrade, String query, String osimGubun, String date, String hospCode, Boolean reserOutYn)
        {
            this._allGubun = allGubun;
            this._gwa = gwa;
            this._doctorGrade = doctorGrade;
            this._query = query;
            this._osimGubun = osimGubun;
            this._date = date;
            this._hospCode = hospCode;
            this._reserOutYn = reserOutYn;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSAOCS0270Q00GridBAS0270Request();
        }
    }
}