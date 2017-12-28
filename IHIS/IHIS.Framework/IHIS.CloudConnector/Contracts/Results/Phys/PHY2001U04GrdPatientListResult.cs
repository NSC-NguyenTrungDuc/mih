using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY2001U04GrdPatientListResult : AbstractContractResult
    {
        private List<PHY2001U04GrdPatientListInfo> _grdPatientItem = new List<PHY2001U04GrdPatientListInfo>();

        public List<PHY2001U04GrdPatientListInfo> GrdPatientItem
        {
            get { return this._grdPatientItem; }
            set { this._grdPatientItem = value; }
        }

        public PHY2001U04GrdPatientListResult() { }

    }
}