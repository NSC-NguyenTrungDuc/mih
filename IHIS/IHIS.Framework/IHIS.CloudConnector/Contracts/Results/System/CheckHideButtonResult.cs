using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class CheckHideButtonResult : AbstractContractResult
    {
        private List<CheckHideButtonInfo> _dt = new List<CheckHideButtonInfo>();

        public List<CheckHideButtonInfo> Dt
        {
            get { return this._dt; }
            set { this._dt = value; }
        }

        public CheckHideButtonResult() { }

    }
}