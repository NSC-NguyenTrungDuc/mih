using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{
    public class OCSACT2GetComboUserArgs : IContractArgs
    {
        private String _hospCode;
        private String _jundalTable;

        protected bool Equals(OCSACT2GetComboUserArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_jundalTable, other._jundalTable);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OCSACT2GetComboUserArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_hospCode != null ? _hospCode.GetHashCode() : 0)*397) ^ (_jundalTable != null ? _jundalTable.GetHashCode() : 0);
            }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String JundalTable
        {
            get { return this._jundalTable; }
            set { this._jundalTable = value; }
        }

        public OCSACT2GetComboUserArgs() { }

        public OCSACT2GetComboUserArgs(String hospCode, String jundalTable)
        {
            this._hospCode = hospCode;
            this._jundalTable = jundalTable;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACT2GetComboUserRequest();
        }
    }
}