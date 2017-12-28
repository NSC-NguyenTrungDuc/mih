using System;
using IHIS.CloudConnector.Contracts.Models;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class LogonArgs : IContractArgs
    {
    protected bool Equals(LogonArgs other)
    {
        return string.Equals(_ticket, other._ticket) && string.Equals(_customerId, other._customerId) && string.Equals(_target, other._target) && string.Equals(_serviceType, other._serviceType);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((LogonArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_ticket != null ? _ticket.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_customerId != null ? _customerId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_target != null ? _target.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_serviceType != null ? _serviceType.GetHashCode() : 0);
            return hashCode;
        }
    }

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

        public string ServiceType
        {
            get { return _serviceType; }
            set { _serviceType = value; }
        }

        public LogonArgs(String ticket, String customerId, String target, String serviceType)
        {
            Ticket = ticket;
            CustomerId = customerId;
            Target = target;
            ServiceType = serviceType;
        }

        public LogonArgs()
        {
        }

        public IExtensible GetRequestInstance()
        {
            return new LogonRequest();
        }
    }
}