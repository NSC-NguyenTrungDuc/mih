using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class GetPatientByCodeResult : AbstractContractResult
    {
        private IList<PatientInfo> lstPatientInfos = new List<PatientInfo>();

        public GetPatientByCodeResult()
        {
        }

        public IList<PatientInfo> LstPatientInfos
        {
            get { return lstPatientInfos; }
            set { lstPatientInfos = value; }
        }
    }
}
