using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRES1001U00TypeResult : AbstractContractResult
	{
		private String _type;

		public String Type
		{
			get { return this._type; }
			set { this._type = value; }
		}

		public NuroRES1001U00TypeResult() { }

	}
}