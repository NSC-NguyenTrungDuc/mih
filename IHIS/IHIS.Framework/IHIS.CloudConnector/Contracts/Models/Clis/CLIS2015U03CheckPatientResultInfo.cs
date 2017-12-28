using System;

namespace IHIS.CloudConnector.Contracts.Models.Clis
{
    [Serializable]
    public class CLIS2015U03CheckPatientResultInfo
    {
        private String _chkResult;

        public String ChkResult
        {
            get { return this._chkResult; }
            set { this._chkResult = value; }
        }

        public CLIS2015U03CheckPatientResultInfo() { }

        public CLIS2015U03CheckPatientResultInfo(String chkResult)
        {
            this._chkResult = chkResult;
        }

    }
}