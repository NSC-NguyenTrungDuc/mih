using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class InjsINJ1001U01PrintNameListResult : AbstractContractResult
	{
		private List<String> _printNameList = new List<String>();

		public List<String> PrintNameList
		{
			get { return this._printNameList; }
			set { this._printNameList = value; }
		}

		public InjsINJ1001U01PrintNameListResult() { }

	}
}