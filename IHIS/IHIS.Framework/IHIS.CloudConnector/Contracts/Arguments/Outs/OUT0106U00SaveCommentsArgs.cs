using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using OUT0106U00GridItemInfo = IHIS.CloudConnector.Contracts.Models.Outs.OUT0106U00GridItemInfo;
using OUT0106U00PatientCommentItemInfo = IHIS.CloudConnector.Contracts.Models.Outs.OUT0106U00PatientCommentItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Outs
{[Serializable]
	public class OUT0106U00SaveCommentsArgs : IContractArgs
	{
    protected bool Equals(OUT0106U00SaveCommentsArgs other)
    {
        return Equals(_gridItemInfo, other._gridItemInfo) && Equals(_patientCommentItemInfo, other._patientCommentItemInfo) && string.Equals(_userId, other._userId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OUT0106U00SaveCommentsArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_gridItemInfo != null ? _gridItemInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_patientCommentItemInfo != null ? _patientCommentItemInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private List<OUT0106U00GridItemInfo> _gridItemInfo = new List<OUT0106U00GridItemInfo>();
		private List<OUT0106U00PatientCommentItemInfo> _patientCommentItemInfo = new List<OUT0106U00PatientCommentItemInfo>();
		private String _userId;

		public List<OUT0106U00GridItemInfo> GridItemInfo
		{
			get { return this._gridItemInfo; }
			set { this._gridItemInfo = value; }
		}

		public List<OUT0106U00PatientCommentItemInfo> PatientCommentItemInfo
		{
			get { return this._patientCommentItemInfo; }
			set { this._patientCommentItemInfo = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public OUT0106U00SaveCommentsArgs() { }

		public OUT0106U00SaveCommentsArgs(List<OUT0106U00GridItemInfo> gridItemInfo, List<OUT0106U00PatientCommentItemInfo> patientCommentItemInfo, String userId)
		{
			this._gridItemInfo = gridItemInfo;
			this._patientCommentItemInfo = patientCommentItemInfo;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new OUT0106U00SaveCommentsRequest();
		}
	}
}