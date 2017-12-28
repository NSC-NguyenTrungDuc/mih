using System;

namespace IHIS.CloudConnector.Contracts.Models.Phys
{
    [Serializable]
    public class PHY2001U04RefreshCounterInfo
    {
        private String _g1;
        private String _g2;
        private String _sa;
        private String _re;

        public String G1
        {
            get { return this._g1; }
            set { this._g1 = value; }
        }

        public String G2
        {
            get { return this._g2; }
            set { this._g2 = value; }
        }

        public String Sa
        {
            get { return this._sa; }
            set { this._sa = value; }
        }

        public String Re
        {
            get { return this._re; }
            set { this._re = value; }
        }

        public PHY2001U04RefreshCounterInfo() { }

        public PHY2001U04RefreshCounterInfo(String g1, String g2, String sa, String re)
        {
            this._g1 = g1;
            this._g2 = g2;
            this._sa = sa;
            this._re = re;
        }

    }
}