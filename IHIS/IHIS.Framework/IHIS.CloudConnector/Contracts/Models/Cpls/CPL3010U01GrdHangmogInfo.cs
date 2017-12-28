using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL3010U01GrdHangmogInfo
    {
        private String _recodeGubun;
        private String _centerCode;
        private String _requestKey;
        private String _hospitalCode;
        private String _hangmogCode;
        private String _sanCode;
        private String _specimenCode;
        private String _emergency;
        private String _emptyString;
        private String _specimenSer;
        private String _jundalGubunName;
        private String _gumsaName;
        private String _specimenName;

        public String RecodeGubun
        {
            get { return this._recodeGubun; }
            set { this._recodeGubun = value; }
        }

        public String CenterCode
        {
            get { return this._centerCode; }
            set { this._centerCode = value; }
        }

        public String RequestKey
        {
            get { return this._requestKey; }
            set { this._requestKey = value; }
        }

        public String HospitalCode
        {
            get { return this._hospitalCode; }
            set { this._hospitalCode = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String SanCode
        {
            get { return this._sanCode; }
            set { this._sanCode = value; }
        }

        public String SpecimenCode
        {
            get { return this._specimenCode; }
            set { this._specimenCode = value; }
        }

        public String Emergency
        {
            get { return this._emergency; }
            set { this._emergency = value; }
        }

        public String EmptyString
        {
            get { return this._emptyString; }
            set { this._emptyString = value; }
        }

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public String JundalGubunName
        {
            get { return this._jundalGubunName; }
            set { this._jundalGubunName = value; }
        }

        public String GumsaName
        {
            get { return this._gumsaName; }
            set { this._gumsaName = value; }
        }

        public String SpecimenName
        {
            get { return this._specimenName; }
            set { this._specimenName = value; }
        }

        public CPL3010U01GrdHangmogInfo() { }

        public CPL3010U01GrdHangmogInfo(String recodeGubun, String centerCode, String requestKey, String hospitalCode, String hangmogCode, String sanCode, String specimenCode, String emergency, String emptyString, String specimenSer, String jundalGubunName, String gumsaName, String specimenName)
        {
            this._recodeGubun = recodeGubun;
            this._centerCode = centerCode;
            this._requestKey = requestKey;
            this._hospitalCode = hospitalCode;
            this._hangmogCode = hangmogCode;
            this._sanCode = sanCode;
            this._specimenCode = specimenCode;
            this._emergency = emergency;
            this._emptyString = emptyString;
            this._specimenSer = specimenSer;
            this._jundalGubunName = jundalGubunName;
            this._gumsaName = gumsaName;
            this._specimenName = specimenName;
        }

    }
}