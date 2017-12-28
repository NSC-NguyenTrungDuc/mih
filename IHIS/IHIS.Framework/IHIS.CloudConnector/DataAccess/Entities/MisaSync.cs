using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.DataAccess.Entities
{
    public class MisaSync
    {
    }

    public class PatientMisa
    {
        private string accountObjectCode;
        public string AccountObjectCode
        {
            get { return accountObjectCode; }
            set { accountObjectCode = value; }
        }
        private string accountObjectName;
        public string AccountObjectName
        {
            get { return accountObjectName; }
            set { accountObjectName = value; }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string tel;
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        private string mobile;
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        private string fax;
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        private string emailAddress;
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }
    }

    public class BookingMisa
    {
        private string accountObjectCode;
        public string AccountObjectCode
        {
            get { return accountObjectCode; }
            set { accountObjectCode = value; }
        }
        private string employeeCode;
        public string EmployeeCode
        {
            get { return employeeCode; }
            set { employeeCode = value; }
        }
        private string modififiedBy;
        public string ModififiedBy
        {
            get { return modififiedBy; }
            set { modififiedBy = value; }
        }
        private DateTime refDate;
        public DateTime RefDate
        {
            get { return refDate; }
            set { refDate = value; }
        }
        private DateTime createDate;
        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
        private string inventoryCode;
        public string InventoryCode
        {
            get { return inventoryCode; }
            set { inventoryCode = value; }
        }
        private string brandId;
        public string BrandID
        {
            get { return brandId; }
            set { brandId = value; }
        }
    }
}
