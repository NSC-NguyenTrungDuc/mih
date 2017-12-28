using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OcsaOCS0304U00GetYaksokDirectNameResult : AbstractContractResult
	{
		private String _yaksokDirectName;

		public String YaksokDirectName
		{
			get { return this._yaksokDirectName; }
			set { this._yaksokDirectName = value; }
		}

		public OcsaOCS0304U00GetYaksokDirectNameResult() { }

	}
}