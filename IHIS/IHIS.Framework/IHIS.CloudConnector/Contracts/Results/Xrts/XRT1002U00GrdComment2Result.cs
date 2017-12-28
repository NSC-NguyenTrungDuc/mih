using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT1002U00GrdComment2Result : AbstractContractResult
    {
        private List<XRT1002U00GrdCommentInfo> _grdCommentItem = new List<XRT1002U00GrdCommentInfo>();

        public List<XRT1002U00GrdCommentInfo> GrdCommentItem
        {
            get { return this._grdCommentItem; }
            set { this._grdCommentItem = value; }
        }

        public XRT1002U00GrdComment2Result() { }

    }
}