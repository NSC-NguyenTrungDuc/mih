using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
	public class ADMS2015U00GroupHospitalInfo
	{
		private String _admsGroupId;
		private String _grpSeq;
		private String _hospCode;
		private String _selectFlg;
		private String _grpId;
		private String _grpNm;
		private String _dataRowState;

		public String AdmsGroupId
		{
			get { return this._admsGroupId; }
			set { this._admsGroupId = value; }
		}

		public String GrpSeq
		{
			get { return this._grpSeq; }
			set { this._grpSeq = value; }
		}

		public String HospCode
		{
			get { return this._hospCode; }
			set { this._hospCode = value; }
		}

		public String SelectFlg
		{
			get { return this._selectFlg; }
			set { this._selectFlg = value; }
		}

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

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public ADMS2015U00GroupHospitalInfo() { }

		public ADMS2015U00GroupHospitalInfo(String admsGroupId, String grpSeq, String hospCode, String selectFlg, String grpId, String grpNm, String dataRowState)
		{
			this._admsGroupId = admsGroupId;
			this._grpSeq = grpSeq;
			this._hospCode = hospCode;
			this._selectFlg = selectFlg;
			this._grpId = grpId;
			this._grpNm = grpNm;
			this._dataRowState = dataRowState;
		}

	}
}