using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class ADM103LaySysListGrpResult : AbstractContractResult
    {
        private List<ADM103LaySysListGrpInfo> _grpItem = new List<ADM103LaySysListGrpInfo>();

        public List<ADM103LaySysListGrpInfo> GrpItem
        {
            get { return this._grpItem; }
            set { this._grpItem = value; }
        }

        public ADM103LaySysListGrpResult() { }

    }
}