using System;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U00EmrGetNoticeEditTimeResult : AbstractContractResult
	{
		private String _timespan;

		public String Timespan
		{
			get { return this._timespan; }
			set { this._timespan = value; }
		}

		public OCS2015U00EmrGetNoticeEditTimeResult() { }

	}
}