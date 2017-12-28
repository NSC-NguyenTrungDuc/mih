using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DRG0102U01GrdMasterItemInfo
	{
		private String _codeType;
		private String _codeTypeName;
		private String _adminGubun;
		private String _remark;
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

		public String Remark
		{
			get { return this._remark; }
			set { this._remark = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public DRG0102U01GrdMasterItemInfo() { }

		public DRG0102U01GrdMasterItemInfo(String codeType, String codeTypeName, String adminGubun, String remark, String dataRowState)
		{
			this._codeType = codeType;
			this._codeTypeName = codeTypeName;
			this._adminGubun = adminGubun;
			this._remark = remark;
			this._dataRowState = dataRowState;
		}

	}
}