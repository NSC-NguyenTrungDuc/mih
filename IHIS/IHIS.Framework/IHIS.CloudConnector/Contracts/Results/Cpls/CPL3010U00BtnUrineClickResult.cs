using System;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL3010U00BtnUrineClickResult : AbstractContractResult
	{
		private String _value;

		public String Value
		{
			get { return this._value; }
			set { this._value = value; }
		}

		public CPL3010U00BtnUrineClickResult() { }

	}
}