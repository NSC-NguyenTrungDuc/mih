using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
	public class FormScreenListResult : AbstractContractResult
	{
		private List<FormScreenInfo> _formScreenInfo = new List<FormScreenInfo>();

		public List<FormScreenInfo> FormScreenInfo
		{
			get { return this._formScreenInfo; }
			set { this._formScreenInfo = value; }
		}

		public FormScreenListResult() { }

	}
}