using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL2010U00LayBarcodeTemp2Args : IContractArgs
    {
        protected bool Equals(CPL2010U00LayBarcodeTemp2Args other)
        {
            return string.Equals(_specimentSer, other._specimentSer);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL2010U00LayBarcodeTemp2Args) obj);
        }

        public override int GetHashCode()
        {
            return (_specimentSer != null ? _specimentSer.GetHashCode() : 0);
        }

        private String _specimentSer;

        public String SpecimentSer
        {
            get { return this._specimentSer; }
            set { this._specimentSer = value; }
        }

        public CPL2010U00LayBarcodeTemp2Args() { }

        public CPL2010U00LayBarcodeTemp2Args(String specimentSer)
        {
            this._specimentSer = specimentSer;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010U00LayBarcodeTemp2Request();
        }
    }
}