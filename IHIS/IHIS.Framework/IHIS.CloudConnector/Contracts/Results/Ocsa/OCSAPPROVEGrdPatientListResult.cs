using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCSAPPROVEGrdPatientListResult : AbstractContractResult
	{
		private List<OCSAPPROVEGrdPatientListInfo> _grdPatientListInfo = new List<OCSAPPROVEGrdPatientListInfo>();

		public List<OCSAPPROVEGrdPatientListInfo> GrdPatientListInfo
		{
			get { return this._grdPatientListInfo; }
			set { this._grdPatientListInfo = value; }
		}

		public OCSAPPROVEGrdPatientListResult() { }

	}
}