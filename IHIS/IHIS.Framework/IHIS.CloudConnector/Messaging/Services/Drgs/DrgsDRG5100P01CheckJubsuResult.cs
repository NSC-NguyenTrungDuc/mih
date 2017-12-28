using System;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
	public class DrgsDRG5100P01CheckJubsuResult : AbstractContractResult
	{
		private String _result;

		public String Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public DrgsDRG5100P01CheckJubsuResult() { }

	}
}