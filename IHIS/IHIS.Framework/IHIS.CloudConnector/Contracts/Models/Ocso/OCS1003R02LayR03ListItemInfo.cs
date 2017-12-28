using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class OCS1003R02LayR03ListItemInfo
    {
        private String _gwa;
        private String _gwaName;
        private String _bunho;
        private String _suname;
        private String _balheangDate;
        private String _birth;
        private String _naewonDate;
        private String _moveName;
        private String _bunho1;
        private String _hopeDate;

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

        public String MoveName
        {
            get { return this._moveName; }
            set { this._moveName = value; }
        }

        public String Bunho1
        {
            get { return this._bunho1; }
            set { this._bunho1 = value; }
        }

        public String HopeDate
        {
            get { return this._hopeDate; }
            set { this._hopeDate = value; }
        }

        public OCS1003R02LayR03ListItemInfo() { }

        public OCS1003R02LayR03ListItemInfo(String gwa, String gwaName, String bunho, String suname, String balheangDate, String birth, String naewonDate, String moveName, String bunho1, String hopeDate)
        {
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._bunho = bunho;
            this._suname = suname;
            this._balheangDate = balheangDate;
            this._birth = birth;
            this._naewonDate = naewonDate;
            this._moveName = moveName;
            this._bunho1 = bunho1;
            this._hopeDate = hopeDate;
        }

    }
}