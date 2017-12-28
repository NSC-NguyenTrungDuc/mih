using System;

namespace IHIS.CloudConnector.Contracts.Models.Pfes
{
    [Serializable]
	public class PFE0101U00GrdMCodeInfo
	{
		private String _codeType;
		private String _codeTypeName;

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

		public PFE0101U00GrdMCodeInfo() { }

		public PFE0101U00GrdMCodeInfo(String codeType, String codeTypeName)
		{
			this._codeType = codeType;
			this._codeTypeName = codeTypeName;
		}

	}
}