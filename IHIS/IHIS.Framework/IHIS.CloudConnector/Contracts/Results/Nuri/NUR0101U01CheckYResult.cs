using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuri
{
    [Serializable]
	public class NUR0101U01CheckYResult : AbstractContractResult
	{
		private String _yValue;

		public String YValue
		{
			get { return this._yValue; }
			set { this._yValue = value; }
		}

		public NUR0101U01CheckYResult() { }

	}
}