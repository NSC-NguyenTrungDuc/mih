using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0221Q01DloOCS0221Result : AbstractContractResult
	{
		private List<OCS0221Q01DloOCS0221Info> _dloOCS0221Info = new List<OCS0221Q01DloOCS0221Info>();

		public List<OCS0221Q01DloOCS0221Info> DloOCS0221Info
		{
			get { return this._dloOCS0221Info; }
			set { this._dloOCS0221Info = value; }
		}

		public OCS0221Q01DloOCS0221Result() { }

	}
}