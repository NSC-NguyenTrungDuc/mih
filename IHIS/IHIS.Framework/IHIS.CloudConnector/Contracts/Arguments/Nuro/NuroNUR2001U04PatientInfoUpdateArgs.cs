using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroNUR2001U04PatientInfoUpdateArgs : IContractArgs
    {
        protected bool Equals(NuroNUR2001U04PatientInfoUpdateArgs other)
        {
            return string.Equals(_updId, other._updId) && string.Equals(_comingStatus, other._comingStatus) && string.Equals(_arriveTime, other._arriveTime) && string.Equals(_receptionType, other._receptionType) && string.Equals(_pkout1001, other._pkout1001);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroNUR2001U04PatientInfoUpdateArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_updId != null ? _updId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_comingStatus != null ? _comingStatus.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_arriveTime != null ? _arriveTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_receptionType != null ? _receptionType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
                return hashCode;
            }
        }

        private string _updId;
        private string _comingStatus;
        private string _arriveTime;
        private string _receptionType;
        private string _pkout1001;

        public string UpdId
        {
            get { return _updId; }
            set { _updId = value; }
        }

        public string ComingStatus
        {
            get { return _comingStatus; }
            set { _comingStatus = value; }
        }

        public string ArriveTime
        {
            get { return _arriveTime; }
            set { _arriveTime = value; }
        }

        public string ReceptionType
        {
            get { return _receptionType; }
            set { _receptionType = value; }
        }

        public string Pkout1001
        {
            get { return _pkout1001; }
            set { _pkout1001 = value; }
        }

        public NuroNUR2001U04PatientInfoUpdateArgs(string updId, string comingStatus, string arriveTime, string receptionType, string pkout1001)
        {
            _updId = updId;
            _comingStatus = comingStatus;
            _arriveTime = arriveTime;
            _receptionType = receptionType;
            _pkout1001 = pkout1001;
        }

        public NuroNUR2001U04PatientInfoUpdateArgs()
        {
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroNUR2001U04PatientInfoUpdateRequest();
        }
    }
}
