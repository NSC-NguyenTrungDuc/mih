using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroGetGwaNameBAS0260Result : AbstractContractResult
	{
		private String _retValue;

		public String RetValue
		{
			get { return this._retValue; }
			set { this._retValue = value; }
		}

		public NuroGetGwaNameBAS0260Result() { }

	}
}