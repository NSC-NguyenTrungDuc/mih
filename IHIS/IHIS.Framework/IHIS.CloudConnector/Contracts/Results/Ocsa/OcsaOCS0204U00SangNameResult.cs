using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OcsaOCS0204U00SangNameResult : AbstractContractResult
	{
		private String _sangName;

		public String SangName
		{
			get { return this._sangName; }
			set { this._sangName = value; }
		}

		public OcsaOCS0204U00SangNameResult() { }

	}
}