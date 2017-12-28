using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010U00LayChkNamesResult : AbstractContractResult
    {
        private List<CPL2010U00LayChkNameListItemInfo> _layChkNamesList = new List<CPL2010U00LayChkNameListItemInfo>();

        public List<CPL2010U00LayChkNameListItemInfo> LayChkNamesList
        {
            get { return this._layChkNamesList; }
            set { this._layChkNamesList = value; }
        }

        public CPL2010U00LayChkNamesResult() { }

    }
}