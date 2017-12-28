using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using System;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public partial class JapanDateInfoArgs : IContractArgs
    {
        protected bool Equals(JapanDateInfoArgs other)
        {
            return string.Equals(_naewonDate, other._naewonDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((JapanDateInfoArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
        }

        public JapanDateInfoArgs() { }
    
        private string _naewonDate;

        public JapanDateInfoArgs(string naewonDate)
        {
            _naewonDate = naewonDate;
        }

        public string NaewonDate
        {
            get { return _naewonDate; }
            set { _naewonDate = value; }
        }

        public IExtensible GetRequestInstance()
        {
            return new JapanDateInfoRequest();
        }
    }
}