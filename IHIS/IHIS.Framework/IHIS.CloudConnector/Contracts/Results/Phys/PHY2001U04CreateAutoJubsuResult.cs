using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY2001U04CreateAutoJubsuResult : AbstractContractResult
    {
        private String _outputList0;
        private String _outputList1;
        private String _outputSin0;
        private String _outputSin1;

        public String OutputList0
        {
            get { return this._outputList0; }
            set { this._outputList0 = value; }
        }

        public String OutputList1
        {
            get { return this._outputList1; }
            set { this._outputList1 = value; }
        }

        public String OutputSin0
        {
            get { return this._outputSin0; }
            set { this._outputSin0 = value; }
        }

        public String OutputSin1
        {
            get { return this._outputSin1; }
            set { this._outputSin1 = value; }
        }

        public PHY2001U04CreateAutoJubsuResult() { }

    }
}