using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class OCS1003R00LayOCS1001Info
    {
        private String _juSangYn;
        private String _sangCode;
        private String _ser;
        private String _disSangName;
        private String _sangStartDate;
        private String _sangEndDate;
        private String _sangEndSayu;
        private String _sangName;
        private String _preModifierName;
        private String _postModifierName;
        private String _endYn;

        public String JuSangYn
        {
            get { return this._juSangYn; }
            set { this._juSangYn = value; }
        }

        public String SangCode
        {
            get { return this._sangCode; }
            set { this._sangCode = value; }
        }

        public String Ser
        {
            get { return this._ser; }
            set { this._ser = value; }
        }

        public String DisSangName
        {
            get { return this._disSangName; }
            set { this._disSangName = value; }
        }

        public String SangStartDate
        {
            get { return this._sangStartDate; }
            set { this._sangStartDate = value; }
        }

        public String SangEndDate
        {
            get { return this._sangEndDate; }
            set { this._sangEndDate = value; }
        }

        public String SangEndSayu
        {
            get { return this._sangEndSayu; }
            set { this._sangEndSayu = value; }
        }

        public String SangName
        {
            get { return this._sangName; }
            set { this._sangName = value; }
        }

        public String PreModifierName
        {
            get { return this._preModifierName; }
            set { this._preModifierName = value; }
        }

        public String PostModifierName
        {
            get { return this._postModifierName; }
            set { this._postModifierName = value; }
        }

        public String EndYn
        {
            get { return this._endYn; }
            set { this._endYn = value; }
        }

        public OCS1003R00LayOCS1001Info() { }

        public OCS1003R00LayOCS1001Info(String juSangYn, String sangCode, String ser, String disSangName, String sangStartDate, String sangEndDate, String sangEndSayu, String sangName, String preModifierName, String postModifierName, String endYn)
        {
            this._juSangYn = juSangYn;
            this._sangCode = sangCode;
            this._ser = ser;
            this._disSangName = disSangName;
            this._sangStartDate = sangStartDate;
            this._sangEndDate = sangEndDate;
            this._sangEndSayu = sangEndSayu;
            this._sangName = sangName;
            this._preModifierName = preModifierName;
            this._postModifierName = postModifierName;
            this._endYn = endYn;
        }

    }
}