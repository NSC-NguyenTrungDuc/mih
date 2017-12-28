using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class LoadPatientInfectionResult : AbstractContractResult
    {
        private String _infectionCount;

        public String InfectionCount
        {
            get { return this._infectionCount; }
            set { this._infectionCount = value; }
        }

        public LoadPatientInfectionResult() { }

    }
}