using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class OUT0101U02SaveGridResult : AbstractContractResult
    {
        private String _errCode;
        private String _newPatientCode;
        private Boolean _result;

        public String ErrCode
        {
            get { return this._errCode; }
            set { this._errCode = value; }
        }

        public String NewPatientCode
        {
            get { return this._newPatientCode; }
            set { this._newPatientCode = value; }
        }

        public Boolean Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public OUT0101U02SaveGridResult() { }

    }
}