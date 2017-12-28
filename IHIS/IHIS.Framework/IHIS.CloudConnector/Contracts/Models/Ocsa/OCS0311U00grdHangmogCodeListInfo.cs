using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0311U00grdHangmogCodeListInfo
    {
        private String _setPart;
        private String _hangmogCode;
        private String _hangmogName;
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

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public OCS0311U00grdHangmogCodeListInfo() { }

        public OCS0311U00grdHangmogCodeListInfo(String setPart, String hangmogCode, String hangmogName, String rowState)
        {
            this._setPart = setPart;
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._rowState = rowState;
        }

    }
}