using System;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201U99GetJundalPartNameResult : AbstractContractResult
	{
		private String _jundalPartName;

		public String JundalPartName
		{
			get { return this._jundalPartName; }
			set { this._jundalPartName = value; }
		}

		public SchsSCH0201U99GetJundalPartNameResult() { }

	}
}