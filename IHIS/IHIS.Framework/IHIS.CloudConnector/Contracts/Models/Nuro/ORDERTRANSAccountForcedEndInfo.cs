using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANSAccountForcedEndInfo
    {
        private String _pkocs1003;

        public String Pkocs1003
        {
            get { return this._pkocs1003; }
            set { this._pkocs1003 = value; }
        }

        public ORDERTRANSAccountForcedEndInfo() { }

        public ORDERTRANSAccountForcedEndInfo(String pkocs1003)
        {
            this._pkocs1003 = pkocs1003;
        }

    }
}