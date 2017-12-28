using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV6002U00GrdINV6002Info
    {
        private String _jaeryoCode;
        private String _jaeryoName;
        private String _existCount;
        private String _subulDanuiName;
        private String _inputDate;
        private String _inputUser;
        private String _jaryoGubun;
        private String _magamMonth;

        public String JaeryoCode
        {
            get { return this._jaeryoCode; }
            set { this._jaeryoCode = value; }
        }

        public String JaeryoName
        {
            get { return this._jaeryoName; }
            set { this._jaeryoName = value; }
        }

        public String ExistCount
        {
            get { return this._existCount; }
            set { this._existCount = value; }
        }

        public String SubulDanuiName
        {
            get { return this._subulDanuiName; }
            set { this._subulDanuiName = value; }
        }

        public String InputDate
        {
            get { return this._inputDate; }
            set { this._inputDate = value; }
        }

        public String InputUser
        {
            get { return this._inputUser; }
            set { this._inputUser = value; }
        }

        public String JaryoGubun
        {
            get { return this._jaryoGubun; }
            set { this._jaryoGubun = value; }
        }

        public String MagamMonth
        {
            get { return this._magamMonth; }
            set { this._magamMonth = value; }
        }

        public INV6002U00GrdINV6002Info() { }

        public INV6002U00GrdINV6002Info(String jaeryoCode, String jaeryoName, String existCount, String subulDanuiName, String inputDate, String inputUser, String jaryoGubun, String magamMonth)
        {
            this._jaeryoCode = jaeryoCode;
            this._jaeryoName = jaeryoName;
            this._existCount = existCount;
            this._subulDanuiName = subulDanuiName;
            this._inputDate = inputDate;
            this._inputUser = inputUser;
            this._jaryoGubun = jaryoGubun;
            this._magamMonth = magamMonth;
        }

    }
}