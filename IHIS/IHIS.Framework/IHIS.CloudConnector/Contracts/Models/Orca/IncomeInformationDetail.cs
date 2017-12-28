using System;

namespace IHIS.CloudConnector.Contracts.Models.Orca
{
    [Serializable]
    public class IncomeInformationDetail
    {
        private string _requestedAmount;
        private string _paidAmount;
        private string _responseDate;
        private string _status;
        private string _paymentMethod;

        public IncomeInformationDetail()
        {
        }

        public IncomeInformationDetail(string requestedAmount, string paidAmount, string responseDate, string status, string paymentMethod)
        {
            _requestedAmount = requestedAmount;
            _paidAmount = paidAmount;
            _responseDate = responseDate;
            _status = status;
            _paymentMethod = paymentMethod;
        }

        public string RequestedAmount
        {
            get { return _requestedAmount; }
            set { _requestedAmount = value; }
        }

        public string PaidAmount
        {
            get { return _paidAmount; }
            set { _paidAmount = value; }
        }

        public string ResponseDate
        {
            get { return _responseDate; }
            set { _responseDate = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string PaymentMethod
        {
            get { return _paymentMethod; }
            set { _paymentMethod = value; }
        }
    }
}