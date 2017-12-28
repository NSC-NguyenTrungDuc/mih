using System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class LogonResult : AbstractContractResult
    {
        private string _ticket;
        private string _customerId;
        private string _target;
        private string _serviceType;

        public string Ticket
        {
            get { return _ticket; }           
            set { _ticket = value; }
        }

        public string CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        public string Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public String ServiceType
        {
            get { return _serviceType; }
            set { _serviceType = value; }
        }

        public LogonResult(String ticket, String customerId, String target, String serviceType)
        {
            Ticket = ticket;
            CustomerId = customerId;
            Target = target;
            ServiceType = serviceType;
        }

        public LogonResult()
        {
        } 
    }
}