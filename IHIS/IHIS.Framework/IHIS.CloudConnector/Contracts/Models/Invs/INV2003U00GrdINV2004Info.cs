using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV2003U00GrdINV2004Info
    {
        private String _pkinv2004;
        private String _fkinv2003;
        private String _jaeryoCode;
        private String _jaeryoName;
        private String _chulgoQty;
        private String _chulgoDanuiName;
        private String _chulgoDanga;
        private String _remark;
        private String _rowState;

        public String Pkinv2004
        {
            get { return this._pkinv2004; }
            set { this._pkinv2004 = value; }
        }

        public String Fkinv2003
        {
            get { return this._fkinv2003; }
            set { this._fkinv2003 = value; }
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

        public String ChulgoDanuiName
        {
            get { return this._chulgoDanuiName; }
            set { this._chulgoDanuiName = value; }
        }

        public String ChulgoDanga
        {
            get { return this._chulgoDanga; }
            set { this._chulgoDanga = value; }
        }

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public INV2003U00GrdINV2004Info() { }

        public INV2003U00GrdINV2004Info(String pkinv2004, String fkinv2003, String jaeryoCode, String jaeryoName, String chulgoQty, String chulgoDanuiName, String chulgoDanga, String remark, String rowState)
        {
            this._pkinv2004 = pkinv2004;
            this._fkinv2003 = fkinv2003;
            this._jaeryoCode = jaeryoCode;
            this._jaeryoName = jaeryoName;
            this._chulgoQty = chulgoQty;
            this._chulgoDanuiName = chulgoDanuiName;
            this._chulgoDanga = chulgoDanga;
            this._remark = remark;
            this._rowState = rowState;
        }

    }
}