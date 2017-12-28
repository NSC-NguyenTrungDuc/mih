using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuri
{
    [Serializable]
	public class NUR0101U01GrdMasterInfo
	{
		private String _codeType;
		private String _codeTypeName;
		private String _adminGubun;
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

		public String AdminGubun
		{
			get { return this._adminGubun; }
			set { this._adminGubun = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public NUR0101U01GrdMasterInfo() { }

		public NUR0101U01GrdMasterInfo(String codeType, String codeTypeName, String adminGubun, String dataRowState)
		{
			this._codeType = codeType;
			this._codeTypeName = codeTypeName;
			this._adminGubun = adminGubun;
			this._dataRowState = dataRowState;
		}

	}
}