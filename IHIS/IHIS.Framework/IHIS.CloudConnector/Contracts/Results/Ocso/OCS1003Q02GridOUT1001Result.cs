using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocso;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OCS1003Q02GridOUT1001Result : AbstractContractResult
	{
		private List<OCS1003Q02GridOUT1001Info> _gridOut1001Info = new List<OCS1003Q02GridOUT1001Info>();

		public List<OCS1003Q02GridOUT1001Info> GridOut1001Info
		{
			get { return this._gridOut1001Info; }
			set { this._gridOut1001Info = value; }
		}

		public OCS1003Q02GridOUT1001Result() { }

	}
}