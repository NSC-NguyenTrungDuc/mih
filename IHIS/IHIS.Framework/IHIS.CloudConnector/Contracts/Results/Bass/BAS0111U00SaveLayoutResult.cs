using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0111U00SaveLayoutResult : AbstractContractResult
    {
        private Boolean _result;
        private String _johapGubun;
        private String _johap;
        private String _gaein;
        private String _errFlag;

        public Boolean Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public String JohapGubun
        {
            get { return this._johapGubun; }
            set { this._johapGubun = value; }
        }

        public String Johap
        {
            get { return this._johap; }
            set { this._johap = value; }
        }

        public String Gaein
        {
            get { return this._gaein; }
            set { this._gaein = value; }
        }

        public String ErrFlag
        {
            get { return this._errFlag; }
            set { this._errFlag = value; }
        }

        public BAS0111U00SaveLayoutResult() { }

    }
}