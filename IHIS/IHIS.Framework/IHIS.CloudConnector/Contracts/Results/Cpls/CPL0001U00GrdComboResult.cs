using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL0001U00GrdComboResult : AbstractContractResult
    {
        private List<CPL0001U00GrdComboInfo> _dt = new List<CPL0001U00GrdComboInfo>();

        public List<CPL0001U00GrdComboInfo> Dt
        {
            get { return this._dt; }
            set { this._dt = value; }
        }

        public CPL0001U00GrdComboResult() { }

    }
}