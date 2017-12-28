using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRES1001U00ReceptionNumberResult : AbstractContractResult
	{
		private String _receptionNo;

		public String ReceptionNo
		{
			get { return this._receptionNo; }
			set { this._receptionNo = value; }
		}

		public NuroRES1001U00ReceptionNumberResult() { }

	}
}