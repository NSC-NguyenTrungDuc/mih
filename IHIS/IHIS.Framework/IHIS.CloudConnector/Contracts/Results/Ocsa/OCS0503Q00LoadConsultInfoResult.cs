using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0503Q00LoadConsultInfoResult : AbstractContractResult
	{
		private List<OCS0503Q00LoadConsultInfo> _gridConsultInfo = new List<OCS0503Q00LoadConsultInfo>();
		private List<OCS0503Q00LoadConsultInfo> _gridRequestOut1001Info = new List<OCS0503Q00LoadConsultInfo>();

		public List<OCS0503Q00LoadConsultInfo> GridConsultInfo
		{
			get { return this._gridConsultInfo; }
			set { this._gridConsultInfo = value; }
		}

		public List<OCS0503Q00LoadConsultInfo> GridRequestOut1001Info
		{
			get { return this._gridRequestOut1001Info; }
			set { this._gridRequestOut1001Info = value; }
		}

		public OCS0503Q00LoadConsultInfoResult() { }

	}
}