using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0503Q00DoctorNameResult : AbstractContractResult
	{
		private String _doctorName;

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public OCS0503Q00DoctorNameResult() { }

	}
}