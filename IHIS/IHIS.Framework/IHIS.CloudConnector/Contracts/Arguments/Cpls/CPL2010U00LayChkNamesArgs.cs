using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL2010U00LayChkNamesArgs : IContractArgs
    {
        protected bool Equals(CPL2010U00LayChkNamesArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_reserDate, other._reserDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL2010U00LayChkNamesArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
            }
        }

        private String _bunho;
        private String _reserDate;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public CPL2010U00LayChkNamesArgs() { }

        public CPL2010U00LayChkNamesArgs(String bunho, String reserDate)
        {
            this._bunho = bunho;
            this._reserDate = reserDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010U00LayChkNamesRequest();
        }
    }
}