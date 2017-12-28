using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL2010U00LayChkNameListItemInfo
    {
        private String _suname;
        private String _orderDate1;
        private String _orderDate2;
        private String _codeName;

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String OrderDate1
        {
            get { return this._orderDate1; }
            set { this._orderDate1 = value; }
        }

        public String OrderDate2
        {
            get { return this._orderDate2; }
            set { this._orderDate2 = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public CPL2010U00LayChkNameListItemInfo() { }

        public CPL2010U00LayChkNameListItemInfo(String suname, String orderDate1, String orderDate2, String codeName)
        {
            this._suname = suname;
            this._orderDate1 = orderDate1;
            this._orderDate2 = orderDate2;
            this._codeName = codeName;
        }

    }
}