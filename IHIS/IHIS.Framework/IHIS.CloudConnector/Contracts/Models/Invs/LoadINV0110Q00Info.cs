using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class LoadINV0110Q00Info
    {
        private String _jaeryoCode;
        private String _jaeryoName;
        private String _subulDanui;
        private String _subulDanuiName;
        private String _subulDanga;

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

        public String SubulDanui
        {
            get { return this._subulDanui; }
            set { this._subulDanui = value; }
        }

        public String SubulDanuiName
        {
            get { return this._subulDanuiName; }
            set { this._subulDanuiName = value; }
        }

        public String SubulDanga
        {
            get { return this._subulDanga; }
            set { this._subulDanga = value; }
        }

        public LoadINV0110Q00Info() { }

        public LoadINV0110Q00Info(String jaeryoCode, String jaeryoName, String subulDanui, String subulDanuiName, String subulDanga)
        {
            this._jaeryoCode = jaeryoCode;
            this._jaeryoName = jaeryoName;
            this._subulDanui = subulDanui;
            this._subulDanuiName = subulDanuiName;
            this._subulDanga = subulDanga;
        }

    }
}