using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003P01CheckYResult : AbstractContractResult
	{
		private String _naewonKeyValue;

		public String NaewonKeyValue
		{
			get { return this._naewonKeyValue; }
			set { this._naewonKeyValue = value; }
		}

		public OcsoOCS1003P01CheckYResult() { }

	}
}