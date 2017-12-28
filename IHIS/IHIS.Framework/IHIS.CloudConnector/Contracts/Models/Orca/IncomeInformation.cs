using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Models.Orca
{
    [Serializable]
    public class IncomeInformation
    {
        private string _invoiceNumber;
        private string _departmentName;
        private string _departmentCode;
        private string _orderDate;
        private string _dateOfExamination;
        private string _insuarance;
        private string _percentOfPayment;
        private string _requestedAmount;
        private string _paidAmount;
        private string _status;
        private List<IncomeInformationDetail> _incomeInformationDetail = new List<IncomeInformationDetail>();

        public IncomeInformation()
        {
        }

        public IncomeInformation(string invoiceNumber, string departmentName, string departmentCode, string orderDate, string dateOfExamination, string insuarance, string percentOfPayment, string requestedAmount, string paidAmount, string status)
        {
            _invoiceNumber = invoiceNumber;
            _departmentName = departmentName;
            _departmentCode = departmentCode;
            _orderDate = orderDate;
            _dateOfExamination = dateOfExamination;
            _insuarance = insuarance;
            _percentOfPayment = percentOfPayment;
            _requestedAmount = requestedAmount;
            _paidAmount = paidAmount;
            _status = status;
        }

        public List<IncomeInformationDetail> IncomeInformationDetail
        {
            get { return _incomeInformationDetail; }
            set { _incomeInformationDetail = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string PaidAmount
        {
            get { return _paidAmount; }
            set { _paidAmount = value; }
        }

        public string RequestedAmount
        {
            get { return _requestedAmount; }
            set { _requestedAmount = value; }
        }

        public string PercentOfPayment
        {
            get { return _percentOfPayment; }
            set { _percentOfPayment = value; }
        }

        public string Insuarance
        {
            get { return _insuarance; }
            set { _insuarance = value; }
        }

        public string DateOfExamination
        {
            get { return _dateOfExamination; }
            set { _dateOfExamination = value; }
        }

        public string OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }

        public string DepartmentCode
        {
            get { return _departmentCode; }
            set { _departmentCode = value; }
        }

        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }

        public string InvoiceNumber
        {
            get { return _invoiceNumber; }
            set { _invoiceNumber = value; }
        }
    }
}