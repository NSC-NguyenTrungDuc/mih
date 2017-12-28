using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1001U01FormJusaBedLayPatientResult : AbstractContractResult
	{
		private List<String> _codeName = new List<String>();

		public List<String> CodeName
		{
			get { return this._codeName; }
			set { this._codeName = value; }
		}

		public INJ1001U01FormJusaBedLayPatientResult() { }

	}
}