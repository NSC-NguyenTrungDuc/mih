using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
    public class SCH0201U10LayReserInfoResult : AbstractContractResult
    {
        private List<SCH0201U10LayReserInfo> _layList = new List<SCH0201U10LayReserInfo>();

        public List<SCH0201U10LayReserInfo> LayList
        {
            get { return this._layList; }
            set { this._layList = value; }
        }

        public SCH0201U10LayReserInfoResult() { }

    }
}