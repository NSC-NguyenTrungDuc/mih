using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
    public class OCS2015U00GetDiseaseReportInfo
    {
        private String _sangCode;
        private String _sangName;

        public String SangCode
        {
            get { return this._sangCode; }
            set { this._sangCode = value; }
        }

        public String SangName
        {
            get { return this._sangName; }
            set { this._sangName = value; }
        }

        public OCS2015U00GetDiseaseReportInfo() { }

        public OCS2015U00GetDiseaseReportInfo(String sangCode, String sangName)
        {
            this._sangCode = sangCode;
            this._sangName = sangName;
        }

    }
}