using System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0310U00FbxBunCodeDataValidatingResult : AbstractContractResult
	{
		private String _fbxBunCode;

		public String FbxBunCode
		{
			get { return this._fbxBunCode; }
			set { this._fbxBunCode = value; }
		}

		public BAS0310U00FbxBunCodeDataValidatingResult() { }

	}
}