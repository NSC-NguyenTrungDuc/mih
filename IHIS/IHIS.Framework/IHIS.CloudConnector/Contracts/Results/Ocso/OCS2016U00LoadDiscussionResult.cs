using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCS2016U00LoadDiscussionResult : AbstractContractResult
    {
        private List<OCS2016U00LoadDiscussionInfo> _itemDiscussionInfo = new List<OCS2016U00LoadDiscussionInfo>();

        public List<OCS2016U00LoadDiscussionInfo> ItemDiscussionInfo
        {
            get { return this._itemDiscussionInfo; }
            set { this._itemDiscussionInfo = value; }
        }

        public OCS2016U00LoadDiscussionResult() { }

    }
}