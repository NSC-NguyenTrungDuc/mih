using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010U00LayBarcodeTemp2Result : AbstractContractResult
    {
        private List<CPL2010U00LayBarcodeTempListItemInfo> _layList = new List<CPL2010U00LayBarcodeTempListItemInfo>();

        public List<CPL2010U00LayBarcodeTempListItemInfo> LayList
        {
            get { return this._layList; }
            set { this._layList = value; }
        }

        public CPL2010U00LayBarcodeTemp2Result() { }

    }
}