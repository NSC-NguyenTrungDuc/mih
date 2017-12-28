using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OCS1003P01OpenAllergyInforResult : AbstractContractResult
	{
		private String _allergyResult;

		public String AllergyResult
		{
			get { return this._allergyResult; }
			set { this._allergyResult = value; }
		}

		public OCS1003P01OpenAllergyInforResult() { }

	}
}