using System;

namespace IHIS.CloudConnector.Contracts.Models.Clis
{
    [Serializable]
    public class CLIS2015U02GrdStatusInfo
    {
        private String _protocolId;
        private String _statusId;
        private String _statusCode;
        private String _statusName;
        private String _sortNo;
        private String _displayFlg;
        private String _rowState;

        public String ProtocolId
        {
            get { return this._protocolId; }
            set { this._protocolId = value; }
        }

        public String StatusId
        {
            get { return this._statusId; }
            set { this._statusId = value; }
        }

        public String StatusCode
        {
            get { return this._statusCode; }
            set { this._statusCode = value; }
        }

        public String StatusName
        {
            get { return this._statusName; }
            set { this._statusName = value; }
        }

        public String SortNo
        {
            get { return this._sortNo; }
            set { this._sortNo = value; }
        }

        public String DisplayFlg
        {
            get { return this._displayFlg; }
            set { this._displayFlg = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public CLIS2015U02GrdStatusInfo() { }

        public CLIS2015U02GrdStatusInfo(String protocolId, String statusId, String statusCode, String statusName, String sortNo, String displayFlg, String rowState)
        {
            this._protocolId = protocolId;
            this._statusId = statusId;
            this._statusCode = statusCode;
            this._statusName = statusName;
            this._sortNo = sortNo;
            this._displayFlg = displayFlg;
            this._rowState = rowState;
        }

    }
}