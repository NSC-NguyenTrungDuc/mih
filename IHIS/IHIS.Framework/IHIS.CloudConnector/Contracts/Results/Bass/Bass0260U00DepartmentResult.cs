using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    public class Bass0260U00DepartmentResult : AbstractContractResult
    {
        private List<Bass0260U00DepartmentInfo> _itemInfo = new List<Bass0260U00DepartmentInfo>();

        public List<Bass0260U00DepartmentInfo> ItemInfo
        {
            get { return this._itemInfo; }
            set { this._itemInfo = value; }
        }

        public Bass0260U00DepartmentResult() { }

    }
}