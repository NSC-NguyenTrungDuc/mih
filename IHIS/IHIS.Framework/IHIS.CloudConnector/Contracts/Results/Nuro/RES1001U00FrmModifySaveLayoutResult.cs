using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class RES1001U00FrmModifySaveLayoutResult : AbstractContractResult
    {
        private Boolean _result;
        private String _errCode;
        private String _doctorName;

        public Boolean Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public String ErrCode
        {
            get { return this._errCode; }
            set { this._errCode = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public RES1001U00FrmModifySaveLayoutResult() { }

    }
}