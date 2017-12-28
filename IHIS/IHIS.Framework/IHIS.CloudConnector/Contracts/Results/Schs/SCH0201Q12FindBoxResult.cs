using System;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SCH0201Q12FindBoxResult : AbstractContractResult
	{
		private String _doctorName;

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public SCH0201Q12FindBoxResult() { }

	}
}