using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocs.Lib
{
    [Serializable]
	public class LoadConsultEndYNResult : AbstractContractResult
	{
		private String _maxReqDate;

		public String MaxReqDate
		{
			get { return this._maxReqDate; }
			set { this._maxReqDate = value; }
		}

		public LoadConsultEndYNResult() { }

	}
}