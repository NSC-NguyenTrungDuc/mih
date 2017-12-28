using System;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201U99ExecIUDResult : AbstractContractResult
	{
		private String _ioErr;

		public String IoErr
		{
			get { return this._ioErr; }
			set { this._ioErr = value; }
		}

		public SchsSCH0201U99ExecIUDResult() { }

	}
}