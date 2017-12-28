using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0204Q00GetOcsUserNameResult : AbstractContractResult
	{
		private String _membName;

		public String MembName
		{
			get { return this._membName; }
			set { this._membName = value; }
		}

		public OCS0204Q00GetOcsUserNameResult() { }

	}
}