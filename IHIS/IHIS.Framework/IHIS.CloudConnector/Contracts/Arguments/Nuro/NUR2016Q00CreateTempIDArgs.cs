using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NUR2016Q00CreateTempIDArgs : IContractArgs
    {
        protected bool Equals(NUR2016Q00CreateTempIDArgs other)
        {
            return Equals(_tempItem, other._tempItem) && _orcaPatient.Equals(other._orcaPatient);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUR2016Q00CreateTempIDArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_tempItem != null ? _tempItem.GetHashCode() : 0)*397) ^ _orcaPatient.GetHashCode();
            }
        }

        private NUR2016Q00CreateTempIDInfo _tempItem;
        private Boolean _orcaPatient;

        public NUR2016Q00CreateTempIDInfo TempItem
        {
            get { return this._tempItem; }
            set { this._tempItem = value; }
        }

        public Boolean OrcaPatient
        {
            get { return this._orcaPatient; }
            set { this._orcaPatient = value; }
        }

        public NUR2016Q00CreateTempIDArgs() { }

        public NUR2016Q00CreateTempIDArgs(NUR2016Q00CreateTempIDInfo tempItem, Boolean orcaPatient)
        {
            this._tempItem = tempItem;
            this._orcaPatient = orcaPatient;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR2016Q00CreateTempIDRequest();
        }
    }
}