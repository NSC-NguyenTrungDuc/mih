using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01PrintNameInfo
	{
		private String _bPrintName;

		public String BPrintName
		{
			get { return this._bPrintName; }
			set { this._bPrintName = value; }
		}

		public DrgsDRG5100P01PrintNameInfo() { }

		public DrgsDRG5100P01PrintNameInfo(String bPrintName)
		{
			this._bPrintName = bPrintName;
		}

	}
}