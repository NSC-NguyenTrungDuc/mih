using System;

namespace IHIS.CloudConnector.Contracts.Models.INVS
{
    public class INV6002U00GrdINV6002ExcuteInfo
    {
        private String _userId;
        private String _hospCode;
        private String _magamMonth;
        private String _jaeryoCode;
        private String _existCount;
        private String _inputDate;
        private String _inputUser;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String MagamMonth
        {
            get { return this._magamMonth; }
            set { this._magamMonth = value; }
        }

        public String JaeryoCode
        {
            get { return this._jaeryoCode; }
            set { this._jaeryoCode = value; }
        }

        public String ExistCount
        {
            get { return this._existCount; }
            set { this._existCount = value; }
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

        public INV6002U00GrdINV6002ExcuteInfo() { }

        public INV6002U00GrdINV6002ExcuteInfo(String userId, String hospCode, String magamMonth, String jaeryoCode, String existCount, String inputDate, String inputUser)
        {
            this._userId = userId;
            this._hospCode = hospCode;
            this._magamMonth = magamMonth;
            this._jaeryoCode = jaeryoCode;
            this._existCount = existCount;
            this._inputDate = inputDate;
            this._inputUser = inputUser;
        }

    }
}