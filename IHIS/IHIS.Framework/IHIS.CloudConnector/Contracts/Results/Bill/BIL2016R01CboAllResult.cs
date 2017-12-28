using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Bill
{
    public class BIL2016R01CboAllResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _cboAssignDept = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _cboExeDept = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> CboAssignDept
        {
            get { return this._cboAssignDept; }
            set { this._cboAssignDept = value; }
        }

        public List<ComboListItemInfo> CboExeDept
        {
            get { return this._cboExeDept; }
            set { this._cboExeDept = value; }
        }

        public BIL2016R01CboAllResult() { }

    }
}