using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV4001U00ExportCSVResult : AbstractContractResult
    {
        private List<INV4001U00ExportCSVInfo> _csvItem = new List<INV4001U00ExportCSVInfo>();

        public List<INV4001U00ExportCSVInfo> CsvItem
        {
            get { return this._csvItem; }
            set { this._csvItem = value; }
        }

        public INV4001U00ExportCSVResult() { }

    }
}