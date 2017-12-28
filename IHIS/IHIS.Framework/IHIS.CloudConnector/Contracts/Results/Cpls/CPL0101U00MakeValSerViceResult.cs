using System;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL0101U00MakeValSerViceResult : AbstractContractResult
	{
		private String _name;

		public String Name
		{
			get { return this._name; }
			set { this._name = value; }
		}

		public CPL0101U00MakeValSerViceResult() { }

	}
}