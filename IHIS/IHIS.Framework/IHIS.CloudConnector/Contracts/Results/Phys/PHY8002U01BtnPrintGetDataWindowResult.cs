using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY8002U01BtnPrintGetDataWindowResult : AbstractContractResult
    {
        private List<PHY8002U01BtnPrintGetDataWindowInfo> _infoList = new List<PHY8002U01BtnPrintGetDataWindowInfo>();

        public List<PHY8002U01BtnPrintGetDataWindowInfo> InfoList
        {
            get { return this._infoList; }
            set { this._infoList = value; }
        }

        public PHY8002U01BtnPrintGetDataWindowResult() { }

    }
}