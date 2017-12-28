using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV6000U00ExportCSVResult : AbstractContractResult
    {
        private List<INV6000U00ExportCSVInfo> _csvItem = new List<INV6000U00ExportCSVInfo>();

        public List<INV6000U00ExportCSVInfo> CsvItem
        {
            get { return this._csvItem; }
            set { this._csvItem = value; }
        }

        public INV6000U00ExportCSVResult() { }

    }
}