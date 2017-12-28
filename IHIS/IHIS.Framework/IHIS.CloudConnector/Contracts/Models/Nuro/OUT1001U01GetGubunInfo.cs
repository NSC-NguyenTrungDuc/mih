using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class OUT1001U01GetGubunInfo
    {
        private String _gubun;
        private String _gubunName;

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String GubunName
        {
            get { return this._gubunName; }
            set { this._gubunName = value; }
        }

        public OUT1001U01GetGubunInfo() { }

        public OUT1001U01GetGubunInfo(String gubun, String gubunName)
        {
            this._gubun = gubun;
            this._gubunName = gubunName;
        }

    }
}