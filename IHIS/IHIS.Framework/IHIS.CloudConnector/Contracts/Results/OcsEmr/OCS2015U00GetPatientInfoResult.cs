using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuri;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U00GetPatientInfoResult : AbstractContractResult
    {
        private List<NuriNUR7001U00MeasurePhysicalConditionListItemInfo> _phyInfoItem = new List<NuriNUR7001U00MeasurePhysicalConditionListItemInfo>();
        private List<NuroManagePatientInfo> _managePatInfo = new List<NuroManagePatientInfo>();

        public List<NuriNUR7001U00MeasurePhysicalConditionListItemInfo> PhyInfoItem
        {
            get { return this._phyInfoItem; }
            set { this._phyInfoItem = value; }
        }

        public List<NuroManagePatientInfo> ManagePatInfo
        {
            get { return this._managePatInfo; }
            set { this._managePatInfo = value; }
        }

        public OCS2015U00GetPatientInfoResult() { }

    }
}