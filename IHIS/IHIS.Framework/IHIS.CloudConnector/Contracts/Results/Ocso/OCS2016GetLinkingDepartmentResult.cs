using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCS2016GetLinkingDepartmentResult : AbstractContractResult
    {
        private List<OCS2016GetLinkingDepartmentInfo> _departmentInfo = new List<OCS2016GetLinkingDepartmentInfo>();

        public List<OCS2016GetLinkingDepartmentInfo> DepartmentInfo
        {
            get { return this._departmentInfo; }
            set { this._departmentInfo = value; }
        }

        public OCS2016GetLinkingDepartmentResult() { }

    }
}