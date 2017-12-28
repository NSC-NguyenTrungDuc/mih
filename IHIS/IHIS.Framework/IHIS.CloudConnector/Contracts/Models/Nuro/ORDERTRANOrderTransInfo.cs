using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANOrderTransInfo
    {
        private String _pkifs1004;

        public String Pkifs1004
        {
            get { return this._pkifs1004; }
            set { this._pkifs1004 = value; }
        }

        public ORDERTRANOrderTransInfo() { }

        public ORDERTRANOrderTransInfo(String pkifs1004)
        {
            this._pkifs1004 = pkifs1004;
        }

    }
}