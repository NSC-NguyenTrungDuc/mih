using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuri
{
    [Serializable]
	public class NUR1016U00SelectNextValResult : AbstractContractResult
	{
		private String _nextVal;

		public String NextVal
		{
			get { return this._nextVal; }
			set { this._nextVal = value; }
		}

		public NUR1016U00SelectNextValResult() { }

	}
}