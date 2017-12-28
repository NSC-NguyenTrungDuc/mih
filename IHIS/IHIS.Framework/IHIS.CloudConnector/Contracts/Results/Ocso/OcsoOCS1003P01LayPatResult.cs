using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocso;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003P01LayPatResult : AbstractContractResult
	{
		private List<OcsoOCS1003P01LayPatInfo> _layPatInfo = new List<OcsoOCS1003P01LayPatInfo>();

		public List<OcsoOCS1003P01LayPatInfo> LayPatInfo
		{
			get { return this._layPatInfo; }
			set { this._layPatInfo = value; }
		}

		public OcsoOCS1003P01LayPatResult() { }

	}
}