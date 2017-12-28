using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class OCS1003R02LayR02ListItemInfo
    {
        private String _gwa;
        private String _gwaName;
        private String _bunho;
        private String _suname;
        private String _balheangDate;
        private String _birth;
        private String _naewonDate;
        private String _comment;
        private String _bunho1;
        private String _dangilGumsaResultYn;
        private String _fkout1001;
        private String _actingCheckYn;
        private String _jaedanName;
        private String _hospName;
        private String _tel;
        private String _homepage;

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String BalheangDate
        {
            get { return this._balheangDate; }
            set { this._balheangDate = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String Comment
        {
            get { return this._comment; }
            set { this._comment = value; }
        }

        public String Bunho1
        {
            get { return this._bunho1; }
            set { this._bunho1 = value; }
        }

        public String DangilGumsaResultYn
        {
            get { return this._dangilGumsaResultYn; }
            set { this._dangilGumsaResultYn = value; }
        }

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public String ActingCheckYn
        {
            get { return this._actingCheckYn; }
            set { this._actingCheckYn = value; }
        }

        public String JaedanName
        {
            get { return this._jaedanName; }
            set { this._jaedanName = value; }
        }

        public String HospName
        {
            get { return this._hospName; }
            set { this._hospName = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public String Homepage
        {
            get { return this._homepage; }
            set { this._homepage = value; }
        }

        public OCS1003R02LayR02ListItemInfo() { }

        public OCS1003R02LayR02ListItemInfo(String gwa, String gwaName, String bunho, String suname, String balheangDate, String birth, String naewonDate, String comment, String bunho1, String dangilGumsaResultYn, String fkout1001, String actingCheckYn, String jaedanName, String hospName, String tel, String homepage)
        {
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._bunho = bunho;
            this._suname = suname;
            this._balheangDate = balheangDate;
            this._birth = birth;
            this._naewonDate = naewonDate;
            this._comment = comment;
            this._bunho1 = bunho1;
            this._dangilGumsaResultYn = dangilGumsaResultYn;
            this._fkout1001 = fkout1001;
            this._actingCheckYn = actingCheckYn;
            this._jaedanName = jaedanName;
            this._hospName = hospName;
            this._tel = tel;
            this._homepage = homepage;
        }

    }
}