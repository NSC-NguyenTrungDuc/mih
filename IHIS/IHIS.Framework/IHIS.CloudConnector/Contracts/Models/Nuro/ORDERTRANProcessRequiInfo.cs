using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANProcessRequiInfo
    {
        private String _hospCode;
        private String _pk1001;
        private String _gubun;
        private String _chojae;
        private String _sanjungGubun;
        private String _pkinp1002;
        private String _sysId;
        private String _bunho;
        private String _gongbiCode;
        private String _priority;
        private String _ioGubun;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Pk1001
        {
            get { return this._pk1001; }
            set { this._pk1001 = value; }
        }

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String Chojae
        {
            get { return this._chojae; }
            set { this._chojae = value; }
        }

        public String SanjungGubun
        {
            get { return this._sanjungGubun; }
            set { this._sanjungGubun = value; }
        }

        public String Pkinp1002
        {
            get { return this._pkinp1002; }
            set { this._pkinp1002 = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String GongbiCode
        {
            get { return this._gongbiCode; }
            set { this._gongbiCode = value; }
        }

        public String Priority
        {
            get { return this._priority; }
            set { this._priority = value; }
        }

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public ORDERTRANProcessRequiInfo() { }

        public ORDERTRANProcessRequiInfo(String hospCode, String pk1001, String gubun, String chojae, String sanjungGubun, String pkinp1002, String sysId, String bunho, String gongbiCode, String priority, String ioGubun)
        {
            this._hospCode = hospCode;
            this._pk1001 = pk1001;
            this._gubun = gubun;
            this._chojae = chojae;
            this._sanjungGubun = sanjungGubun;
            this._pkinp1002 = pkinp1002;
            this._sysId = sysId;
            this._bunho = bunho;
            this._gongbiCode = gongbiCode;
            this._priority = priority;
            this._ioGubun = ioGubun;
        }

    }
}