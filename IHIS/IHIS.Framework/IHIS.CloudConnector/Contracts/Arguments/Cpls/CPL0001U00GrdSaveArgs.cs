using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL0001U00GrdSaveArgs : IContractArgs
    {
        protected bool Equals(CPL0001U00GrdSaveArgs other)
        {
            return string.Equals(_qUserId, other._qUserId) && string.Equals(_fHospCode, other._fHospCode) && Equals(_dt, other._dt);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0001U00GrdSaveArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_qUserId != null ? _qUserId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fHospCode != null ? _fHospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_dt != null ? _dt.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _qUserId;
        private String _fHospCode;
        private List<CPL0001U00GrdSlipInfo> _dt = new List<CPL0001U00GrdSlipInfo>();

        public String QUserId
        {
            get { return this._qUserId; }
            set { this._qUserId = value; }
        }

        public String FHospCode
        {
            get { return this._fHospCode; }
            set { this._fHospCode = value; }
        }

        public List<CPL0001U00GrdSlipInfo> Dt
        {
            get { return this._dt; }
            set { this._dt = value; }
        }

        public CPL0001U00GrdSaveArgs() { }

        public CPL0001U00GrdSaveArgs(String qUserId, String fHospCode, List<CPL0001U00GrdSlipInfo> dt)
        {
            this._qUserId = qUserId;
            this._fHospCode = fHospCode;
            this._dt = dt;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL0001U00GrdSaveRequest();
        }
    }
}