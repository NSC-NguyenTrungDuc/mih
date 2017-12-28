using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{ [Serializable]
    public class PHY2001U04LayDoctorNameArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04LayDoctorNameArgs other)
    {
        return string.Equals(_doctor, other._doctor) && string.Equals(_date, other._date);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04LayDoctorNameArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_doctor != null ? _doctor.GetHashCode() : 0)*397) ^ (_date != null ? _date.GetHashCode() : 0);
        }
    }

    private String _doctor;
        private String _date;

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String Date
        {
            get { return this._date; }
            set { this._date = value; }
        }

        public PHY2001U04LayDoctorNameArgs() { }

        public PHY2001U04LayDoctorNameArgs(String doctor, String date)
        {
            this._doctor = doctor;
            this._date = date;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04LayDoctorNameRequest();
        }
    }
}