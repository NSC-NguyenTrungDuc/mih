using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class OUT0101U02PatientExportResult : AbstractContractResult
    {
        private List<byte[]> _data = new List<byte[]>();

        public List<byte[]> Data
        {
            get { return this._data; }
            set { this._data = value; }
        }

        public OUT0101U02PatientExportResult() { }

    }
}