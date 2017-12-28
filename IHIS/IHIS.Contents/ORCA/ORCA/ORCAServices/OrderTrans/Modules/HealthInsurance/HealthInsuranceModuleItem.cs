using System;
using System.Collections.Generic;
using System.Text;

namespace ORCA
{
    public class HealthInsuranceModuleItem
    {
        private string _countryType = "";
        private string _insuranceCode = "";
        private string _insuranceNumber = "";
        private DateTime _startDate;
        private DateTime _endDate;
        private int _paymentInRatio;
        private PublicHeathInsuranceItemInfo _publicHealthInsuranceItem;

        public string CountryType
        {
            get { return _countryType; }
            set { _countryType = value; }
        }

        public string InsuranceCode
        {
            get { return _insuranceCode; }
            set { _insuranceCode = value; }
        }

        public string InsuranceNumber
        {
            get { return _insuranceNumber; }
            set { _insuranceNumber = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public int PaymentRatio
        {
            get { return _paymentInRatio; }
            set { _paymentInRatio = value; }
        }

        public PublicHeathInsuranceItemInfo PublicHeathInsuranceItem
        {
            get { return _publicHealthInsuranceItem; }
            set { _publicHealthInsuranceItem = value; }
        }

        public HealthInsuranceModuleItem()
        { }
    }
}
