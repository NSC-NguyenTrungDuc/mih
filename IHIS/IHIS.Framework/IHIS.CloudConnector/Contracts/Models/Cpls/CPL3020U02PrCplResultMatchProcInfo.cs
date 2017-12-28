using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL3020U02PrCplResultMatchProcInfo
    {
        private String _procGubun;
        private String _specimenSer;
        private String _hangmogCode;
        private String _resultVal;
        private String _jangbiCode;
        private String _resultDate;
        private String _sampleId;
        private String _resultCode;

        public String ProcGubun
        {
            get { return this._procGubun; }
            set { this._procGubun = value; }
        }

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String ResultVal
        {
            get { return this._resultVal; }
            set { this._resultVal = value; }
        }

        public String JangbiCode
        {
            get { return this._jangbiCode; }
            set { this._jangbiCode = value; }
        }

        public String ResultDate
        {
            get { return this._resultDate; }
            set { this._resultDate = value; }
        }

        public String SampleId
        {
            get { return this._sampleId; }
            set { this._sampleId = value; }
        }

        public String ResultCode
        {
            get { return this._resultCode; }
            set { this._resultCode = value; }
        }

        public CPL3020U02PrCplResultMatchProcInfo() { }

        public CPL3020U02PrCplResultMatchProcInfo(String procGubun, String specimenSer, String hangmogCode, String resultVal, String jangbiCode, String resultDate, String sampleId, String resultCode)
        {
            this._procGubun = procGubun;
            this._specimenSer = specimenSer;
            this._hangmogCode = hangmogCode;
            this._resultVal = resultVal;
            this._jangbiCode = jangbiCode;
            this._resultDate = resultDate;
            this._sampleId = sampleId;
            this._resultCode = resultCode;
        }

    }
}