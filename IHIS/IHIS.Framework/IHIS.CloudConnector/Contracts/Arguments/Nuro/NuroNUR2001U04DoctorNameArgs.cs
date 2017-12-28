using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroNUR2001U04DoctorNameArgs : IContractArgs
    {
        protected bool Equals(NuroNUR2001U04DoctorNameArgs other)
        {
            return string.Equals(_doctorCode, other._doctorCode) && string.Equals(_date, other._date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroNUR2001U04DoctorNameArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_doctorCode != null ? _doctorCode.GetHashCode() : 0)*397) ^ (_date != null ? _date.GetHashCode() : 0);
            }
        }

        private string _doctorCode;
        private string _date;

        public string DoctorCode
        {
            get { return _doctorCode; }
            set { _doctorCode = value; }
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public NuroNUR2001U04DoctorNameArgs(string doctorCode, string date)
        {
            _doctorCode = doctorCode;
            _date = date;
        }

        public NuroNUR2001U04DoctorNameArgs()
        {
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroNUR2001U04DoctorNameRequest();
        }
    }
}
