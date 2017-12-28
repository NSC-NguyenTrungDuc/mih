using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV6000U00ExportCSVInfo
    {
        private String _rowNum;
        private String _jaeryoCode;
        private String _jaeryoName;
        private String _ipgoDanuiName;
        private String _danga;
        private String _preMJaegoQty;
        private String _ipgoQty;
        private String _chulgoQty;
        private String _jaegoQty;
        private String _adjAmt;
        private String _dangaJaegoQty;

        public String RowNum
        {
            get { return this._rowNum; }
            set { this._rowNum = value; }
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

        public String IpgoDanuiName
        {
            get { return this._ipgoDanuiName; }
            set { this._ipgoDanuiName = value; }
        }

        public String Danga
        {
            get { return this._danga; }
            set { this._danga = value; }
        }

        public String PreMJaegoQty
        {
            get { return this._preMJaegoQty; }
            set { this._preMJaegoQty = value; }
        }

        public String IpgoQty
        {
            get { return this._ipgoQty; }
            set { this._ipgoQty = value; }
        }

        public String ChulgoQty
        {
            get { return this._chulgoQty; }
            set { this._chulgoQty = value; }
        }

        public String JaegoQty
        {
            get { return this._jaegoQty; }
            set { this._jaegoQty = value; }
        }

        public String AdjAmt
        {
            get { return this._adjAmt; }
            set { this._adjAmt = value; }
        }

        public String DangaJaegoQty
        {
            get { return this._dangaJaegoQty; }
            set { this._dangaJaegoQty = value; }
        }

        public INV6000U00ExportCSVInfo() { }

        public INV6000U00ExportCSVInfo(String rowNum, String jaeryoCode, String jaeryoName, String ipgoDanuiName, String danga, String preMJaegoQty, String ipgoQty, String chulgoQty, String jaegoQty, String adjAmt, String dangaJaegoQty)
        {
            this._rowNum = rowNum;
            this._jaeryoCode = jaeryoCode;
            this._jaeryoName = jaeryoName;
            this._ipgoDanuiName = ipgoDanuiName;
            this._danga = danga;
            this._preMJaegoQty = preMJaegoQty;
            this._ipgoQty = ipgoQty;
            this._chulgoQty = chulgoQty;
            this._jaegoQty = jaegoQty;
            this._adjAmt = adjAmt;
            this._dangaJaegoQty = dangaJaegoQty;
        }

    }
}