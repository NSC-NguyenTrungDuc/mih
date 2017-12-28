using System;

namespace IHIS.CloudConnector.Contracts.Models.Endo
{
    [Serializable]
    public class END1001U02GrdPurposeInfo
    {
        private String _n;
        private String _codeName;

        public String N
        {
            get { return this._n; }
            set { this._n = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public END1001U02GrdPurposeInfo() { }

        public END1001U02GrdPurposeInfo(String n, String codeName)
        {
            this._n = n;
            this._codeName = codeName;
        }

    }
}