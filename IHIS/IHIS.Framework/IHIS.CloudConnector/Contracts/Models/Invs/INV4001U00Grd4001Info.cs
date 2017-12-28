using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV4001U00Grd4001Info
    {
        private String _pkinv4001;
        private String _churiDate;
        private String _importTime;
        private String _churiBuseo;
        private String _ipgoType;
        private String _importCode;
        private String _churiSeq;
        private String _jaeryoGubun;
        private String _remark;
        private String _inOutGubun;
        private String _ipchulType;
        private String _inputUser;
        private String _rowState;

        public String Pkinv4001
        {
            get { return this._pkinv4001; }
            set { this._pkinv4001 = value; }
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

        public String ChuriBuseo
        {
            get { return this._churiBuseo; }
            set { this._churiBuseo = value; }
        }

        public String IpgoType
        {
            get { return this._ipgoType; }
            set { this._ipgoType = value; }
        }

        public String ImportCode
        {
            get { return this._importCode; }
            set { this._importCode = value; }
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

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public String IpchulType
        {
            get { return this._ipchulType; }
            set { this._ipchulType = value; }
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

        public INV4001U00Grd4001Info() { }

        public INV4001U00Grd4001Info(String pkinv4001, String churiDate, String importTime, String churiBuseo, String ipgoType, String importCode, String churiSeq, String jaeryoGubun, String remark, String inOutGubun, String ipchulType, String inputUser, String rowState)
        {
            this._pkinv4001 = pkinv4001;
            this._churiDate = churiDate;
            this._importTime = importTime;
            this._churiBuseo = churiBuseo;
            this._ipgoType = ipgoType;
            this._importCode = importCode;
            this._churiSeq = churiSeq;
            this._jaeryoGubun = jaeryoGubun;
            this._remark = remark;
            this._inOutGubun = inOutGubun;
            this._ipchulType = ipchulType;
            this._inputUser = inputUser;
            this._rowState = rowState;
        }

    }
}