using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class MdiFormOpenMainScreenResult : AbstractContractResult
    {
        private List<MdiFormOpenMainScreenInfo> _mainScreenItem = new List<MdiFormOpenMainScreenInfo>();

        public List<MdiFormOpenMainScreenInfo> MainScreenItem
        {
            get { return this._mainScreenItem; }
            set { this._mainScreenItem = value; }
        }

        public MdiFormOpenMainScreenResult() { }

    }
}