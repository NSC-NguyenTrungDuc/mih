using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuri
{
    [Serializable]
	public class NuriNUR1016U00NurAlegyMappingResult : AbstractContractResult
	{
		private String _result;

		public String Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public NuriNUR1016U00NurAlegyMappingResult() { }

	}
}