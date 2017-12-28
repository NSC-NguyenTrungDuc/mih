using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    public class LoadCbxLanguageResult : AbstractContractResult
    {
        private List<LoadCbxLanguageInfo> _listInfo = new List<LoadCbxLanguageInfo>();

        public List<LoadCbxLanguageInfo> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public LoadCbxLanguageResult() { }

    }
}