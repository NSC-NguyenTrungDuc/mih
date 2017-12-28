using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocso;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OCS1003DloCheckLayoutResult : AbstractContractResult
	{
		private List<OCS1003Q09GridOUT1001Info> _gridout1001Info = new List<OCS1003Q09GridOUT1001Info>();

		public List<OCS1003Q09GridOUT1001Info> Gridout1001Info
		{
			get { return this._gridout1001Info; }
			set { this._gridout1001Info = value; }
		}

		public OCS1003DloCheckLayoutResult() { }

	}
}