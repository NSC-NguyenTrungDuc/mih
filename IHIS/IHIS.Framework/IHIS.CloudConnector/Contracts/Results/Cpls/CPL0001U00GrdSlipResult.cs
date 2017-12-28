using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL0001U00GrdSlipResult : AbstractContractResult
    {
        private List<CPL0001U00GrdSlipInfo> _dt = new List<CPL0001U00GrdSlipInfo>();

        public List<CPL0001U00GrdSlipInfo> Dt
        {
            get { return this._dt; }
            set { this._dt = value; }
        }

        public CPL0001U00GrdSlipResult() { }

    }
}