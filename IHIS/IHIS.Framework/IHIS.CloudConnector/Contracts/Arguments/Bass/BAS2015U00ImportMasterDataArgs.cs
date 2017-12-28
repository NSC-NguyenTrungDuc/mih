using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS2015U00ImportMasterDataArgs : IContractArgs
    {
        protected bool Equals(BAS2015U00ImportMasterDataArgs other)
        {
            return string.Equals(_importType, other._importType) && Equals(_bytesData, other._bytesData);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS2015U00ImportMasterDataArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_importType != null ? _importType.GetHashCode() : 0)*397) ^ (_bytesData != null ? _bytesData.GetHashCode() : 0);
            }
        }

        private String _importType;
        private List<Byte> _bytesData = new List<Byte>();

        public String ImportType
        {
            get { return this._importType; }
            set { this._importType = value; }
        }

        public List<Byte> BytesData
        {
            get { return this._bytesData; }
            set { this._bytesData = value; }
        }

        public BAS2015U00ImportMasterDataArgs() { }

        public BAS2015U00ImportMasterDataArgs(String importType, List<Byte> bytesData)
        {
            this._importType = importType;
            this._bytesData = bytesData;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS2015U00ImportMasterDataRequest();
        }
    }
}