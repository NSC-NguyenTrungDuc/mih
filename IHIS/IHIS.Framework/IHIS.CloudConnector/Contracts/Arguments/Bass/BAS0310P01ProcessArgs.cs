using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0310P01ProcessArgs : IContractArgs
    {
        protected bool Equals(BAS0310P01ProcessArgs other)
        {
            return string.Equals(_updateProcName, other._updateProcName) && string.Equals(_procGubun, other._procGubun) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0310P01ProcessArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_updateProcName != null ? _updateProcName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_procGubun != null ? _procGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _updateProcName;
        private String _procGubun;
        private String _userId;

        public String UpdateProcName
        {
            get { return this._updateProcName; }
            set { this._updateProcName = value; }
        }

        public String ProcGubun
        {
            get { return this._procGubun; }
            set { this._procGubun = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public BAS0310P01ProcessArgs() { }

        public BAS0310P01ProcessArgs(String updateProcName, String procGubun, String userId)
        {
            this._updateProcName = updateProcName;
            this._procGubun = procGubun;
            this._userId = userId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0310P01ProcessRequest();
        }
    }
}