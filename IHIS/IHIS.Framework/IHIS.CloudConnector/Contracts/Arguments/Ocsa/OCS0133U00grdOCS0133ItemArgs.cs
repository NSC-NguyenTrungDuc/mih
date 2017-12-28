using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0133U00grdOCS0133ItemArgs : IContractArgs
    {
    protected bool Equals(OCS0133U00grdOCS0133ItemArgs other)
    {
        return string.Equals(_inputControl, other._inputControl) && string.Equals(_userInfo, other._userInfo);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0133U00grdOCS0133ItemArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_inputControl != null ? _inputControl.GetHashCode() : 0)*397) ^ (_userInfo != null ? _userInfo.GetHashCode() : 0);
        }
    }

    private String _inputControl;
        private String _userInfo;

        public String InputControl
        {
            get { return this._inputControl; }
            set { this._inputControl = value; }
        }

        public String UserInfo
        {
            get { return this._userInfo; }
            set { this._userInfo = value; }
        }

        public OCS0133U00grdOCS0133ItemArgs() { }

        public OCS0133U00grdOCS0133ItemArgs(String inputControl, String userInfo)
        {
            this._inputControl = inputControl;
            this._userInfo = userInfo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0133U00grdOCS0133ItemRequest();
        }
    }
}