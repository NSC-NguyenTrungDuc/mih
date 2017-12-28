using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class RES1001U00CheckDuplicateResult : AbstractContractResult
    {
        private String _duplicateResult;
        private String _gwaName;
        private String _doctorName;

        public String DuplicateResult
        {
            get { return this._duplicateResult; }
            set { this._duplicateResult = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public RES1001U00CheckDuplicateResult() { }

    }
}