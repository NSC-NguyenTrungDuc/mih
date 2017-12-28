using System;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADMS2015U01SystemIdValidatingResult : AbstractContractResult
	{
		private String _sysName;

		public String SysName
		{
			get { return this._sysName; }
			set { this._sysName = value; }
		}

		public ADMS2015U01SystemIdValidatingResult() { }

	}
}