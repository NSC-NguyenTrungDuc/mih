using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable ]
	public class NuroOUT0101U02GetJohapResult : AbstractContractResult
	{
		private List<NuroOUT0101U02GetJohapInfo> _johapItem = new List<NuroOUT0101U02GetJohapInfo>();

		public List<NuroOUT0101U02GetJohapInfo> JohapItem
		{
			get { return this._johapItem; }
			set { this._johapItem = value; }
		}

		public NuroOUT0101U02GetJohapResult() { }

	}
}