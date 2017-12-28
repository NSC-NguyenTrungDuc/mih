using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class CheckDuplicateDataINV0101Result : AbstractContractResult
    {
        private String _checkMaster;
        private String _checkDetail;

        public String CheckMaster
        {
            get { return this._checkMaster; }
            set { this._checkMaster = value; }
        }

        public String CheckDetail
        {
            get { return this._checkDetail; }
            set { this._checkDetail = value; }
        }

        public CheckDuplicateDataINV0101Result() { }

    }
}