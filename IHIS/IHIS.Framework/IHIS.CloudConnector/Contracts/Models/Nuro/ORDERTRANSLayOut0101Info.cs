using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANSLayOut0101Info
    {
        private String _suname;
        private String _suname2;
        private String _birth;
        private String _tel;
        private String _sex;
        private String _age;
        private String _ifValidYn;

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

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String Age
        {
            get { return this._age; }
            set { this._age = value; }
        }

        public String IfValidYn
        {
            get { return this._ifValidYn; }
            set { this._ifValidYn = value; }
        }

        public ORDERTRANSLayOut0101Info() { }

        public ORDERTRANSLayOut0101Info(String suname, String suname2, String birth, String tel, String sex, String age, String ifValidYn)
        {
            this._suname = suname;
            this._suname2 = suname2;
            this._birth = birth;
            this._tel = tel;
            this._sex = sex;
            this._age = age;
            this._ifValidYn = ifValidYn;
        }

    }
}