using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class DetailPaInfoFormGridCommentResult : AbstractContractResult
    {
        private List<DetailPaInfoFormGridCommentInfo> _commentItem = new List<DetailPaInfoFormGridCommentInfo>();

        public List<DetailPaInfoFormGridCommentInfo> CommentItem
        {
            get { return this._commentItem; }
            set { this._commentItem = value; }
        }

        public DetailPaInfoFormGridCommentResult() { }

    }

}
