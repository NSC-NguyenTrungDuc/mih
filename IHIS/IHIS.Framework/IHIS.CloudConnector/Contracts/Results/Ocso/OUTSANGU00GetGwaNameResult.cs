using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OUTSANGU00GetGwaNameResult : AbstractContractResult
	{
		private String _gwaName;

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public OUTSANGU00GetGwaNameResult() { }

	}
}