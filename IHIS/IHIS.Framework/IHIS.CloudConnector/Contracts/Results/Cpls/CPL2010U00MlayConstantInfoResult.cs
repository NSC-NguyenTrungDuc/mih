using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010U00MlayConstantInfoResult : AbstractContractResult
    {
        private List<CPL2010U00MlayConstantInfoListItemInfo> _mLayConstantInfoList = new List<CPL2010U00MlayConstantInfoListItemInfo>();

        public List<CPL2010U00MlayConstantInfoListItemInfo> MLayConstantInfoList
        {
            get { return this._mLayConstantInfoList; }
            set { this._mLayConstantInfoList = value; }
        }

        public CPL2010U00MlayConstantInfoResult() { }

    }
}