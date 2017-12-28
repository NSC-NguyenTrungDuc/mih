using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class FwBizObjectXPaCommentLayCmmtGubunfwkResult : AbstractContractResult
    {
        private List<FwBizObjectXPaCommentLayCmmtGubunfwkInfo> _layCmtGubunItem = new List<FwBizObjectXPaCommentLayCmmtGubunfwkInfo>();

        public List<FwBizObjectXPaCommentLayCmmtGubunfwkInfo> LayCmtGubunItem
        {
            get { return this._layCmtGubunItem; }
            set { this._layCmtGubunItem = value; }
        }

        public FwBizObjectXPaCommentLayCmmtGubunfwkResult() { }

    }
}