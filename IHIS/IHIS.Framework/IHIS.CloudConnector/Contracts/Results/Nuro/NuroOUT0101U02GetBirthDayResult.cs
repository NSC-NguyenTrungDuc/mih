using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroOUT0101U02GetBirthDayResult : AbstractContractResult
	{
		private String _birthDay;

		public String BirthDay
		{
			get { return this._birthDay; }
			set { this._birthDay = value; }
		}

		public NuroOUT0101U02GetBirthDayResult() { }

	}
}