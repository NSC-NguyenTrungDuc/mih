using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0113U00GetCodeNameResult : AbstractContractResult
	{
		private String _specimenName;

		public String SpecimenName
		{
			get { return this._specimenName; }
			set { this._specimenName = value; }
		}

		public OCS0113U00GetCodeNameResult() { }

	}
}