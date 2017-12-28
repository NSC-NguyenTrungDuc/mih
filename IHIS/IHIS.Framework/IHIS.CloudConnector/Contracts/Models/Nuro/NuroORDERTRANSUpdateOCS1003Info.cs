using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroORDERTRANSUpdateOCS1003Info
    {
        private String _sunabDate;
        private String _pkocs1003;

        public String SunabDate
        {
            get { return this._sunabDate; }
            set { this._sunabDate = value; }
        }

        public String Pkocs1003
        {
            get { return this._pkocs1003; }
            set { this._pkocs1003 = value; }
        }

        public NuroORDERTRANSUpdateOCS1003Info() { }

        public NuroORDERTRANSUpdateOCS1003Info(String sunabDate, String pkocs1003)
        {
            this._sunabDate = sunabDate;
            this._pkocs1003 = pkocs1003;
        }

    }
}