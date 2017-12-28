using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003P01GetGroupKeyResult : AbstractContractResult
	{
		private String _groupKey;

		public String GroupKey
		{
			get { return this._groupKey; }
			set { this._groupKey = value; }
		}

		public OcsoOCS1003P01GetGroupKeyResult() { }

	}
}