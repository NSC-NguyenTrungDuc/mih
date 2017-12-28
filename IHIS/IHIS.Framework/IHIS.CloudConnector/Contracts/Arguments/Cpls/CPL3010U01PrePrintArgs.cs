using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL3010U01PrePrintArgs : IContractArgs
    {
        protected bool Equals(CPL3010U01PrePrintArgs other)
        {
            return string.Equals(_iraiStr, other._iraiStr) && string.Equals(_uitakCode, other._uitakCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3010U01PrePrintArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_iraiStr != null ? _iraiStr.GetHashCode() : 0)*397) ^ (_uitakCode != null ? _uitakCode.GetHashCode() : 0);
            }
        }

        private String _iraiStr;
        private String _uitakCode;

        public String IraiStr
        {
            get { return this._iraiStr; }
            set { this._iraiStr = value; }
        }

        public String UitakCode
        {
            get { return this._uitakCode; }
            set { this._uitakCode = value; }
        }

        public CPL3010U01PrePrintArgs() { }

        public CPL3010U01PrePrintArgs(String iraiStr, String uitakCode)
        {
            this._iraiStr = iraiStr;
            this._uitakCode = uitakCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3010U01PrePrintRequest();
        }
    }
}