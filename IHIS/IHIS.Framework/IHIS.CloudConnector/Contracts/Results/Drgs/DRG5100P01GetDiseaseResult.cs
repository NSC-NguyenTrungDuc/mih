using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    public class DRG5100P01GetDiseaseResult : AbstractContractResult
    {
        private List<DRG5100P01GetDiseaseInfo> _sangItem = new List<DRG5100P01GetDiseaseInfo>();

        public List<DRG5100P01GetDiseaseInfo> SangItem
        {
            get { return this._sangItem; }
            set { this._sangItem = value; }
        }

        public DRG5100P01GetDiseaseResult() { }

    }
}