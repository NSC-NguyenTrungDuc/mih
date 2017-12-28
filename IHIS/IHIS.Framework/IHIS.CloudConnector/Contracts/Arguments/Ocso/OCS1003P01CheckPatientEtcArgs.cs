using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using GetOutJinryoCommentCntInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.GetOutJinryoCommentCntInfo;
using GetUserOptionInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.GetUserOptionInfo;
using IpwonReserStatusInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.IpwonReserStatusInfo;
using KensaReserInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.KensaReserInfo;
using OutTaGwaJinryoCntInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.OutTaGwaJinryoCntInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OCS1003P01CheckPatientEtcArgs : IContractArgs
	{
    protected bool Equals(OCS1003P01CheckPatientEtcArgs other)
    {
        return Equals(_kensaReserInfo, other._kensaReserInfo) && string.Equals(_bunho, other._bunho) && Equals(_userOptionInfo, other._userOptionInfo) && Equals(_outTaGwaJinryoCnt, other._outTaGwaJinryoCnt) && Equals(_commentCntInfo, other._commentCntInfo) && Equals(_reserStatusInfo, other._reserStatusInfo);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS1003P01CheckPatientEtcArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_kensaReserInfo != null ? _kensaReserInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userOptionInfo != null ? _userOptionInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_outTaGwaJinryoCnt != null ? _outTaGwaJinryoCnt.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_commentCntInfo != null ? _commentCntInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_reserStatusInfo != null ? _reserStatusInfo.GetHashCode() : 0);
            return hashCode;
        }
    }

    private KensaReserInfo _kensaReserInfo;
		private String _bunho;
		private GetUserOptionInfo _userOptionInfo;
		private OutTaGwaJinryoCntInfo _outTaGwaJinryoCnt;
		private GetOutJinryoCommentCntInfo _commentCntInfo;
		private IpwonReserStatusInfo _reserStatusInfo;

		public KensaReserInfo KensaReserInfo
		{
			get { return this._kensaReserInfo; }
			set { this._kensaReserInfo = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public GetUserOptionInfo UserOptionInfo
		{
			get { return this._userOptionInfo; }
			set { this._userOptionInfo = value; }
		}

		public OutTaGwaJinryoCntInfo OutTaGwaJinryoCnt
		{
			get { return this._outTaGwaJinryoCnt; }
			set { this._outTaGwaJinryoCnt = value; }
		}

		public GetOutJinryoCommentCntInfo CommentCntInfo
		{
			get { return this._commentCntInfo; }
			set { this._commentCntInfo = value; }
		}

		public IpwonReserStatusInfo ReserStatusInfo
		{
			get { return this._reserStatusInfo; }
			set { this._reserStatusInfo = value; }
		}

		public OCS1003P01CheckPatientEtcArgs() { }

		public OCS1003P01CheckPatientEtcArgs(KensaReserInfo kensaReserInfo, String bunho, GetUserOptionInfo userOptionInfo, OutTaGwaJinryoCntInfo outTaGwaJinryoCnt, GetOutJinryoCommentCntInfo commentCntInfo, IpwonReserStatusInfo reserStatusInfo)
		{
			this._kensaReserInfo = kensaReserInfo;
			this._bunho = bunho;
			this._userOptionInfo = userOptionInfo;
			this._outTaGwaJinryoCnt = outTaGwaJinryoCnt;
			this._commentCntInfo = commentCntInfo;
			this._reserStatusInfo = reserStatusInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS1003P01CheckPatientEtcRequest();
		}
	}
}