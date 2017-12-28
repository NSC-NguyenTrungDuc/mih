using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0503Q00DepartmentNameResult : AbstractContractResult
	{
		private String _gwaName;

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public OCS0503Q00DepartmentNameResult() { }

	}
}