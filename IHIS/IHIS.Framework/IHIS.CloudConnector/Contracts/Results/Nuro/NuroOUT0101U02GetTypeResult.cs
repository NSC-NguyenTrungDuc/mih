using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable ]
	public class NuroOUT0101U02GetTypeResult : AbstractContractResult
	{
		private List<NuroOUT0101U02GetType> _typeItem = new List<NuroOUT0101U02GetType>();

		public List<NuroOUT0101U02GetType> TypeItem
		{
			get { return this._typeItem; }
			set { this._typeItem = value; }
		}

		public NuroOUT0101U02GetTypeResult() { }

	}
}