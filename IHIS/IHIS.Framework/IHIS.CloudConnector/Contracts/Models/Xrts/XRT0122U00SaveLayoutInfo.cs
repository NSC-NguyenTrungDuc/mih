using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT0122U00SaveLayoutInfo
    {
        private String _callerId;
        private String _buwiBunryu;
        private String _buwiBunryuName;
        private String _buwiCode;
        private String _buwiName;
        private String _sortSeq;
        private String _rowState;

        public String CallerId
        {
            get { return this._callerId; }
            set { this._callerId = value; }
        }

        public String BuwiBunryu
        {
            get { return this._buwiBunryu; }
            set { this._buwiBunryu = value; }
        }

        public String BuwiBunryuName
        {
            get { return this._buwiBunryuName; }
            set { this._buwiBunryuName = value; }
        }

        public String BuwiCode
        {
            get { return this._buwiCode; }
            set { this._buwiCode = value; }
        }

        public String BuwiName
        {
            get { return this._buwiName; }
            set { this._buwiName = value; }
        }

        public String SortSeq
        {
            get { return this._sortSeq; }
            set { this._sortSeq = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public XRT0122U00SaveLayoutInfo() { }

        public XRT0122U00SaveLayoutInfo(String callerId, String buwiBunryu, String buwiBunryuName, String buwiCode, String buwiName, String sortSeq, String rowState)
        {
            this._callerId = callerId;
            this._buwiBunryu = buwiBunryu;
            this._buwiBunryuName = buwiBunryuName;
            this._buwiCode = buwiCode;
            this._buwiName = buwiName;
            this._sortSeq = sortSeq;
            this._rowState = rowState;
        }

    }
}