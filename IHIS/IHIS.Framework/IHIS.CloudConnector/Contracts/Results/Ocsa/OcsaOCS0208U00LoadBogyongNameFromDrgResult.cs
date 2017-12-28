using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OcsaOCS0208U00LoadBogyongNameFromDrgResult : AbstractContractResult
	{
		private String _bogyongName;

		public String BogyongName
		{
			get { return this._bogyongName; }
			set { this._bogyongName = value; }
		}

		public OcsaOCS0208U00LoadBogyongNameFromDrgResult() { }

	}
}