using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL3010U01LayPrint2Result : AbstractContractResult
    {
        private List<CPL3010U01LayPrint2Info> _layPrintLst = new List<CPL3010U01LayPrint2Info>();

        public List<CPL3010U01LayPrint2Info> LayPrintLst
        {
            get { return this._layPrintLst; }
            set { this._layPrintLst = value; }
        }

        public CPL3010U01LayPrint2Result() { }

    }
}