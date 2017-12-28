using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
    public class OCS2015U31EmrTagGetTagArgs : IContractArgs
    {
    protected bool Equals(OCS2015U31EmrTagGetTagArgs other)
    {
        return string.Equals(_tagLevel, other._tagLevel);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U31EmrTagGetTagArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_tagLevel != null ? _tagLevel.GetHashCode() : 0);
    }

    private String _tagLevel;

        public String TagLevel
        {
            get { return this._tagLevel; }
            set { this._tagLevel = value; }
        }

        public OCS2015U31EmrTagGetTagArgs() { }

        public OCS2015U31EmrTagGetTagArgs(String tagLevel)
        {
            this._tagLevel = tagLevel;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U31EmrTagGetTagRequest();
        }
    }
}