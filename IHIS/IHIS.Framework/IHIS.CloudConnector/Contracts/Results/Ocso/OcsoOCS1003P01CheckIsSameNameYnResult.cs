using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003P01CheckIsSameNameYnResult : AbstractContractResult
	{
		private String _valueCheck;

		public String ValueCheck
		{
			get { return this._valueCheck; }
			set { this._valueCheck = value; }
		}

		public OcsoOCS1003P01CheckIsSameNameYnResult() { }

	}
}