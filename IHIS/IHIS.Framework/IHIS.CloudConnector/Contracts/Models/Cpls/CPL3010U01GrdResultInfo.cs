using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL3010U01GrdResultInfo
    {
        private String _recodeGubun;
        private String _centerCode;
        private String _requestKey;
        private String _hangmogCode;
        private String _srlCode;
        private String _specimenCode;
        private String _emergency;
        private String _emptyString;
        private String _specimenSer;
        private String _jundalGubunName;
        private String _labNo;
        private String _cplResult;
        private String _standardYn;
        private String _comments;
        private String _vitros;
        private String _resultYn;
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

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String SrlCode
        {
            get { return this._srlCode; }
            set { this._srlCode = value; }
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

        public String LabNo
        {
            get { return this._labNo; }
            set { this._labNo = value; }
        }

        public String CplResult
        {
            get { return this._cplResult; }
            set { this._cplResult = value; }
        }

        public String StandardYn
        {
            get { return this._standardYn; }
            set { this._standardYn = value; }
        }

        public String Comments
        {
            get { return this._comments; }
            set { this._comments = value; }
        }

        public String Vitros
        {
            get { return this._vitros; }
            set { this._vitros = value; }
        }

        public String ResultYn
        {
            get { return this._resultYn; }
            set { this._resultYn = value; }
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

        public CPL3010U01GrdResultInfo() { }

        public CPL3010U01GrdResultInfo(String recodeGubun, String centerCode, String requestKey, String hangmogCode, String srlCode, String specimenCode, String emergency, String emptyString, String specimenSer, String jundalGubunName, String labNo, String cplResult, String standardYn, String comments, String vitros, String resultYn, String gumsaName, String specimenName)
        {
            this._recodeGubun = recodeGubun;
            this._centerCode = centerCode;
            this._requestKey = requestKey;
            this._hangmogCode = hangmogCode;
            this._srlCode = srlCode;
            this._specimenCode = specimenCode;
            this._emergency = emergency;
            this._emptyString = emptyString;
            this._specimenSer = specimenSer;
            this._jundalGubunName = jundalGubunName;
            this._labNo = labNo;
            this._cplResult = cplResult;
            this._standardYn = standardYn;
            this._comments = comments;
            this._vitros = vitros;
            this._resultYn = resultYn;
            this._gumsaName = gumsaName;
            this._specimenName = specimenName;
        }

    }
}