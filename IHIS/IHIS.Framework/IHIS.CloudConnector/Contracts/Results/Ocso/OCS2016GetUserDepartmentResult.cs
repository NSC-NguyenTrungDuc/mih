using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCS2016GetUserDepartmentResult : AbstractContractResult
    {
        private List<OCS2016GetUserDepartmentInfo> _departmentInfo = new List<OCS2016GetUserDepartmentInfo>();

        public List<OCS2016GetUserDepartmentInfo> DepartmentInfo
        {
            get { return this._departmentInfo; }
            set { this._departmentInfo = value; }
        }

        public OCS2016GetUserDepartmentResult() { }

    }
}