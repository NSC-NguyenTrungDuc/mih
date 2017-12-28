using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    [Serializable]
    public class OCS2015U40EmrMedicalRecordContentArgs : IContractArgs
    {
        protected bool Equals(OCS2015U40EmrMedicalRecordContentArgs other)
        {
            return string.Equals(_recordId, other._recordId) && string.Equals(_version, other._version);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OCS2015U40EmrMedicalRecordContentArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_recordId != null ? _recordId.GetHashCode() : 0)*397) ^ (_version != null ? _version.GetHashCode() : 0);
            }
        }

        private String _recordId;
        private String _version;

        public String RecordId
        {
            get { return this._recordId; }
            set { this._recordId = value; }
        }

        public String Version
        {
            get { return this._version; }
            set { this._version = value; }
        }

        public OCS2015U40EmrMedicalRecordContentArgs() { }

        public OCS2015U40EmrMedicalRecordContentArgs(String recordId, String version)
        {
            this._recordId = recordId;
            this._version = version;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U40EmrMedicalRecordContentRequest();
        }
    }
}