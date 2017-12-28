using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT1002U00DsvXrayGubunInfo
    {
        private String _xrayGubun;
        private String _xrayName;
        private String _requestYn;

        public String XrayGubun
        {
            get { return this._xrayGubun; }
            set { this._xrayGubun = value; }
        }

        public String XrayName
        {
            get { return this._xrayName; }
            set { this._xrayName = value; }
        }

        public String RequestYn
        {
            get { return this._requestYn; }
            set { this._requestYn = value; }
        }

        public XRT1002U00DsvXrayGubunInfo() { }

        public XRT1002U00DsvXrayGubunInfo(String xrayGubun, String xrayName, String requestYn)
        {
            this._xrayGubun = xrayGubun;
            this._xrayName = xrayName;
            this._requestYn = requestYn;
        }

    }
}