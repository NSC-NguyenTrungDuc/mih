using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT1002U00LayOrderDateInfo
    {
        private String _orderDate;

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public XRT1002U00LayOrderDateInfo() { }

        public XRT1002U00LayOrderDateInfo(String orderDate)
        {
            this._orderDate = orderDate;
        }

    }
}