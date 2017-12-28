using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Clis
{
    [Serializable]
    public class CLIS2015U03PatientListDataValidatingResult : AbstractContractResult
    {
        private String _errMsg;
        private String _bunho;
        private String _suname;
        private String _suname2;

        public String ErrMsg
        {
            get { return this._errMsg; }
            set { this._errMsg = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String Suname2
        {
            get { return this._suname2; }
            set { this._suname2 = value; }
        }

        public CLIS2015U03PatientListDataValidatingResult() { }

    }
}