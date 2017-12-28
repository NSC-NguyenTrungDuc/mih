using System;

namespace IHIS.CloudConnector.Contracts.Results.Chts
{
    [Serializable]
	public class CHT0117LayNextSubBuwiCdResult : AbstractContractResult
	{
		private String _subBuwi;

		public String SubBuwi
		{
			get { return this._subBuwi; }
			set { this._subBuwi = value; }
		}

		public CHT0117LayNextSubBuwiCdResult() { }

	}
}