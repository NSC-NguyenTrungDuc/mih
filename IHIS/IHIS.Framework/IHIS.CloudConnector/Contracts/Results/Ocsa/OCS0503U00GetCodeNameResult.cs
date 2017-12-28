using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0503U00GetCodeNameResult : AbstractContractResult
	{
		private String _codeName;

		public String CodeName
		{
			get { return this._codeName; }
			set { this._codeName = value; }
		}

		public OCS0503U00GetCodeNameResult() { }

	}
}