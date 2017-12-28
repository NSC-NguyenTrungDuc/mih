using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPLMASTERUPLOADERPRCplBmlUploaderInfo
    {
        private String _groupGubun;
        private String _parentCode;
        private String _hangmogCode;
        private String _serial;
        private String _gumsaNameRe;
        private String _gumsaName;
        private String _jlac10Code;
        private String _tubeName;
        private String _keepMeansName;
        private String _specimenCode;
        private String _specimenName;
        private String _danui;
        private String _menFromStandard;
        private String _menToStandard;
        private String _womenFromStandard;
        private String _womenToStandard;
        private String _sgCode1;
        private String _sgCode2;
        private String _specimenAmt;
        private String _jukyongDate;
        private String _detailInfo;
        private String _hangmogMarkName;
        private String _emergency;
        private String _specimenCode2;
        private String _specimenName2;

        public String GroupGubun
        {
            get { return this._groupGubun; }
            set { this._groupGubun = value; }
        }

        public String ParentCode
        {
            get { return this._parentCode; }
            set { this._parentCode = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String Serial
        {
            get { return this._serial; }
            set { this._serial = value; }
        }

        public String GumsaNameRe
        {
            get { return this._gumsaNameRe; }
            set { this._gumsaNameRe = value; }
        }

        public String GumsaName
        {
            get { return this._gumsaName; }
            set { this._gumsaName = value; }
        }

        public String Jlac10Code
        {
            get { return this._jlac10Code; }
            set { this._jlac10Code = value; }
        }

        public String TubeName
        {
            get { return this._tubeName; }
            set { this._tubeName = value; }
        }

        public String KeepMeansName
        {
            get { return this._keepMeansName; }
            set { this._keepMeansName = value; }
        }

        public String SpecimenCode
        {
            get { return this._specimenCode; }
            set { this._specimenCode = value; }
        }

        public String SpecimenName
        {
            get { return this._specimenName; }
            set { this._specimenName = value; }
        }

        public String Danui
        {
            get { return this._danui; }
            set { this._danui = value; }
        }

        public String MenFromStandard
        {
            get { return this._menFromStandard; }
            set { this._menFromStandard = value; }
        }

        public String MenToStandard
        {
            get { return this._menToStandard; }
            set { this._menToStandard = value; }
        }

        public String WomenFromStandard
        {
            get { return this._womenFromStandard; }
            set { this._womenFromStandard = value; }
        }

        public String WomenToStandard
        {
            get { return this._womenToStandard; }
            set { this._womenToStandard = value; }
        }

        public String SgCode1
        {
            get { return this._sgCode1; }
            set { this._sgCode1 = value; }
        }

        public String SgCode2
        {
            get { return this._sgCode2; }
            set { this._sgCode2 = value; }
        }

        public String SpecimenAmt
        {
            get { return this._specimenAmt; }
            set { this._specimenAmt = value; }
        }

        public String JukyongDate
        {
            get { return this._jukyongDate; }
            set { this._jukyongDate = value; }
        }

        public String DetailInfo
        {
            get { return this._detailInfo; }
            set { this._detailInfo = value; }
        }

        public String HangmogMarkName
        {
            get { return this._hangmogMarkName; }
            set { this._hangmogMarkName = value; }
        }

        public String Emergency
        {
            get { return this._emergency; }
            set { this._emergency = value; }
        }

        public String SpecimenCode2
        {
            get { return this._specimenCode2; }
            set { this._specimenCode2 = value; }
        }

        public String SpecimenName2
        {
            get { return this._specimenName2; }
            set { this._specimenName2 = value; }
        }

        public CPLMASTERUPLOADERPRCplBmlUploaderInfo() { }

        public CPLMASTERUPLOADERPRCplBmlUploaderInfo(String groupGubun, String parentCode, String hangmogCode, String serial, String gumsaNameRe, String gumsaName, String jlac10Code, String tubeName, String keepMeansName, String specimenCode, String specimenName, String danui, String menFromStandard, String menToStandard, String womenFromStandard, String womenToStandard, String sgCode1, String sgCode2, String specimenAmt, String jukyongDate, String detailInfo, String hangmogMarkName, String emergency, String specimenCode2, String specimenName2)
        {
            this._groupGubun = groupGubun;
            this._parentCode = parentCode;
            this._hangmogCode = hangmogCode;
            this._serial = serial;
            this._gumsaNameRe = gumsaNameRe;
            this._gumsaName = gumsaName;
            this._jlac10Code = jlac10Code;
            this._tubeName = tubeName;
            this._keepMeansName = keepMeansName;
            this._specimenCode = specimenCode;
            this._specimenName = specimenName;
            this._danui = danui;
            this._menFromStandard = menFromStandard;
            this._menToStandard = menToStandard;
            this._womenFromStandard = womenFromStandard;
            this._womenToStandard = womenToStandard;
            this._sgCode1 = sgCode1;
            this._sgCode2 = sgCode2;
            this._specimenAmt = specimenAmt;
            this._jukyongDate = jukyongDate;
            this._detailInfo = detailInfo;
            this._hangmogMarkName = hangmogMarkName;
            this._emergency = emergency;
            this._specimenCode2 = specimenCode2;
            this._specimenName2 = specimenName2;
        }

    }
}