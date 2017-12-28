using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OcsaOCS0221U00SeqResult : AbstractContractResult
	{
		private String _seqNextval;

		public String SeqNextval
		{
			get { return this._seqNextval; }
			set { this._seqNextval = value; }
		}

		public OcsaOCS0221U00SeqResult() { }

	}
}