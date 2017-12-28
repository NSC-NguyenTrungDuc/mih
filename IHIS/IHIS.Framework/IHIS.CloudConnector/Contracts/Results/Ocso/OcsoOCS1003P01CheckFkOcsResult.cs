using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003P01CheckFkOcsResult : AbstractContractResult
	{
		private String _fkOcs;

		public String FkOcs
		{
			get { return this._fkOcs; }
			set { this._fkOcs = value; }
		}

		public OcsoOCS1003P01CheckFkOcsResult() { }

	}
}