using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV2003U00ExportCSVInfo
    {
        private String _rowNum;
        private String _churiDate;
        private String _exportTime;
        private String _jaeryoCode;
        private String _jaeryoName;
        private String _chulgoQty;
        private String _ipgoDanuiName;
        private String _chulgoType;
        private String _updId;
        private String _exportCode;
        private String _comment;

        public String RowNum
        {
            get { return this._rowNum; }
            set { this._rowNum = value; }
        }

        public String ChuriDate
        {
            get { return this._churiDate; }
            set { this._churiDate = value; }
        }

        public String ExportTime
        {
            get { return this._exportTime; }
            set { this._exportTime = value; }
        }

        public String JaeryoCode
        {
            get { return this._jaeryoCode; }
            set { this._jaeryoCode = value; }
        }

        public String JaeryoName
        {
            get { return this._jaeryoName; }
            set { this._jaeryoName = value; }
        }

        public String ChulgoQty
        {
            get { return this._chulgoQty; }
            set { this._chulgoQty = value; }
        }

        public String IpgoDanuiName
        {
            get { return this._ipgoDanuiName; }
            set { this._ipgoDanuiName = value; }
        }

        public String ChulgoType
        {
            get { return this._chulgoType; }
            set { this._chulgoType = value; }
        }

        public String UpdId
        {
            get { return this._updId; }
            set { this._updId = value; }
        }

        public String ExportCode
        {
            get { return this._exportCode; }
            set { this._exportCode = value; }
        }

        public String Comment
        {
            get { return this._comment; }
            set { this._comment = value; }
        }

        public INV2003U00ExportCSVInfo() { }

        public INV2003U00ExportCSVInfo(String rowNum, String churiDate, String exportTime, String jaeryoCode, String jaeryoName, String chulgoQty, String ipgoDanuiName, String chulgoType, String updId, String exportCode, String comment)
        {
            this._rowNum = rowNum;
            this._churiDate = churiDate;
            this._exportTime = exportTime;
            this._jaeryoCode = jaeryoCode;
            this._jaeryoName = jaeryoName;
            this._chulgoQty = chulgoQty;
            this._ipgoDanuiName = ipgoDanuiName;
            this._chulgoType = chulgoType;
            this._updId = updId;
            this._exportCode = exportCode;
            this._comment = comment;
        }

    }
}