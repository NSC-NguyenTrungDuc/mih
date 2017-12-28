using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
	public class ADM101UGrdGroupItemInfo
	{

		private String _grpId;
		private String _grpNm;
		private String _grpSeq;
		private String _grpDesc;
		private String _dispGrpId;
		private String _dataRowState;

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

		public String GrpSeq
		{
			get { return this._grpSeq; }
			set { this._grpSeq = value; }
		}

		public String GrpDesc
		{
			get { return this._grpDesc; }
			set { this._grpDesc = value; }
		}

		public String DispGrpId
		{
			get { return this._dispGrpId; }
			set { this._dispGrpId = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public ADM101UGrdGroupItemInfo() { }

		public ADM101UGrdGroupItemInfo(String grpId, String grpNm, String grpSeq, String grpDesc, String dispGrpId, String dataRowState)
		{
			this._grpId = grpId;
			this._grpNm = grpNm;
			this._grpSeq = grpSeq;
			this._grpDesc = grpDesc;
			this._dispGrpId = dispGrpId;
			this._dataRowState = dataRowState;
		}

	}
}