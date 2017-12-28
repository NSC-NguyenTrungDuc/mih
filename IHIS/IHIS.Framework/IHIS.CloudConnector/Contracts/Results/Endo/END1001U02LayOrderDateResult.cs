using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Endo
{
    [Serializable]
    public class END1001U02LayOrderDateResult : AbstractContractResult
    {
        private List<END1001U02LayOrderDateInfo> _layOrderDateItem = new List<END1001U02LayOrderDateInfo>();

        public List<END1001U02LayOrderDateInfo> LayOrderDateItem
        {
            get { return this._layOrderDateItem; }
            set { this._layOrderDateItem = value; }
        }

        public END1001U02LayOrderDateResult() { }

    }
}