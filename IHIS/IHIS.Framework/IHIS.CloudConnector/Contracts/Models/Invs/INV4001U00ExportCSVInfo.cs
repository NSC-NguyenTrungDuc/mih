using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV4001U00ExportCSVInfo
    {
        private String _rowNum;
        private String _churiDate;
        private String _importTime;
        private String _jaeryoCode;
        private String _jaeryoName;
        private String _startDate;
        private String _lot;
        private String _expiredDate;
        private String _ipgoQty;
        private String _ipgoDanuiName;
        private String _ipgoType;
        private String _updId;
        private String _ipgoDanga;
        private String _qtyIpgoDanga;
        private String _importCode;
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

        public String ImportTime
        {
            get { return this._importTime; }
            set { this._importTime = value; }
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

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String Lot
        {
            get { return this._lot; }
            set { this._lot = value; }
        }

        public String ExpiredDate
        {
            get { return this._expiredDate; }
            set { this._expiredDate = value; }
        }

        public String IpgoQty
        {
            get { return this._ipgoQty; }
            set { this._ipgoQty = value; }
        }

        public String IpgoDanuiName
        {
            get { return this._ipgoDanuiName; }
            set { this._ipgoDanuiName = value; }
        }

        public String IpgoType
        {
            get { return this._ipgoType; }
            set { this._ipgoType = value; }
        }

        public String UpdId
        {
            get { return this._updId; }
            set { this._updId = value; }
        }

        public String IpgoDanga
        {
            get { return this._ipgoDanga; }
            set { this._ipgoDanga = value; }
        }

        public String QtyIpgoDanga
        {
            get { return this._qtyIpgoDanga; }
            set { this._qtyIpgoDanga = value; }
        }

        public String ImportCode
        {
            get { return this._importCode; }
            set { this._importCode = value; }
        }

        public String Comment
        {
            get { return this._comment; }
            set { this._comment = value; }
        }

        public INV4001U00ExportCSVInfo() { }

        public INV4001U00ExportCSVInfo(String rowNum, String churiDate, String importTime, String jaeryoCode, String jaeryoName, String startDate, String lot, String expiredDate, String ipgoQty, String ipgoDanuiName, String ipgoType, String updId, String ipgoDanga, String qtyIpgoDanga, String importCode, String comment)
        {
            this._rowNum = rowNum;
            this._churiDate = churiDate;
            this._importTime = importTime;
            this._jaeryoCode = jaeryoCode;
            this._jaeryoName = jaeryoName;
            this._startDate = startDate;
            this._lot = lot;
            this._expiredDate = expiredDate;
            this._ipgoQty = ipgoQty;
            this._ipgoDanuiName = ipgoDanuiName;
            this._ipgoType = ipgoType;
            this._updId = updId;
            this._ipgoDanga = ipgoDanga;
            this._qtyIpgoDanga = qtyIpgoDanga;
            this._importCode = importCode;
            this._comment = comment;
        }

    }
}