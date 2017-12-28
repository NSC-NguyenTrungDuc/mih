using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroManagePatientResult : AbstractContractResult
    {
        private List<NuroManagePatientInfo> _lstManagePatientInfos = new List<NuroManagePatientInfo>();

        public NuroManagePatientResult()
        {
        }

        public NuroManagePatientResult(List<NuroManagePatientInfo> lstManagePatientInfos)
        {
            this._lstManagePatientInfos = lstManagePatientInfos;
        }

        public List<NuroManagePatientInfo> LstManagePatientInfos
        {
            get { return _lstManagePatientInfos; }
            set { _lstManagePatientInfos = value; }
        }
    }
}
