using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class NUR2015U01GetDataFromNaewonResult : AbstractContractResult
    {
        private String _examDate;
        private String _departmentCode;

        public String ExamDate
        {
            get { return this._examDate; }
            set { this._examDate = value; }
        }

        public String DepartmentCode
        {
            get { return this._departmentCode; }
            set { this._departmentCode = value; }
        }

        public NUR2015U01GetDataFromNaewonResult() { }

    }
}