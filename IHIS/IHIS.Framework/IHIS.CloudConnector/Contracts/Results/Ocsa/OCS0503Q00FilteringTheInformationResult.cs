using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0503Q00FilteringTheInformationResult : AbstractContractResult
	{
		private List<OCS0503Q00FilteringTheInformationInfo> _grdConsultOut1001 = new List<OCS0503Q00FilteringTheInformationInfo>();
		private List<OCS0503Q00FilteringTheInformationInfo> _gridRequestOut1001Info = new List<OCS0503Q00FilteringTheInformationInfo>();

		public List<OCS0503Q00FilteringTheInformationInfo> GrdConsultOut1001
		{
			get { return this._grdConsultOut1001; }
			set { this._grdConsultOut1001 = value; }
		}

		public List<OCS0503Q00FilteringTheInformationInfo> GridRequestOut1001Info
		{
			get { return this._gridRequestOut1001Info; }
			set { this._gridRequestOut1001Info = value; }
		}

		public OCS0503Q00FilteringTheInformationResult() { }

	}
}