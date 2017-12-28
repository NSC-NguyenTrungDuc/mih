using System;
using IHIS.CloudConnector.Contracts.Models;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class MainMenuArgs : IContractArgs
    {
    protected bool Equals(MainMenuArgs other)
    {
        return string.Equals(_msgUserYn, other._msgUserYn) && string.Equals(_adminUserYn, other._adminUserYn);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((MainMenuArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_msgUserYn != null ? _msgUserYn.GetHashCode() : 0)*397) ^ (_adminUserYn != null ? _adminUserYn.GetHashCode() : 0);
        }
    }

    private string _msgUserYn;
        private string _adminUserYn;

        public string MsgUserYn
        {
            get { return _msgUserYn; }
            set { _msgUserYn = value; }
        }

        public string AdminUserYn
        {
            get { return _adminUserYn; }
            set { _adminUserYn = value; }
        }

        public MainMenuArgs(String msgUserYn, String adminUserYn)
        {
            MsgUserYn = msgUserYn;
            AdminUserYn = adminUserYn;
        }

        public MainMenuArgs()
        {
        }

        public IExtensible GetRequestInstance()
        {
            return new MainMenuRequest();
        }
    }
}