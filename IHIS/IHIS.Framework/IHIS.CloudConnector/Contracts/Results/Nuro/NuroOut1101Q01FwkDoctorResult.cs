using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOut1101Q01FwkDoctorResult : AbstractContractResult
    {
        public NuroOut1101Q01FwkDoctorResult() { }
        private List<NuroOUT1101Q01FwkDoctorInfo> _nuroFwkDoctorInfoList = new List<NuroOUT1101Q01FwkDoctorInfo>();
        public List<NuroOUT1101Q01FwkDoctorInfo> NuroFwkDoctorInfoList
        {
            get { return _nuroFwkDoctorInfoList; }
            set { _nuroFwkDoctorInfoList = value; }
        }
    }
}