using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Clis
{
    [Serializable]
    public class CLIS2015U03CheckPatientResult : AbstractContractResult
    {
        private List<CLIS2015U03CheckPatientResultInfo> _chkResult = new List<CLIS2015U03CheckPatientResultInfo>();

        public List<CLIS2015U03CheckPatientResultInfo> ChkResult
        {
            get { return this._chkResult; }
            set { this._chkResult = value; }
        }

        public CLIS2015U03CheckPatientResult() { }

    }
}