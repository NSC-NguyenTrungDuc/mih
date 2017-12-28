using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Endo
{
    [Serializable]
    public class END1001U02DsvGumsaNameResult : AbstractContractResult
    {
        private List<END1001U02StrInfo> _dsvGumsaNameItem = new List<END1001U02StrInfo>();

        public List<END1001U02StrInfo> DsvGumsaNameItem
        {
            get { return this._dsvGumsaNameItem; }
            set { this._dsvGumsaNameItem = value; }
        }

        public END1001U02DsvGumsaNameResult() { }

    }
}