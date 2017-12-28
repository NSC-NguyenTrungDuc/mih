using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADM101UGrdSystemArgs : IContractArgs
	{
        protected bool Equals(ADM101UGrdSystemArgs other)
        {
            return string.Equals(_grpId, other._grpId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM101UGrdSystemArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_grpId != null ? _grpId.GetHashCode() : 0);
        }

        private String _grpId;

		public String GrpId
		{
			get { return this._grpId; }
			set { this._grpId = value; }
		}

		public ADM101UGrdSystemArgs() { }

		public ADM101UGrdSystemArgs(String grpId)
		{
			this._grpId = grpId;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADM101UGrdSystemRequest();
		}
	}
}