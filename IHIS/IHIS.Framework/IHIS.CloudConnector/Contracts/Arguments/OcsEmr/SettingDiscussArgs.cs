using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class SettingDiscussArgs : IContractArgs
    {
        protected bool Equals(SettingDiscussArgs other)
        {
            return string.Equals(_gwa, other._gwa);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SettingDiscussArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_gwa != null ? _gwa.GetHashCode() : 0);
        }

        private String _gwa;

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public SettingDiscussArgs() { }

        public SettingDiscussArgs(String gwa)
        {
            this._gwa = gwa;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SettingDiscussRequest();
        }
    }
}