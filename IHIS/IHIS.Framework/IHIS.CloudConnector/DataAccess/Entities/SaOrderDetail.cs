using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.DataAccess.Entities
{
    public class SaOrderDetail
    {
        private Guid refdetailid;
        public Guid Refdetailid
        {
            get { return refdetailid; }
            set { refdetailid = value; }
        }

        private Guid refid;
        public Guid Refid
        {
            get { return refid; }
            set { refid = value; }
        }

        private Guid inventoryitemid;
        public Guid Inventoryitemid
        {
            get { return inventoryitemid; }
            set { inventoryitemid = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private Guid unitid;
        public Guid Unitid
        {
            get { return unitid; }
            set { unitid = value; }
        }

        private decimal quantity;
        public decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private decimal quantitydeliveredsa;
        public decimal Quantitydeliveredsa
        {
            get { return quantitydeliveredsa; }
            set { quantitydeliveredsa = value; }
        }

        private decimal quantitydeliveredin;
        public decimal Quantitydeliveredin
        {
            get { return quantitydeliveredin; }
            set { quantitydeliveredin = value; }
        }

        private decimal unitprice;
        public decimal Unitprice
        {
            get { return unitprice; }
            set { unitprice = value; }
        }

        private decimal unitpriceaftertax;
        public decimal Unitpriceaftertax
        {
            get { return unitpriceaftertax; }
            set { unitpriceaftertax = value; }
        }

        private decimal amountoc;
        public decimal Amountoc
        {
            get { return amountoc; }
            set { amountoc = value; }
        }

        private decimal amount;
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private decimal discountrate;
        public decimal Discountrate
        {
            get { return discountrate; }
            set { discountrate = value; }
        }

        private decimal discountamountoc;
        public decimal Discountamountoc
        {
            get { return discountamountoc; }
            set { discountamountoc = value; }
        }

        private decimal discountamount;
        public decimal Discountamount
        {
            get { return discountamount; }
            set { discountamount = value; }
        }

        private decimal vatrate;
        public decimal Vatrate
        {
            get { return vatrate; }
            set { vatrate = value; }
        }

        private decimal vatamountoc;
        public decimal Vatamountoc
        {
            get { return vatamountoc; }
            set { vatamountoc = value; }
        }

        private decimal vatamount;
        public decimal Vatamount
        {
            get { return vatamount; }
            set { vatamount = value; }
        }

        private decimal mainquantity;
        public decimal Mainquantity
        {
            get { return mainquantity; }
            set { mainquantity = value; }
        }

        private Guid mainunitid;
        public Guid Mainunitid
        {
            get { return mainunitid; }
            set { mainunitid = value; }
        }

        private decimal mainunitprice;
        public decimal Mainunitprice
        {
            get { return mainunitprice; }
            set { mainunitprice = value; }
        }

        private decimal mainconvertrate;
        public decimal Mainconvertrate
        {
            get { return mainconvertrate; }
            set { mainconvertrate = value; }
        }

        private string exchangerateoperator;
        public string Exchangerateoperator
        {
            get { return exchangerateoperator; }
            set { exchangerateoperator = value; }
        }

        private int sortorder;
        public int Sortorder
        {
            get { return sortorder; }
            set { sortorder = value; }
        }

        private string customfield1;
        public string Customfield1
        {
            get { return customfield1; }
            set { customfield1 = value; }
        }

        private string customfield2;
        public string Customfield2
        {
            get { return customfield2; }
            set { customfield2 = value; }
        }

        private string customfield3;
        public string Customfield3
        {
            get { return customfield3; }
            set { customfield3 = value; }
        }

        private string customfield4;
        public string Customfield4
        {
            get { return customfield4; }
            set { customfield4 = value; }
        }

        private string customfield5;
        public string Customfield5
        {
            get { return customfield5; }
            set { customfield5 = value; }
        }

        private string customfield6;
        public string Customfield6
        {
            get { return customfield6; }
            set { customfield6 = value; }
        }

        private string customfield7;
        public string Customfield7
        {
            get { return customfield7; }
            set { customfield7 = value; }
        }

        private string customfield8;
        public string Customfield8
        {
            get { return customfield8; }
            set { customfield8 = value; }
        }

        private string customfield9;
        public string Customfield9
        {
            get { return customfield9; }
            set { customfield9 = value; }
        }

        private string customfield10;
        public string Customfield10
        {
            get { return customfield10; }
            set { customfield10 = value; }
        }

        private Guid saquoterefdetailid;
        public Guid Saquoterefdetailid
        {
            get { return saquoterefdetailid; }
            set { saquoterefdetailid = value; }
        }

        private Guid contractid;
        public Guid Contractid
        {
            get { return contractid; }
            set { contractid = value; }
        }

        private Guid projectworkid;
        public Guid Projectworkid
        {
            get { return projectworkid; }
            set { projectworkid = value; }
        }

        private Guid expenseitemid;
        public Guid Expenseitemid
        {
            get { return expenseitemid; }
            set { expenseitemid = value; }
        }

        private Guid organizationunitid;
        public Guid Organizationunitid
        {
            get { return organizationunitid; }
            set { organizationunitid = value; }
        }

        private Guid jobid;
        public Guid Jobid
        {
            get { return jobid; }
            set { jobid = value; }
        }

        private Guid listitemid;
        public Guid Listitemid
        {
            get { return listitemid; }
            set { listitemid = value; }
        }

        private Guid stockid;
        public Guid Stockid
        {
            get { return stockid; }
            set { stockid = value; }
        }

        private string lotno;
        public string Lotno
        {
            get { return lotno; }
            set { lotno = value; }
        }

        private DateTime expirydate;
        public DateTime Expirydate
        {
            get { return expirydate; }
            set { expirydate = value; }
        }

    }

}
