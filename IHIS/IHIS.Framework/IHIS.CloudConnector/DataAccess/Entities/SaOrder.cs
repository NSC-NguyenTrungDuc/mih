using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.DataAccess.Entities
{

    public class SaOrder
    {
        private Guid refid;
        public Guid Refid
        {
            get { return refid; }
            set { refid = value; }
        }

        private DateTime refdate;
        public DateTime Refdate
        {
            get { return refdate; }
            set { refdate = value; }
        }

        private string refno;
        public string Refno
        {
            get { return refno; }
            set { refno = value; }
        }

        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private int reftype;
        public int Reftype
        {
            get { return reftype; }
            set { reftype = value; }
        }

        private Guid branchid;
        public Guid Branchid
        {
            get { return branchid; }
            set { branchid = value; }
        }

        private Guid accountobjectid;
        public Guid Accountobjectid
        {
            get { return accountobjectid; }
            set { accountobjectid = value; }
        }

        private string accountobjectname;
        public string Accountobjectname
        {
            get { return accountobjectname; }
            set { accountobjectname = value; }
        }

        private string accountobjectaddress;
        public string Accountobjectaddress
        {
            get { return accountobjectaddress; }
            set { accountobjectaddress = value; }
        }

        private string accountobjecttaxcode;
        public string Accountobjecttaxcode
        {
            get { return accountobjecttaxcode; }
            set { accountobjecttaxcode = value; }
        }

        private string receiver;
        public string Receiver
        {
            get { return receiver; }
            set { receiver = value; }
        }

        private Guid employeeid;
        public Guid Employeeid
        {
            get { return employeeid; }
            set { employeeid = value; }
        }

        private DateTime deliverydate;
        public DateTime Deliverydate
        {
            get { return deliverydate; }
            set { deliverydate = value; }
        }

        private bool iscalculatedcost;
        public bool Iscalculatedcost
        {
            get { return iscalculatedcost; }
            set { iscalculatedcost = value; }
        }

        private Guid? paymenttermid;
        public Guid? Paymenttermid
        {
            get { return paymenttermid; }
            set { paymenttermid = value; }
        }

        private int dueday;
        public int Dueday
        {
            get { return dueday; }
            set { dueday = value; }
        }

        private string journalmemo;
        public string Journalmemo
        {
            get { return journalmemo; }
            set { journalmemo = value; }
        }

        private string shippingaddress;
        public string Shippingaddress
        {
            get { return shippingaddress; }
            set { shippingaddress = value; }
        }

        private string otherterm;
        public string Otherterm
        {
            get { return otherterm; }
            set { otherterm = value; }
        }

        private Guid quoterefid;
        public Guid Quoterefid
        {
            get { return quoterefid; }
            set { quoterefid = value; }
        }

        private string currencyid;
        public string Currencyid
        {
            get { return currencyid; }
            set { currencyid = value; }
        }

        private decimal exchangerate;
        public decimal Exchangerate
        {
            get { return exchangerate; }
            set { exchangerate = value; }
        }

        private decimal totalamountoc;
        public decimal Totalamountoc
        {
            get { return totalamountoc; }
            set { totalamountoc = value; }
        }

        private decimal totalamount;
        public decimal Totalamount
        {
            get { return totalamount; }
            set { totalamount = value; }
        }

        private decimal totaldiscountamountoc;
        public decimal Totaldiscountamountoc
        {
            get { return totaldiscountamountoc; }
            set { totaldiscountamountoc = value; }
        }

        private decimal totaldiscountamount;
        public decimal Totaldiscountamount
        {
            get { return totaldiscountamount; }
            set { totaldiscountamount = value; }
        }

        private decimal totalvatamountoc;
        public decimal Totalvatamountoc
        {
            get { return totalvatamountoc; }
            set { totalvatamountoc = value; }
        }

        private decimal totalvatamount;
        public decimal Totalvatamount
        {
            get { return totalvatamount; }
            set { totalvatamount = value; }
        }

        private DateTime editversion;
        public DateTime Editversion
        {
            get { return editversion; }
            set { editversion = value; }
        }

        private string modifiedby;
        public string Modifiedby
        {
            get { return modifiedby; }
            set { modifiedby = value; }
        }

        private DateTime createddate;
        public DateTime Createddate
        {
            get { return createddate; }
            set { createddate = value; }
        }

        private string createdby;
        public string Createdby
        {
            get { return createdby; }
            set { createdby = value; }
        }

        private DateTime modifieddate;
        public DateTime Modifieddate
        {
            get { return modifieddate; }
            set { modifieddate = value; }
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

    }

}
