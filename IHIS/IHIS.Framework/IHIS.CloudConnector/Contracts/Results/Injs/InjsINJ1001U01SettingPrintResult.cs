using System;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class InjsINJ1001U01SettingPrintResult : AbstractContractResult
	{
		private Boolean _result;

		public Boolean Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public InjsINJ1001U01SettingPrintResult() { }

	}
}