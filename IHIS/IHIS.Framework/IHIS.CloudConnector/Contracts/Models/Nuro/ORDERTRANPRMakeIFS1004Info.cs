using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANPRMakeIFS1004Info
    {
        private String _hospCode;
        private String _ioGubun;
        private String _pkout1003;
        private String _transYn;
        private String _transGubun;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public String Pkout1003
        {
            get { return this._pkout1003; }
            set { this._pkout1003 = value; }
        }

        public String TransYn
        {
            get { return this._transYn; }
            set { this._transYn = value; }
        }

        public String TransGubun
        {
            get { return this._transGubun; }
            set { this._transGubun = value; }
        }

        public ORDERTRANPRMakeIFS1004Info() { }

        public ORDERTRANPRMakeIFS1004Info(String hospCode, String ioGubun, String pkout1003, String transYn, String transGubun)
        {
            this._hospCode = hospCode;
            this._ioGubun = ioGubun;
            this._pkout1003 = pkout1003;
            this._transYn = transYn;
            this._transGubun = transGubun;
        }

    }
}