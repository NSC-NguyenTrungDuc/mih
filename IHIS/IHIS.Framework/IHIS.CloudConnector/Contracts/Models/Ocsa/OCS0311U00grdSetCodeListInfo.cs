using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0311U00grdSetCodeListInfo
    {
        private String _setPart;
        private String _hangmogCode;
        private String _setCode;
        private String _comments;
        private String _setCodeName;
        private String _rowState;

        public String SetPart
        {
            get { return this._setPart; }
            set { this._setPart = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String SetCode
        {
            get { return this._setCode; }
            set { this._setCode = value; }
        }

        public String Comments
        {
            get { return this._comments; }
            set { this._comments = value; }
        }

        public String SetCodeName
        {
            get { return this._setCodeName; }
            set { this._setCodeName = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public OCS0311U00grdSetCodeListInfo() { }

        public OCS0311U00grdSetCodeListInfo(String setPart, String hangmogCode, String setCode, String comments, String setCodeName, String rowState)
        {
            this._setPart = setPart;
            this._hangmogCode = hangmogCode;
            this._setCode = setCode;
            this._comments = comments;
            this._setCodeName = setCodeName;
            this._rowState = rowState;
        }

    }
}