using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class OUT1001P03BunhoListItemInfo
    {
        private String _bunho;
        private String _suname;
        private String _sex;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public OUT1001P03BunhoListItemInfo() { }

        public OUT1001P03BunhoListItemInfo(String bunho, String suname, String sex)
        {
            this._bunho = bunho;
            this._suname = suname;
            this._sex = sex;
        }

    }
}