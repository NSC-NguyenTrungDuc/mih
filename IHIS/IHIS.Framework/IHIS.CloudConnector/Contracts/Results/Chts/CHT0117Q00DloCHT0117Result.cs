using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Chts;

namespace IHIS.CloudConnector.Contracts.Results.Chts
{
    [Serializable]
	public class CHT0117Q00DloCHT0117Result : AbstractContractResult
	{
		private List<CHT0117Q00DloCHT0117Info> _cht0117Info = new List<CHT0117Q00DloCHT0117Info>();

		public List<CHT0117Q00DloCHT0117Info> Cht0117Info
		{
			get { return this._cht0117Info; }
			set { this._cht0117Info = value; }
		}

		public CHT0117Q00DloCHT0117Result() { }

	}
}