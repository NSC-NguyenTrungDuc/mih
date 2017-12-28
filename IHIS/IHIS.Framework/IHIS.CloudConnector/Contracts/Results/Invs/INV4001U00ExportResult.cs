using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    [Serializable]
    public class INV4001U00ExportResult : AbstractContractResult
    {
        private byte[] _data;

        public byte[] Data
        {
            get { return this._data; }
            set { this._data = value; }
        }
    }
}
