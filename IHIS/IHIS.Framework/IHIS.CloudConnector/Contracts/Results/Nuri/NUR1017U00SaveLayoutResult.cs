using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuri
{
    [Serializable]
	public class NUR1017U00SaveLayoutResult : AbstractContractResult
	{
		private Boolean _saveLayoutResult;

		public Boolean SaveLayoutResult
		{
			get { return this._saveLayoutResult; }
			set { this._saveLayoutResult = value; }
		}

		public NUR1017U00SaveLayoutResult() { }

	}
}