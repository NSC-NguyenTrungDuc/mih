using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroSearchPatientInfoResult : AbstractContractResult
    {
        private List<NuroSearchPatientInfo>  _lsPatientInfos = new List<NuroSearchPatientInfo>();

        public NuroSearchPatientInfoResult()
        {
            
        }

        public NuroSearchPatientInfoResult(List<NuroSearchPatientInfo> lsPatientInfos)
        {
            LsPatientInfos = lsPatientInfos;
        }


        public List<NuroSearchPatientInfo> LsPatientInfos
        {
            get { return _lsPatientInfos; }
            set { _lsPatientInfos = value; }
        }
    }
}
