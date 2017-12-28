using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY2001U04GrdPatientListItemValueChangingResult : AbstractContractResult
    {
        private Boolean _success;
        private String _result;
        private String _resultMsg;

        public Boolean Success
        {
            get { return this._success; }
            set { this._success = value; }
        }

        public String Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public String ResultMsg
        {
            get { return this._resultMsg; }
            set { this._resultMsg = value; }
        }

        public PHY2001U04GrdPatientListItemValueChangingResult() { }

    }
}