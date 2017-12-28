using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class Bas0260U00grdBuseoInitArgs : IContractArgs
    {
        protected bool Equals(Bas0260U00grdBuseoInitArgs other)
        {
            return string.Equals(_startDate, other._startDate) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Bas0260U00grdBuseoInitArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_startDate != null ? _startDate.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            }
        }

        private String _startDate;
        private String _hospCode;

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public Bas0260U00grdBuseoInitArgs() { }

        public Bas0260U00grdBuseoInitArgs(String startDate, String hospCode)
        {
            this._startDate = startDate;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Bas0260U00grdBuseoInitRequest();
        }
    }
}