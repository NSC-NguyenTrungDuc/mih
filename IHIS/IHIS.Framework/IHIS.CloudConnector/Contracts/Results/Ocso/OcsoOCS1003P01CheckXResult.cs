using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003P01CheckXResult : AbstractContractResult
	{
		private String _xValue;

		public String XValue
		{
			get { return this._xValue; }
			set { this._xValue = value; }
		}

		public OcsoOCS1003P01CheckXResult() { }

	}
}