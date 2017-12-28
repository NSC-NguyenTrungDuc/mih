using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    public class ADM104QGetPatientResult : AbstractContractResult
    {
        private Boolean _exist;
        private String _userName;

        public Boolean Exist
        {
            get { return this._exist; }
            set { this._exist = value; }
        }

        public String UserName
        {
            get { return this._userName; }
            set { this._userName = value; }
        }

        public ADM104QGetPatientResult() { }

    }
}