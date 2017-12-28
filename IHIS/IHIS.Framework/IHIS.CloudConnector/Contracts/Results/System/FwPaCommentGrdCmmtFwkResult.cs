using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class FwPaCommentGrdCmmtFwkResult : AbstractContractResult
    {
        private List<FwPaCommentGrdCmmtFwkInfo> _grdCmmtFwkItem = new List<FwPaCommentGrdCmmtFwkInfo>();

        public List<FwPaCommentGrdCmmtFwkInfo> GrdCmmtFwkItem
        {
            get { return this._grdCmmtFwkItem; }
            set { this._grdCmmtFwkItem = value; }
        }

        public FwPaCommentGrdCmmtFwkResult() { }

    }
}