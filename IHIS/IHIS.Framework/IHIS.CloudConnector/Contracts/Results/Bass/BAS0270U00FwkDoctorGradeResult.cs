using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0270U00FwkDoctorGradeResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _fwkList = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> FwkList
        {
            get { return this._fwkList; }
            set { this._fwkList = value; }
        }

        public BAS0270U00FwkDoctorGradeResult() { }

    }
}