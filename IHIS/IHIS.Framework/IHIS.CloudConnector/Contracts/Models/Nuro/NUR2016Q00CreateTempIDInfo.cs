using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NUR2016Q00CreateTempIDInfo
    {
        private String _bunho;
        private String _hospCode;
        private String _suname;
        private String _suname2;
        private String _address;
        private String _birth;
        private String _linkPatientFlg;
        private String _bunhoType;
        private String _sex;
        private String _tel;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String Suname2
        {
            get { return this._suname2; }
            set { this._suname2 = value; }
        }

        public String Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String LinkPatientFlg
        {
            get { return this._linkPatientFlg; }
            set { this._linkPatientFlg = value; }
        }

        public String BunhoType
        {
            get { return this._bunhoType; }
            set { this._bunhoType = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public NUR2016Q00CreateTempIDInfo() { }

        public NUR2016Q00CreateTempIDInfo(String bunho, String hospCode, String suname, String suname2, String address, String birth, String linkPatientFlg, String bunhoType, String sex, String tel)
        {
            this._bunho = bunho;
            this._hospCode = hospCode;
            this._suname = suname;
            this._suname2 = suname2;
            this._address = address;
            this._birth = birth;
            this._linkPatientFlg = linkPatientFlg;
            this._bunhoType = bunhoType;
            this._sex = sex;
            this._tel = tel;
        }

    }
}