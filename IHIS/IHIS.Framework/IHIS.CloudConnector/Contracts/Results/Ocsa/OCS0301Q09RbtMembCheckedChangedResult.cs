using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0301Q09RbtMembCheckedChangedResult : AbstractContractResult
	{
		private String _result1;
		private String _result2;
		private String _result3;

		public String Result1
		{
			get { return this._result1; }
			set { this._result1 = value; }
		}

		public String Result2
		{
			get { return this._result2; }
			set { this._result2 = value; }
		}

		public String Result3
		{
			get { return this._result3; }
			set { this._result3 = value; }
		}

		public OCS0301Q09RbtMembCheckedChangedResult() { }

	}
}