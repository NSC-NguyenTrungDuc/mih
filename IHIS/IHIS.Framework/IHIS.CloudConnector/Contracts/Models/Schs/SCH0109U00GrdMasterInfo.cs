using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
	public class SCH0109U00GrdMasterInfo
	{
		private String _codeType;
		private String _codeTypeName;
		private String _dataRowState;

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public String CodeTypeName
		{
			get { return this._codeTypeName; }
			set { this._codeTypeName = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public SCH0109U00GrdMasterInfo() { }

		public SCH0109U00GrdMasterInfo(String codeType, String codeTypeName, String dataRowState)
		{
			this._codeType = codeType;
			this._codeTypeName = codeTypeName;
			this._dataRowState = dataRowState;
		}

	}
}