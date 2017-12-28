using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL2010U00ChangeTimeUpdateCPL2010Args : IContractArgs
    {
        protected bool Equals(CPL2010U00ChangeTimeUpdateCPL2010Args other)
        {
            return string.Equals(_userId, other._userId) && Equals(_inputList, other._inputList);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL2010U00ChangeTimeUpdateCPL2010Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_inputList != null ? _inputList.GetHashCode() : 0);
            }
        }

        private String _userId;
        private List<CPL2010U00ChangeTimeGrdSpecimenListItemInfo> _inputList = new List<CPL2010U00ChangeTimeGrdSpecimenListItemInfo>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<CPL2010U00ChangeTimeGrdSpecimenListItemInfo> InputList
        {
            get { return this._inputList; }
            set { this._inputList = value; }
        }

        public CPL2010U00ChangeTimeUpdateCPL2010Args() { }

        public CPL2010U00ChangeTimeUpdateCPL2010Args(String userId, List<CPL2010U00ChangeTimeGrdSpecimenListItemInfo> inputList)
        {
            this._userId = userId;
            this._inputList = inputList;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010U00ChangeTimeUpdateCPL2010Request();
        }
    }
}