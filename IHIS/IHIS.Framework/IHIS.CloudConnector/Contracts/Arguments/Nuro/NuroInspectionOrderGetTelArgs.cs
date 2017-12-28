using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroInspectionOrderGetTelArgs : IContractArgs
    {
        protected bool Equals(NuroInspectionOrderGetTelArgs other)
        {
            return string.Equals(_reserDate, other._reserDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroInspectionOrderGetTelArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_reserDate != null ? _reserDate.GetHashCode() : 0);
        }

        private String _reserDate;

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public NuroInspectionOrderGetTelArgs() { }

        public NuroInspectionOrderGetTelArgs(String reserDate)
        {
            this._reserDate = reserDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroInspectionOrderGetTelRequest();
        }
    }
}