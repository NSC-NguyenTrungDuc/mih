using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class BIL0102U00DataReportInfo
    {
        private String _department;
        private List<LoadGridBIL2016U02Info> _invoiceDetail = new List<LoadGridBIL2016U02Info>();

        public String Department
        {
            get { return this._department; }
            set { this._department = value; }
        }

        public List<LoadGridBIL2016U02Info> InvoiceDetail
        {
            get { return this._invoiceDetail; }
            set { this._invoiceDetail = value; }
        }

        public BIL0102U00DataReportInfo() { }

        public BIL0102U00DataReportInfo(String department, List<LoadGridBIL2016U02Info> invoiceDetail)
        {
            this._department = department;
            this._invoiceDetail = invoiceDetail;
        }

    }
}