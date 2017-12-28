using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class DetailPaInfoFormGridVisitListResult : AbstractContractResult
    {
        private List<DetailPaInfoFormGridVisitListInfo> _gridVisitItem = new List<DetailPaInfoFormGridVisitListInfo>();

        public List<DetailPaInfoFormGridVisitListInfo> GridVisitItem
        {
            get { return this._gridVisitItem; }
            set { this._gridVisitItem = value; }
        }

        public DetailPaInfoFormGridVisitListResult() { }

    }
}
