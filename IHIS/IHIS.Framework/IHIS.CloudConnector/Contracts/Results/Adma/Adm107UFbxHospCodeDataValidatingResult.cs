using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class Adm107UFbxHospCodeDataValidatingResult : AbstractContractResult
    {
        private String _yoyangName;

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
        }

        public Adm107UFbxHospCodeDataValidatingResult() { }

    }
}