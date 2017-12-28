using System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0310U00layGroupGubunCheckResult : AbstractContractResult
	{
		private String _count;

		public String Count
		{
			get { return this._count; }
			set { this._count = value; }
		}

		public BAS0310U00layGroupGubunCheckResult() { }

	}
}