using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OCS1003P01SettingVisibleByUserResult : AbstractContractResult
	{
		private String _ynValue;
		private String _countValue;

		public String YnValue
		{
			get { return this._ynValue; }
			set { this._ynValue = value; }
		}

		public String CountValue
		{
			get { return this._countValue; }
			set { this._countValue = value; }
		}

		public OCS1003P01SettingVisibleByUserResult() { }

	}
}