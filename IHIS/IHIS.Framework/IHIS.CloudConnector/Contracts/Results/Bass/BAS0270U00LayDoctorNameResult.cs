using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0270U00LayDoctorNameResult : AbstractContractResult
    {
        private List<DataStringListItemInfo> _doctorName = new List<DataStringListItemInfo>();

        public List<DataStringListItemInfo> DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public BAS0270U00LayDoctorNameResult() { }

    }
}