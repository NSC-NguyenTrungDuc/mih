using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0270U00LayDoctorGradeResult : AbstractContractResult
    {
        private List<DataStringListItemInfo> _codeName = new List<DataStringListItemInfo>();

        public List<DataStringListItemInfo> CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public BAS0270U00LayDoctorGradeResult() { }

    }
}