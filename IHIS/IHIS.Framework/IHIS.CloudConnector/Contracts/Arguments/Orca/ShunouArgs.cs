using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Orca
{[Serializable]
    public class ShunouArgs : IContractArgs
    {
    protected bool Equals(ShunouArgs other)
    {
        return string.Equals(_performDate, other._performDate) && string.Equals(_performMonth, other._performMonth) && string.Equals(_performYear, other._performYear) && string.Equals(_patientId, other._patientId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ShunouArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_performDate != null ? _performDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_performMonth != null ? _performMonth.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_performYear != null ? _performYear.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_patientId != null ? _patientId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private string _patientId;
        private string _performDate = "";
        private string _performMonth = "";
        private string _performYear = "";

        public ShunouArgs()
        {
            
        }
        public ShunouArgs(string patientId, string performDate, string performMonth, string performYear)
        {
            _patientId = patientId;
            _performDate = performDate;
            _performMonth = performMonth;
            _performYear = performYear;
        }

        public string PatientId
        {
            get { return _patientId; }
            set { _patientId = value; }
        }

        public string PerformDate
        {
            get { return _performDate; }
            set { _performDate = value; }
        }

        public string PerformMonth
        {
            get { return _performMonth; }
            set { _performMonth = value; }
        }

        public string PerformYear
        {
            get { return _performYear; }
            set { _performYear = value; }
        }

        public IExtensible GetRequestInstance()
        {
            return new ShunouRequest();
        }
    }
}