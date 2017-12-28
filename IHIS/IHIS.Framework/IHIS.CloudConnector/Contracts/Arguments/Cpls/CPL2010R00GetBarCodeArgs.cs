using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL2010R00GetBarCodeArgs : IContractArgs
    {
        protected bool Equals(CPL2010R00GetBarCodeArgs other)
        {
            return string.Equals(_specimenSer, other._specimenSer);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL2010R00GetBarCodeArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_specimenSer != null ? _specimenSer.GetHashCode() : 0);
        }

        private String _specimenSer;

        public String SpecimenSer
        {
            get { return this._specimenSer; }
            set { this._specimenSer = value; }
        }

        public CPL2010R00GetBarCodeArgs() { }

        public CPL2010R00GetBarCodeArgs(String specimenSer)
        {
            this._specimenSer = specimenSer;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010R00GetBarCodeRequest();
        }
    }
}