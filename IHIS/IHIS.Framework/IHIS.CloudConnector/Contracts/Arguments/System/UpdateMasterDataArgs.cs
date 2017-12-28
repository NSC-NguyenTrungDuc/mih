using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class UpdateMasterDataArgs : IContractArgs
    {
    protected bool Equals(UpdateMasterDataArgs other)
    {
        return string.Equals(_screenName, other._screenName);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((UpdateMasterDataArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_screenName != null ? _screenName.GetHashCode() : 0);
    }

    private String _screenName;

        public String ScreenName
        {
            get { return this._screenName; }
            set { this._screenName = value; }
        }

        public UpdateMasterDataArgs() { }

        public UpdateMasterDataArgs(String screenName)
        {
            this._screenName = screenName;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.UpdateMasterDataRequest();
        }
    }
}