using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0203U00SaveLayoutArgs : IContractArgs
    {
        protected bool Equals(BAS0203U00SaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_hospCode, other._hospCode) && Equals(_grdBas0203Item, other._grdBas0203Item);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0203U00SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grdBas0203Item != null ? _grdBas0203Item.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private String _hospCode;
        private List<BAS0203U00GrdBAS0203Info> _grdBas0203Item = new List<BAS0203U00GrdBAS0203Info>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public List<BAS0203U00GrdBAS0203Info> GrdBas0203Item
        {
            get { return this._grdBas0203Item; }
            set { this._grdBas0203Item = value; }
        }

        public BAS0203U00SaveLayoutArgs() { }

        public BAS0203U00SaveLayoutArgs(String userId, String hospCode, List<BAS0203U00GrdBAS0203Info> grdBas0203Item)
        {
            this._userId = userId;
            this._hospCode = hospCode;
            this._grdBas0203Item = grdBas0203Item;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0203U00SaveLayoutRequest();
        }
    }
}