using System;

namespace IHIS.CloudConnector.Contracts.Models.Endo
{
    [Serializable]
    public class END1001U02LayOrderDateInfo
    {
        private String _orderDate;

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public END1001U02LayOrderDateInfo() { }

        public END1001U02LayOrderDateInfo(String orderDate)
        {
            this._orderDate = orderDate;
        }

    }
}