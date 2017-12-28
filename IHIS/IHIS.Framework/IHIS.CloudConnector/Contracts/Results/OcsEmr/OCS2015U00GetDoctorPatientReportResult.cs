using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U00GetDoctorPatientReportResult : AbstractContractResult
    {
        private OCS2015U00GetDoctorPatientReportInfo _listItem;
        private List<OCS2015U00GetDiseaseReportInfo> _listDisease = new List<OCS2015U00GetDiseaseReportInfo>();
        private List<OCS2015U00GetOrderReportInfo> _listOrder = new List<OCS2015U00GetOrderReportInfo>();

        public OCS2015U00GetDoctorPatientReportInfo ListItem
        {
            get { return this._listItem; }
            set { this._listItem = value; }
        }

        public List<OCS2015U00GetDiseaseReportInfo> ListDisease
        {
            get { return this._listDisease; }
            set { this._listDisease = value; }
        }

        public List<OCS2015U00GetOrderReportInfo> ListOrder
        {
            get { return this._listOrder; }
            set { this._listOrder = value; }
        }

        public OCS2015U00GetDoctorPatientReportResult() { }

    }
}