using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{[Serializable]
	public class ADM101UGrdGroupArgs : IContractArgs
	{
    protected bool Equals(ADM101UGrdGroupArgs other)
    {
        return string.Equals(_grpId, other._grpId) && string.Equals(_grpNm, other._grpNm);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ADM101UGrdGroupArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_grpId != null ? _grpId.GetHashCode() : 0)*397) ^ (_grpNm != null ? _grpNm.GetHashCode() : 0);
        }
    }

    private String _grpId;
		private String _grpNm;

		public String GrpId
		{
			get { return this._grpId; }
			set { this._grpId = value; }
		}

		public String GrpNm
		{
			get { return this._grpNm; }
			set { this._grpNm = value; }
		}

		public ADM101UGrdGroupArgs() { }

		public ADM101UGrdGroupArgs(String grpId, String grpNm)
		{
			this._grpId = grpId;
			this._grpNm = grpNm;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADM101UGrdGroupRequest();
		}
	}
}