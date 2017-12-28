using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    public class Bas0260U01LoadDepartmentTypeResult : AbstractContractResult
    {
        private List<LoadDepartmentTypeInfo> _listInfo = new List<LoadDepartmentTypeInfo>();

        public List<LoadDepartmentTypeInfo> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public Bas0260U01LoadDepartmentTypeResult() { }

    }
}