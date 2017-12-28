using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV4001U00Grd4002Info
    {
        private String _pkinv4002;
        private String _fkinv4001;
        private String _jaeryoCode;
        private String _jaeryoName;
        private String _ipgoQty;
        private String _ipgoDanui;
        private String _ipgoDanga;
        private String _remark;
        private String _sumDanga;
        private String _startDate;
        private String _lot;
        private String _endDate;
        private String _rowState;

        public String Pkinv4002
        {
            get { return this._pkinv4002; }
            set { this._pkinv4002 = value; }
        }

        public String Fkinv4001
        {
            get { return this._fkinv4001; }
            set { this._fkinv4001 = value; }
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

        public String IpgoQty
        {
            get { return this._ipgoQty; }
            set { this._ipgoQty = value; }
        }

        public String IpgoDanui
        {
            get { return this._ipgoDanui; }
            set { this._ipgoDanui = value; }
        }

        public String IpgoDanga
        {
            get { return this._ipgoDanga; }
            set { this._ipgoDanga = value; }
        }

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String SumDanga
        {
            get { return this._sumDanga; }
            set { this._sumDanga = value; }
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

        public String EndDate
        {
            get { return this._endDate; }
            set { this._endDate = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public INV4001U00Grd4002Info() { }

        public INV4001U00Grd4002Info(String pkinv4002, String fkinv4001, String jaeryoCode, String jaeryoName, String ipgoQty, String ipgoDanui, String ipgoDanga, String remark, String sumDanga, String startDate, String lot, String endDate, String rowState)
        {
            this._pkinv4002 = pkinv4002;
            this._fkinv4001 = fkinv4001;
            this._jaeryoCode = jaeryoCode;
            this._jaeryoName = jaeryoName;
            this._ipgoQty = ipgoQty;
            this._ipgoDanui = ipgoDanui;
            this._ipgoDanga = ipgoDanga;
            this._remark = remark;
            this._sumDanga = sumDanga;
            this._startDate = startDate;
            this._lot = lot;
            this._endDate = endDate;
            this._rowState = rowState;
        }

    }
}