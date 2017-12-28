using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    public class CPL0000Q00GrdResResult : AbstractContractResult
    {
        private List<CPL0000Q00GrdResInfo> _resItem = new List<CPL0000Q00GrdResInfo>();

        public List<CPL0000Q00GrdResInfo> ResItem
        {
            get { return this._resItem; }
            set { this._resItem = value; }
        }

        public CPL0000Q00GrdResResult() { }

    }
}