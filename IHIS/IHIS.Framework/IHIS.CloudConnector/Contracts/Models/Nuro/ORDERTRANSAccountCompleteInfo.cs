using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANSAccountCompleteInfo
    {
        private String _pkocs1003;

        public String Pkocs1003
        {
            get { return this._pkocs1003; }
            set { this._pkocs1003 = value; }
        }

        public ORDERTRANSAccountCompleteInfo() { }

        public ORDERTRANSAccountCompleteInfo(String pkocs1003)
        {
            this._pkocs1003 = pkocs1003;
        }

    }
}