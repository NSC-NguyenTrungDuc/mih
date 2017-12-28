using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class DetailPaInfoFormGridInsureResult : AbstractContractResult
    {
        private List<DetailPaInfoFormGridInsureInfo> _gridInsureItem = new List<DetailPaInfoFormGridInsureInfo>();

        public List<DetailPaInfoFormGridInsureInfo> GridInsureItem
        {
            get { return this._gridInsureItem; }
            set { this._gridInsureItem = value; }
        }

        public DetailPaInfoFormGridInsureResult() { }

    }
}
