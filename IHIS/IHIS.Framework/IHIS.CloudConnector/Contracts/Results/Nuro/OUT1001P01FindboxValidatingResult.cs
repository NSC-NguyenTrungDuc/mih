using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class OUT1001P01FindboxValidatingResult : AbstractContractResult
	{
		private String _gwaName;
		private String _doctorName;

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public OUT1001P01FindboxValidatingResult() { }

	}
}