using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NUR2016U02GrdListInfo
    {
        private String _select;
        private String _hospCodeLink;
        private String _yoyangName;
        private String _bunhoLink;
        private String _suname;
        private String _address1;
        private String _birth;

        public String Select
        {
            get { return this._select; }
            set { this._select = value; }
        }

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
        }

        public String BunhoLink
        {
            get { return this._bunhoLink; }
            set { this._bunhoLink = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String Address1
        {
            get { return this._address1; }
            set { this._address1 = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public NUR2016U02GrdListInfo() { }

        public NUR2016U02GrdListInfo(String select, String hospCodeLink, String yoyangName, String bunhoLink, String suname, String address1, String birth)
        {
            this._select = select;
            this._hospCodeLink = hospCodeLink;
            this._yoyangName = yoyangName;
            this._bunhoLink = bunhoLink;
            this._suname = suname;
            this._address1 = address1;
            this._birth = birth;
        }

    }
}