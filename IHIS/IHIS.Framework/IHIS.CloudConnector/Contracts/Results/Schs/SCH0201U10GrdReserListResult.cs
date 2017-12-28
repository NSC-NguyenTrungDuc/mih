using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
    public class SCH0201U10GrdReserListResult : AbstractContractResult
    {
        private List<DataStringListItemInfo> _dateValue = new List<DataStringListItemInfo>();

        public List<DataStringListItemInfo> DateValue
        {
            get { return this._dateValue; }
            set { this._dateValue = value; }
        }

        public SCH0201U10GrdReserListResult() { }

    }
}