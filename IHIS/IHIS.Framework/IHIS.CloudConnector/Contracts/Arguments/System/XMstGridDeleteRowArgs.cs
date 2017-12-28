using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class XMstGridDeleteRowArgs : IContractArgs
    {
    protected bool Equals(XMstGridDeleteRowArgs other)
    {
        return string.Equals(_tableName, other._tableName) && string.Equals(_whereCmd, other._whereCmd) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XMstGridDeleteRowArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_tableName != null ? _tableName.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_whereCmd != null ? _whereCmd.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _tableName;
        private String _whereCmd;
        private String _hospCode;

        public String TableName
        {
            get { return this._tableName; }
            set { this._tableName = value; }
        }

        public String WhereCmd
        {
            get { return this._whereCmd; }
            set { this._whereCmd = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public XMstGridDeleteRowArgs() { }

        public XMstGridDeleteRowArgs(String tableName, String whereCmd, String hospCode)
        {
            this._tableName = tableName;
            this._whereCmd = whereCmd;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XMstGridDeleteRowRequest();
        }
    }
}