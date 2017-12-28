using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OcsaOCS0204U00SangGubunNameResult : AbstractContractResult
	{
		private String _sangGubunName;

		public String SangGubunName
		{
			get { return this._sangGubunName; }
			set { this._sangGubunName = value; }
		}

		public OcsaOCS0204U00SangGubunNameResult() { }

	}
}