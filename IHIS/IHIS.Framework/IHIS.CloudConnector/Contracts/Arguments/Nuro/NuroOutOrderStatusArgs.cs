using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOutOrderStatusArgs : IContractArgs
    {
        protected bool Equals(NuroOutOrderStatusArgs other)
        {
            return string.Equals(_commingDate, other._commingDate) && string.Equals(_deparmentCode, other._deparmentCode) && string.Equals(_patientCode, other._patientCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOutOrderStatusArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_commingDate != null ? _commingDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_deparmentCode != null ? _deparmentCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_patientCode != null ? _patientCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private string _commingDate;
        private string _deparmentCode;
        private string _patientCode;

        public NuroOutOrderStatusArgs()
        {
        }

        public NuroOutOrderStatusArgs(string commingDate, string deparmentCode, string patientCode)
        {
            _commingDate = commingDate;
            _deparmentCode = deparmentCode;
            _patientCode = patientCode;
        }

        public string CommingDate
        {
            get { return _commingDate; }
            set { _commingDate = value; }
        }

        public string DeparmentCode
        {
            get { return _deparmentCode; }
            set { _deparmentCode = value; }
        }

        public string PatientCode
        {
            get { return _patientCode; }
            set { _patientCode = value; }
        }

        public IExtensible GetRequestInstance()
        {
           return new NuroOutOrderStatusRequest();
        }
    }
}
