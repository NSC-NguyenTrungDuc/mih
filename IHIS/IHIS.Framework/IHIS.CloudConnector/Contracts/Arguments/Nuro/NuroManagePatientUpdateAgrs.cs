using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using NuroManagePatientUpdateData = IHIS.CloudConnector.Contracts.Models.Nuro.NuroManagePatientUpdateData;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroManagePatientUpdateAgrs : IContractArgs
    {
        protected bool Equals(NuroManagePatientUpdateAgrs other)
        {
            return Equals(_managePatientUpdateData, other._managePatientUpdateData);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroManagePatientUpdateAgrs) obj);
        }

        public override int GetHashCode()
        {
            return (_managePatientUpdateData != null ? _managePatientUpdateData.GetHashCode() : 0);
        }

        private NuroManagePatientUpdateData _managePatientUpdateData;

        public NuroManagePatientUpdateAgrs()
        {

        }

        public NuroManagePatientUpdateAgrs(NuroManagePatientUpdateData managePatientUpdateData)
        {
            _managePatientUpdateData = managePatientUpdateData;
        }

        public NuroManagePatientUpdateData ManagePatientUpdateData
        {
            get { return _managePatientUpdateData; }
            set { _managePatientUpdateData = value; }
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroManagePatientUpdateRequest();
        }
    }
}
