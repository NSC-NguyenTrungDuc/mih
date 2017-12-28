using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class UpdateJubsuDataArgs : IContractArgs
    {
        protected bool Equals(UpdateJubsuDataArgs other)
        {
            return Equals(_dataInfo, other._dataInfo) && _isOrca.Equals(other._isOrca) && string.Equals(_orcaGigwanCode, other._orcaGigwanCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateJubsuDataArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_dataInfo != null ? _dataInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _isOrca.GetHashCode();
                hashCode = (hashCode*397) ^ (_orcaGigwanCode != null ? _orcaGigwanCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private List<UpdateJubsuDataInfo> _dataInfo = new List<UpdateJubsuDataInfo>();
        private Boolean _isOrca;
        private String _orcaGigwanCode;

        public List<UpdateJubsuDataInfo> DataInfo
        {
            get { return this._dataInfo; }
            set { this._dataInfo = value; }
        }

        public Boolean IsOrca
        {
            get { return this._isOrca; }
            set { this._isOrca = value; }
        }

        public String OrcaGigwanCode
        {
            get { return this._orcaGigwanCode; }
            set { this._orcaGigwanCode = value; }
        }

        public UpdateJubsuDataArgs() { }

        public UpdateJubsuDataArgs(List<UpdateJubsuDataInfo> dataInfo, Boolean isOrca, String orcaGigwanCode)
        {
            this._dataInfo = dataInfo;
            this._isOrca = isOrca;
            this._orcaGigwanCode = orcaGigwanCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.UpdateJubsuDataRequest();
        }
    }
}