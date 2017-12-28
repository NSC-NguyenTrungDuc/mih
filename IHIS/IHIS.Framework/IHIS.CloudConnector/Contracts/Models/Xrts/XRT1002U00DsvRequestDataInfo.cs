using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT1002U00DsvRequestDataInfo
    {
        private String _fkocs;
        private String _inOutGubun;
        private String _hangmogCode;
        private String _bunho;
        private String _gumsaMokjuk;
        private String _xrayMethod;
        private String _pandokRequestYn;
        private String _buhaGubun;

        public String Fkocs
        {
            get { return this._fkocs; }
            set { this._fkocs = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String GumsaMokjuk
        {
            get { return this._gumsaMokjuk; }
            set { this._gumsaMokjuk = value; }
        }

        public String XrayMethod
        {
            get { return this._xrayMethod; }
            set { this._xrayMethod = value; }
        }

        public String PandokRequestYn
        {
            get { return this._pandokRequestYn; }
            set { this._pandokRequestYn = value; }
        }

        public String BuhaGubun
        {
            get { return this._buhaGubun; }
            set { this._buhaGubun = value; }
        }

        public XRT1002U00DsvRequestDataInfo() { }

        public XRT1002U00DsvRequestDataInfo(String fkocs, String inOutGubun, String hangmogCode, String bunho, String gumsaMokjuk, String xrayMethod, String pandokRequestYn, String buhaGubun)
        {
            this._fkocs = fkocs;
            this._inOutGubun = inOutGubun;
            this._hangmogCode = hangmogCode;
            this._bunho = bunho;
            this._gumsaMokjuk = gumsaMokjuk;
            this._xrayMethod = xrayMethod;
            this._pandokRequestYn = pandokRequestYn;
            this._buhaGubun = buhaGubun;
        }

    }
}