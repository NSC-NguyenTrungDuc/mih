using System;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADM101UGetGrpNmResult : AbstractContractResult
	{
		private String _grpNm;

		public String GrpNm
		{
			get { return this._grpNm; }
			set { this._grpNm = value; }
		}

		public ADM101UGetGrpNmResult() { }

	}
}