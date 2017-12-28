using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT1002U00GrdCommentInfo
    {
        private String _comments;

        public String Comments
        {
            get { return this._comments; }
            set { this._comments = value; }
        }

        public XRT1002U00GrdCommentInfo() { }

        public XRT1002U00GrdCommentInfo(String comments)
        {
            this._comments = comments;
        }

    }
}