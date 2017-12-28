using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    public class CPL3020U02ImportFileResult : AbstractContractResult
    {
        private byte[] _data;
        private String _message;

        public byte[] Data
        {
            get { return this._data; }
            set { this._data = value; }
        }

        public String Message
        {
            get { return this._message; }
            set { this._message = value; }
        }

        public CPL3020U02ImportFileResult() { }

    }
}