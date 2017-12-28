using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class OUT0101U02GetPatientCodeResult : AbstractContractResult
    {
        private Boolean _result;
        private String _autoBunhoFlg;
        private String _patientCode;

        public Boolean Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public String AutoBunhoFlg
        {
            get { return this._autoBunhoFlg; }
            set { this._autoBunhoFlg = value; }
        }

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public OUT0101U02GetPatientCodeResult() { }

    }
}