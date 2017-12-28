using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0103U00FwkCommonInfo
    {
        private String _yjCode;
        private String _hotCode;
        private String _yakKijunCode;
        private String _sgCode;
        private String _saleName;
        private String _createdCompanyName;
        private String _saledCompanyName;
        private String _a16;
        private String _a18;

        public String YjCode
        {
            get { return this._yjCode; }
            set { this._yjCode = value; }
        }

        public String HotCode
        {
            get { return this._hotCode; }
            set { this._hotCode = value; }
        }

        public String YakKijunCode
        {
            get { return this._yakKijunCode; }
            set { this._yakKijunCode = value; }
        }

        public String SgCode
        {
            get { return this._sgCode; }
            set { this._sgCode = value; }
        }

        public String SaleName
        {
            get { return this._saleName; }
            set { this._saleName = value; }
        }

        public String CreatedCompanyName
        {
            get { return this._createdCompanyName; }
            set { this._createdCompanyName = value; }
        }

        public String SaledCompanyName
        {
            get { return this._saledCompanyName; }
            set { this._saledCompanyName = value; }
        }

        public String A16
        {
            get { return this._a16; }
            set { this._a16 = value; }
        }

        public String A18
        {
            get { return this._a18; }
            set { this._a18 = value; }
        }

        public OCS0103U00FwkCommonInfo() { }

        public OCS0103U00FwkCommonInfo(String yjCode, String hotCode, String yakKijunCode, String sgCode, String saleName, String createdCompanyName, String saledCompanyName, String a16, String a18)
        {
            this._yjCode = yjCode;
            this._hotCode = hotCode;
            this._yakKijunCode = yakKijunCode;
            this._sgCode = sgCode;
            this._saleName = saleName;
            this._createdCompanyName = createdCompanyName;
            this._saledCompanyName = saledCompanyName;
            this._a16 = a16;
            this._a18 = a18;
        }

    }
}