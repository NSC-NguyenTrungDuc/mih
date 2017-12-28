using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
    public class OCS2015U31EmrTagGetTemplateTagsArgs : IContractArgs
    {
    protected bool Equals(OCS2015U31EmrTagGetTemplateTagsArgs other)
    {
        return string.Equals(_strTagCode, other._strTagCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U31EmrTagGetTemplateTagsArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_strTagCode != null ? _strTagCode.GetHashCode() : 0);
    }

    private String _strTagCode;

        public String StrTagCode
        {
            get { return this._strTagCode; }
            set { this._strTagCode = value; }
        }

        public OCS2015U31EmrTagGetTemplateTagsArgs() { }

        public OCS2015U31EmrTagGetTemplateTagsArgs(String strTagCode)
        {
            this._strTagCode = strTagCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U31EmrTagGetTemplateTagsRequest();
        }
    }
}