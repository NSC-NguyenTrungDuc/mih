using System;

namespace IHIS.CloudConnector.Contracts.Models.Phys
{
    [Serializable]
    public class PHY8002U01BtnPrintGetDataWindowInfo
    {
        private String _yoyangName;
        private String _simpleYoyangName;
        private String _tel;
        private String _homepage;

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
        }

        public String SimpleYoyangName
        {
            get { return this._simpleYoyangName; }
            set { this._simpleYoyangName = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public String Homepage
        {
            get { return this._homepage; }
            set { this._homepage = value; }
        }

        public PHY8002U01BtnPrintGetDataWindowInfo() { }

        public PHY8002U01BtnPrintGetDataWindowInfo(String yoyangName, String simpleYoyangName, String tel, String homepage)
        {
            this._yoyangName = yoyangName;
            this._simpleYoyangName = simpleYoyangName;
            this._tel = tel;
            this._homepage = homepage;
        }

    }
}