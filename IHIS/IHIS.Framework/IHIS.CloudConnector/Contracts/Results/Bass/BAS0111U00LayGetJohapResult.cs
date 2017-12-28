using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0111U00LayGetJohapResult : AbstractContractResult
    {
        private List<BAS0111U00LayVzvItemInfo> _dt = new List<BAS0111U00LayVzvItemInfo>();

        public List<BAS0111U00LayVzvItemInfo> Dt
        {
            get { return this._dt; }
            set { this._dt = value; }
        }

        public BAS0111U00LayGetJohapResult() { }

    }
}