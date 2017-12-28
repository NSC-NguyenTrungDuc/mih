using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010R00GetBarCodeResult : AbstractContractResult
    {
        private List<CPL2010R00GetBarCodeInfo> _listItem = new List<CPL2010R00GetBarCodeInfo>();

        public List<CPL2010R00GetBarCodeInfo> ListItem
        {
            get { return this._listItem; }
            set { this._listItem = value; }
        }

        public CPL2010R00GetBarCodeResult() { }

    }
}