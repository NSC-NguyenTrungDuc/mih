using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Chts;

namespace IHIS.CloudConnector.Contracts.Results.Chts
{
    [Serializable]
	public class CHT0115Q00SusikCodeResult : AbstractContractResult
	{
		private List<CHT0115Q00SusikCodeInfo> _susikCodeInfo = new List<CHT0115Q00SusikCodeInfo>();

		public List<CHT0115Q00SusikCodeInfo> SusikCodeInfo
		{
			get { return this._susikCodeInfo; }
			set { this._susikCodeInfo = value; }
		}

		public CHT0115Q00SusikCodeResult() { }

	}
}