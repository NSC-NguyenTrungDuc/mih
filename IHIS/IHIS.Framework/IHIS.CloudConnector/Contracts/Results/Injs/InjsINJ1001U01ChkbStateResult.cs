using System;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class InjsINJ1001U01ChkbStateResult : AbstractContractResult
	{
		private String _result;

		public String Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public InjsINJ1001U01ChkbStateResult() { }

	}
}