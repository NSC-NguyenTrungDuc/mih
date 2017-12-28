using System;
using IHIS.CloudConnector.Contracts.Models.Outs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Outs
{[Serializable]
    public class OUT2016U00UpdatePatientLinkingArgs : IContractArgs
    {
    protected bool Equals(OUT2016U00UpdatePatientLinkingArgs other)
    {
        return string.Equals(_hospCode, other._hospCode) && string.Equals(_bunho, other._bunho) && Equals(_phrPatientLinkingContent, other._phrPatientLinkingContent);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OUT2016U00UpdatePatientLinkingArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_phrPatientLinkingContent != null ? _phrPatientLinkingContent.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _hospCode;
        private String _bunho;
        private List<OUT2016U00PatientLinkingContentInfo> _phrPatientLinkingContent = new List<OUT2016U00PatientLinkingContentInfo>();

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public List<OUT2016U00PatientLinkingContentInfo> PhrPatientLinkingContent
        {
            get { return this._phrPatientLinkingContent; }
            set { this._phrPatientLinkingContent = value; }
        }

        public OUT2016U00UpdatePatientLinkingArgs() { }

        public OUT2016U00UpdatePatientLinkingArgs(String hospCode, String bunho, List<OUT2016U00PatientLinkingContentInfo> phrPatientLinkingContent)
        {
            this._hospCode = hospCode;
            this._bunho = bunho;
            this._phrPatientLinkingContent = phrPatientLinkingContent;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OUT2016U00UpdatePatientLinkingRequest();
        }
    }
}