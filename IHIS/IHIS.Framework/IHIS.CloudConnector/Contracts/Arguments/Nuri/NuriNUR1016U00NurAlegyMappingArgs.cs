using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuri
{
    [Serializable]
	public class NuriNUR1016U00NurAlegyMappingArgs : IContractArgs
	{
        protected bool Equals(NuriNUR1016U00NurAlegyMappingArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_tableId, other._tableId) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuriNUR1016U00NurAlegyMappingArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_tableId != null ? _tableId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
		private String _tableId;
		private String _userId;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String TableId
		{
			get { return this._tableId; }
			set { this._tableId = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public NuriNUR1016U00NurAlegyMappingArgs() { }

		public NuriNUR1016U00NurAlegyMappingArgs(String bunho, String tableId, String userId)
		{
			this._bunho = bunho;
			this._tableId = tableId;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuriNUR1016U00NurAlegyMappingRequest();
		}
	}
}