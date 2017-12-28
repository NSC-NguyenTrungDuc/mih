using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01GetDepartmentResult : AbstractContractResult
    {
        private List<NuroOUT1001U01GetDepartmentInfo> _deptItem = new List<NuroOUT1001U01GetDepartmentInfo>();

        public List<NuroOUT1001U01GetDepartmentInfo> DeptItem
        {
            get { return this._deptItem; }
            set { this._deptItem = value; }
        }

        public NuroOUT1001U01GetDepartmentResult() { }

    }
}