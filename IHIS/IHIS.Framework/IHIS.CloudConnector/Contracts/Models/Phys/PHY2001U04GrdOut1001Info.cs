using System;

namespace IHIS.CloudConnector.Contracts.Models.Phys
{
    [Serializable]
    public class PHY2001U04GrdOut1001Info
    {
        private String _bunho;
        private String _naewonDate;
        private String _jubsuGubun;
        private String _next;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String JubsuGubun
        {
            get { return this._jubsuGubun; }
            set { this._jubsuGubun = value; }
        }

        public String Next
        {
            get { return this._next; }
            set { this._next = value; }
        }

        public PHY2001U04GrdOut1001Info() { }

        public PHY2001U04GrdOut1001Info(String bunho, String naewonDate, String jubsuGubun, String next)
        {
            this._bunho = bunho;
            this._naewonDate = naewonDate;
            this._jubsuGubun = jubsuGubun;
            this._next = next;
        }

    }
}