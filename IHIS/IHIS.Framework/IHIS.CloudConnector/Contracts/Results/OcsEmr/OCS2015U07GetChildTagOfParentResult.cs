using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
	public class OCS2015U07GetChildTagOfParentResult : AbstractContractResult
	{
		private List<OCS2015U07TagChildInfo> _tagChildList = new List<OCS2015U07TagChildInfo>();

		public List<OCS2015U07TagChildInfo> TagChildList
		{
			get { return this._tagChildList; }
			set { this._tagChildList = value; }
		}

		public OCS2015U07GetChildTagOfParentResult() { }

	}
}