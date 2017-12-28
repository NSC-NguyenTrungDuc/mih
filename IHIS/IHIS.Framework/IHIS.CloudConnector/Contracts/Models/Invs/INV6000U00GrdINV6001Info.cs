using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV6000U00GrdINV6001Info
    {
        private String _jaeryoCode;
        private String _jaeryoName;
        private String _preMJaegoQty;
        private String _ipgoQty;
        private String _chulgoQty;
        private String _jaegoQty;
        private String _existCnt;
        private String _deltaQty;
        private String _subulDanuiName;
        private String _danga;
        private String _adjAmt;

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

        public String ExistCnt
        {
            get { return this._existCnt; }
            set { this._existCnt = value; }
        }

        public String DeltaQty
        {
            get { return this._deltaQty; }
            set { this._deltaQty = value; }
        }

        public String SubulDanuiName
        {
            get { return this._subulDanuiName; }
            set { this._subulDanuiName = value; }
        }

        public String Danga
        {
            get { return this._danga; }
            set { this._danga = value; }
        }

        public String AdjAmt
        {
            get { return this._adjAmt; }
            set { this._adjAmt = value; }
        }

        public INV6000U00GrdINV6001Info() { }

        public INV6000U00GrdINV6001Info(String jaeryoCode, String jaeryoName, String preMJaegoQty, String ipgoQty, String chulgoQty, String jaegoQty, String existCnt, String deltaQty, String subulDanuiName, String danga, String adjAmt)
        {
            this._jaeryoCode = jaeryoCode;
            this._jaeryoName = jaeryoName;
            this._preMJaegoQty = preMJaegoQty;
            this._ipgoQty = ipgoQty;
            this._chulgoQty = chulgoQty;
            this._jaegoQty = jaegoQty;
            this._existCnt = existCnt;
            this._deltaQty = deltaQty;
            this._subulDanuiName = subulDanuiName;
            this._danga = danga;
            this._adjAmt = adjAmt;
        }

    }
}