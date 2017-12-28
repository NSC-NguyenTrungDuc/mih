using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
     [Serializable]
    public class Adm107UFbxIDDataValidatingArgs : IContractArgs
    {
         protected bool Equals(Adm107UFbxIDDataValidatingArgs other)
         {
             return string.Equals(_userId, other._userId) && string.Equals(_hospCode, other._hospCode);
         }

         public override bool Equals(object obj)
         {
             if (ReferenceEquals(null, obj)) return false;
             if (ReferenceEquals(this, obj)) return true;
             if (obj.GetType() != this.GetType()) return false;
             return Equals((Adm107UFbxIDDataValidatingArgs) obj);
         }

         public override int GetHashCode()
         {
             unchecked
             {
                 return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
             }
         }

         private String _userId;
        private String _hospCode;

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

        public Adm107UFbxIDDataValidatingArgs() { }

        public Adm107UFbxIDDataValidatingArgs(String userId, String hospCode)
        {
            this._userId = userId;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Adm107UFbxIDDataValidatingRequest();
        }
    }
}