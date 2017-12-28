using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class PatientLinkingFwkDoctorResult : AbstractContractResult
    {
        private List<PatientLinkingFwkDoctorInfo> _doctorList = new List<PatientLinkingFwkDoctorInfo>();

        public List<PatientLinkingFwkDoctorInfo> DoctorList
        {
            get { return this._doctorList; }
            set { this._doctorList = value; }
        }

        public PatientLinkingFwkDoctorResult() { }

    }
}