using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL2010R01LaySpecimenListArgs : IContractArgs
    {
        protected bool Equals(CPL2010R01LaySpecimenListArgs other)
        {
            return string.Equals(_hoDong, other._hoDong) && string.Equals(_reserDate, other._reserDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL2010R01LaySpecimenListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_hoDong != null ? _hoDong.GetHashCode() : 0)*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
            }
        }

        private String _hoDong;
        private String _reserDate;

        public String HoDong
        {
            get { return this._hoDong; }
            set { this._hoDong = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public CPL2010R01LaySpecimenListArgs() { }

        public CPL2010R01LaySpecimenListArgs(String hoDong, String reserDate)
        {
            this._hoDong = hoDong;
            this._reserDate = reserDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010R01LaySpecimenListRequest();
        }
    }
}