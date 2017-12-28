using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuri
{
    [Serializable]
	public class NuriNUR7001U00GetMaxSeqInNUR7001Result : AbstractContractResult
	{
		private String _result;

		public String Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public NuriNUR7001U00GetMaxSeqInNUR7001Result() { }

	}
}