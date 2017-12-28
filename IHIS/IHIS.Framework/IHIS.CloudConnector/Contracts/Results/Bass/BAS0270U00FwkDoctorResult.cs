using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0270U00FwkDoctorResult : AbstractContractResult
    {
        private List<BAS0270U00FwdDoctorInfo> _fwkList = new List<BAS0270U00FwdDoctorInfo>();

        public List<BAS0270U00FwdDoctorInfo> FwkList
        {
            get { return this._fwkList; }
            set { this._fwkList = value; }
        }

        public BAS0270U00FwkDoctorResult() { }

    }
}