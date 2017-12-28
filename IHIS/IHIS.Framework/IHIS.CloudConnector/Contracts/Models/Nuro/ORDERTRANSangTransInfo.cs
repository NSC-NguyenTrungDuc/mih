using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANSangTransInfo
    {
        private String _pkifs1011;

        public String Pkifs1011
        {
            get { return this._pkifs1011; }
            set { this._pkifs1011 = value; }
        }

        public ORDERTRANSangTransInfo() { }

        public ORDERTRANSangTransInfo(String pkifs1011)
        {
            this._pkifs1011 = pkifs1011;
        }

    }
}