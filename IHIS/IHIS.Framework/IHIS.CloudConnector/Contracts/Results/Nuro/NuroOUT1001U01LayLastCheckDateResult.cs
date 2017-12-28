using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01LayLastCheckDateResult : AbstractContractResult
    {
        private string _lastCheckDate = "";

        public string LastCheckDate
        {
            get { return this._lastCheckDate; }
            set { this._lastCheckDate = value; }
        }

        public NuroOUT1001U01LayLastCheckDateResult() { }

    }
}
