using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY8002U01GetScan001SeqResult : AbstractContractResult
    {
        private String _seq;

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public PHY8002U01GetScan001SeqResult() { }

    }
}