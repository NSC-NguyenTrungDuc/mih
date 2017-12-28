using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocso;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OCS1003P01GrdPatientResult : AbstractContractResult
	{
		private List<OCS1003P01GrdPatientListItemInfo> _grdPatientList = new List<OCS1003P01GrdPatientListItemInfo>();
		private String _cntValue;

		public List<OCS1003P01GrdPatientListItemInfo> GrdPatientList
		{
			get { return this._grdPatientList; }
			set { this._grdPatientList = value; }
		}

		public String CntValue
		{
			get { return this._cntValue; }
			set { this._cntValue = value; }
		}

		public OCS1003P01GrdPatientResult() { }

	}
}