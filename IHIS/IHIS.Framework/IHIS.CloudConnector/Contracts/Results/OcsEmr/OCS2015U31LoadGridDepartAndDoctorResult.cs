using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class OCS2015U31LoadGridDepartAndDoctorResult : AbstractContractResult
    {
        private List<OCS2015U31LoadGridDepartAndDoctorInfo> _departAndDoctor = new List<OCS2015U31LoadGridDepartAndDoctorInfo>();

        public List<OCS2015U31LoadGridDepartAndDoctorInfo> DepartAndDoctor
        {
            get { return this._departAndDoctor; }
            set { this._departAndDoctor = value; }
        }

        public OCS2015U31LoadGridDepartAndDoctorResult() { }

    }
}