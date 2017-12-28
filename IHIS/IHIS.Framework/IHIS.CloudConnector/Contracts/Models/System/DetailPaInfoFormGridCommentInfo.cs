using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class DetailPaInfoFormGridCommentInfo
    {
        private String _comment;

        public String Comment
        {
            get { return this._comment; }
            set { this._comment = value; }
        }

        public DetailPaInfoFormGridCommentInfo() { }

        public DetailPaInfoFormGridCommentInfo(String comment)
        {
            this._comment = comment;
        }
       
    }
}
