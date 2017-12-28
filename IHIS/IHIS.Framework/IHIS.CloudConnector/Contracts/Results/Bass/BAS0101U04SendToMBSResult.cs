using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    public class BAS0101U04SendToMBSResult : AbstractContractResult
    {
        private String _status;
        private String _message;

        public String Status
        {
            get { return this._status; }
            set { this._status = value; }
        }

        public String Message
        {
            get { return this._message; }
            set { this._message = value; }
        }

        public BAS0101U04SendToMBSResult() { }

    }
}