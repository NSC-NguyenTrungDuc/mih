using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0503U00CheckInpPatientResult : AbstractContractResult
	{
		private String _pkinp1001;

		public String Pkinp1001
		{
			get { return this._pkinp1001; }
			set { this._pkinp1001 = value; }
		}

		public OCS0503U00CheckInpPatientResult() { }

	}
}