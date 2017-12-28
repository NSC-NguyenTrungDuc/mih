using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Clis
{
    [Serializable]
    public class CLIS2015U04GetPatientListItemResult : AbstractContractResult
    {
        private List<CLIS2015U04GetPatientListItemInfo> _num = new List<CLIS2015U04GetPatientListItemInfo>();

        public List<CLIS2015U04GetPatientListItemInfo> Num
        {
            get { return this._num; }
            set { this._num = value; }
        }

        public CLIS2015U04GetPatientListItemResult() { }

    }
}