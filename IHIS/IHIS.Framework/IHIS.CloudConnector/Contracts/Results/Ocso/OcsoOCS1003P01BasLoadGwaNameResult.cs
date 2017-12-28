using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003P01BasLoadGwaNameResult : AbstractContractResult
	{
		private String _gwaName;

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public OcsoOCS1003P01BasLoadGwaNameResult() { }

	}
}