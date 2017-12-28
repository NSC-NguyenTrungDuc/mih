using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U12InitializeScreenResult : AbstractContractResult
	{
		private String _codeName;
		private String _mainDoctorCode;

		public String CodeName
		{
			get { return this._codeName; }
			set { this._codeName = value; }
		}

		public String MainDoctorCode
		{
			get { return this._mainDoctorCode; }
			set { this._mainDoctorCode = value; }
		}

		public OCS0103U12InitializeScreenResult() { }

	}
}