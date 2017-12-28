using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NUROAccountForcedEndInfo
    {
        private String _sunabDate;
        private String _fkout1003;
        private String _pkocs1003;

        public String SunabDate
        {
            get { return this._sunabDate; }
            set { this._sunabDate = value; }
        }

        public String Fkout1003
        {
            get { return this._fkout1003; }
            set { this._fkout1003 = value; }
        }

        public String Pkocs1003
        {
            get { return this._pkocs1003; }
            set { this._pkocs1003 = value; }
        }

        public NUROAccountForcedEndInfo() { }

        public NUROAccountForcedEndInfo(String sunabDate, String fkout1003, String pkocs1003)
        {
            this._sunabDate = sunabDate;
            this._fkout1003 = fkout1003;
            this._pkocs1003 = pkocs1003;
        }

    }
}