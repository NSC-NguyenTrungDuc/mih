using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.ORCA
{
    public class PublicHeathInsuranceItemInfo
    {
        private int _priorityNumber;
        private string _providerName = "";
        private string _providerNumber = "";
        private DateTime _startDate;
        private DateTime _endDate;

        public int PriorityNumber
        {
            get { return _priorityNumber; }
            set { _priorityNumber = value; }
        }

        public string ProviderName
        {
            get { return _providerName; }
            set { _providerName = value; }
        }

        public string ProviderNumber
        {
            get { return _providerNumber; }
            set { _providerNumber = value; }
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

        public PublicHeathInsuranceItemInfo()
        { }
    }
}
