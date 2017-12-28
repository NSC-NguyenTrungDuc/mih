using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
	public class ADMS2015U00SystemHospitalInfo
	{
		private String _admsGroupSystemId;
		private String _systemSeq;
		private String _hospCode;
		private String _selectFlg;
		private String _systemId;
		private String _sysNm;
		private String _dataRowState;

		public String AdmsGroupSystemId
		{
			get { return this._admsGroupSystemId; }
			set { this._admsGroupSystemId = value; }
		}

		public String SystemSeq
		{
			get { return this._systemSeq; }
			set { this._systemSeq = value; }
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

		public String SystemId
		{
			get { return this._systemId; }
			set { this._systemId = value; }
		}

		public String SysNm
		{
			get { return this._sysNm; }
			set { this._sysNm = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public ADMS2015U00SystemHospitalInfo() { }

		public ADMS2015U00SystemHospitalInfo(String admsGroupSystemId, String systemSeq, String hospCode, String selectFlg, String systemId, String sysNm, String dataRowState)
		{
			this._admsGroupSystemId = admsGroupSystemId;
			this._systemSeq = systemSeq;
			this._hospCode = hospCode;
			this._selectFlg = selectFlg;
			this._systemId = systemId;
			this._sysNm = sysNm;
			this._dataRowState = dataRowState;
		}

	}
}