using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroInspectionOrderGetMaxCodeNameArgs : IContractArgs
    {
        protected bool Equals(NuroInspectionOrderGetMaxCodeNameArgs other)
        {
            return string.Equals(_codeType, other._codeType) && string.Equals(_reserPart, other._reserPart);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroInspectionOrderGetMaxCodeNameArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_codeType != null ? _codeType.GetHashCode() : 0)*397) ^ (_reserPart != null ? _reserPart.GetHashCode() : 0);
            }
        }

        private String _codeType;
        private String _reserPart;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String ReserPart
        {
            get { return this._reserPart; }
            set { this._reserPart = value; }
        }

        public NuroInspectionOrderGetMaxCodeNameArgs() { }

        public NuroInspectionOrderGetMaxCodeNameArgs(String codeType, String reserPart)
        {
            this._codeType = codeType;
            this._reserPart = reserPart;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroInspectionOrderGetMaxCodeNameRequest();
        }
    }
}