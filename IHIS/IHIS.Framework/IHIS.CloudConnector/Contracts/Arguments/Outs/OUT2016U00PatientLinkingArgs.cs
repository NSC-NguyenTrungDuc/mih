using System;
using IHIS.CloudConnector.Contracts.Models.Outs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Outs
{[Serializable]
    public class OUT2016U00PatientLinkingArgs : IContractArgs
    {
    protected bool Equals(OUT2016U00PatientLinkingArgs other)
    {
        return string.Equals(_linkType, other._linkType) && string.Equals(_hospCode, other._hospCode) && string.Equals(_bunho, other._bunho) && string.Equals(_hospCodeLink, other._hospCodeLink) && string.Equals(_bunhoLink, other._bunhoLink) && string.Equals(_password, other._password);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OUT2016U00PatientLinkingArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_linkType != null ? _linkType.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunhoLink != null ? _bunhoLink.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_password != null ? _password.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _linkType;
        private String _hospCode;
        private String _bunho;
        private String _hospCodeLink;
        private String _bunhoLink;
        private String _password;

        public String LinkType
        {
            get { return this._linkType; }
            set { this._linkType = value; }
        }

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

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public String BunhoLink
        {
            get { return this._bunhoLink; }
            set { this._bunhoLink = value; }
        }

        public String Password
        {
            get { return this._password; }
            set { this._password = value; }
        }

        public OUT2016U00PatientLinkingArgs() { }

        public OUT2016U00PatientLinkingArgs(String linkType, String hospCode, String bunho, String hospCodeLink, String bunhoLink, String password)
        {
            this._linkType = linkType;
            this._hospCode = hospCode;
            this._bunho = bunho;
            this._hospCodeLink = hospCodeLink;
            this._bunhoLink = bunhoLink;
            this._password = password;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OUT2016U00PatientLinkingRequest();
        }
    }
}