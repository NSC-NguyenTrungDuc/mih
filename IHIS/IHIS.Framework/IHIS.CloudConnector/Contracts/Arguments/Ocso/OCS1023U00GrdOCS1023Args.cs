using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCS1023U00GrdOCS1023Args : IContractArgs
    {
    protected bool Equals(OCS1023U00GrdOCS1023Args other)
    {
        return string.Equals(_genericYn, other._genericYn) && string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_inputTab, other._inputTab);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS1023U00GrdOCS1023Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_genericYn != null ? _genericYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _genericYn;
        private String _bunho;
        private String _gwa;
        private String _inputTab;

        public String GenericYn
        {
            get { return this._genericYn; }
            set { this._genericYn = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String InputTab
        {
            get { return this._inputTab; }
            set { this._inputTab = value; }
        }

        public OCS1023U00GrdOCS1023Args() { }

        public OCS1023U00GrdOCS1023Args(String genericYn, String bunho, String gwa, String inputTab)
        {
            this._genericYn = genericYn;
            this._bunho = bunho;
            this._gwa = gwa;
            this._inputTab = inputTab;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS1023U00GrdOCS1023Request();
        }
    }
}