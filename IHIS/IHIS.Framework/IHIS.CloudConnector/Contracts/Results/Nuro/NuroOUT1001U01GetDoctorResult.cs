using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01GetDoctorResult : AbstractContractResult
    {
        private List<NuroOUT1001U01GetDoctorInfo> _doctorItem = new List<NuroOUT1001U01GetDoctorInfo>();

        public List<NuroOUT1001U01GetDoctorInfo> DoctorItem
        {
            get { return this._doctorItem; }
            set { this._doctorItem = value; }
        }

        public NuroOUT1001U01GetDoctorResult() { }

    }
}