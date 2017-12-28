using System;

namespace IHIS.CloudConnector.Contracts.Models.INVS
{
    public class INV6002U00GrdINV6002BeforeInfo
    {
        private String _jaeryoCode;
        private String _jaeryoName;
        private String _subulDanuiName;
        private String _jaryoGubun;

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

        public String SubulDanuiName
        {
            get { return this._subulDanuiName; }
            set { this._subulDanuiName = value; }
        }

        public String JaryoGubun
        {
            get { return this._jaryoGubun; }
            set { this._jaryoGubun = value; }
        }

        public INV6002U00GrdINV6002BeforeInfo() { }

        public INV6002U00GrdINV6002BeforeInfo(String jaeryoCode, String jaeryoName, String subulDanuiName, String jaryoGubun)
        {
            this._jaeryoCode = jaeryoCode;
            this._jaeryoName = jaeryoName;
            this._subulDanuiName = subulDanuiName;
            this._jaryoGubun = jaryoGubun;
        }

    }
}