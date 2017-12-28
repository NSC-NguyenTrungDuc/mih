using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroNUR2001U04DepartmentListResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _deptListItem = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> DeptListItem
        {
            get { return _deptListItem; }
            set { _deptListItem = value; }
        }

        public NuroNUR2001U04DepartmentListResult()
        {
        }
    }
}
