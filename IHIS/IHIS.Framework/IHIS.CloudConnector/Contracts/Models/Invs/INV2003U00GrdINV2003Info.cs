using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV2003U00GrdINV2003Info
    {
        private String _pkinv2003;
        private String _churiDate;
        private String _churiTime;
        private String _churiBuseo;
        private String _chulgoType;
        private String _exportCode;
        private String _churiSeq;
        private String _jaeryoGubun;
        private String _ipchulType;
        private String _inOutGubun;
        private String _remark;
        private String _inputUser;
        private String _rowState;

        public String Pkinv2003
        {
            get { return this._pkinv2003; }
            set { this._pkinv2003 = value; }
        }

        public String ChuriDate
        {
            get { return this._churiDate; }
            set { this._churiDate = value; }
        }

        public String ChuriTime
        {
            get { return this._churiTime; }
            set { this._churiTime = value; }
        }

        public String ChuriBuseo
        {
            get { return this._churiBuseo; }
            set { this._churiBuseo = value; }
        }

        public String ChulgoType
        {
            get { return this._chulgoType; }
            set { this._chulgoType = value; }
        }

        public String ExportCode
        {
            get { return this._exportCode; }
            set { this._exportCode = value; }
        }

        public String ChuriSeq
        {
            get { return this._churiSeq; }
            set { this._churiSeq = value; }
        }

        public String JaeryoGubun
        {
            get { return this._jaeryoGubun; }
            set { this._jaeryoGubun = value; }
        }

        public String IpchulType
        {
            get { return this._ipchulType; }
            set { this._ipchulType = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String InputUser
        {
            get { return this._inputUser; }
            set { this._inputUser = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public INV2003U00GrdINV2003Info() { }

        public INV2003U00GrdINV2003Info(String pkinv2003, String churiDate, String churiTime, String churiBuseo, String chulgoType, String exportCode, String churiSeq, String jaeryoGubun, String ipchulType, String inOutGubun, String remark, String inputUser, String rowState)
        {
            this._pkinv2003 = pkinv2003;
            this._churiDate = churiDate;
            this._churiTime = churiTime;
            this._churiBuseo = churiBuseo;
            this._chulgoType = chulgoType;
            this._exportCode = exportCode;
            this._churiSeq = churiSeq;
            this._jaeryoGubun = jaeryoGubun;
            this._ipchulType = ipchulType;
            this._inOutGubun = inOutGubun;
            this._remark = remark;
            this._inputUser = inputUser;
            this._rowState = rowState;
        }

    }
}