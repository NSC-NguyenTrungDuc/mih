using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCSAOCS0270Q00GridBAS0270Result : AbstractContractResult
	{
		private List<OCSAOCS0270Q00GridBAS0270RowInfo> _rows = new List<OCSAOCS0270Q00GridBAS0270RowInfo>();

		public List<OCSAOCS0270Q00GridBAS0270RowInfo> Rows
		{
			get { return this._rows; }
			set { this._rows = value; }
		}

		public OCSAOCS0270Q00GridBAS0270Result() { }

	}
}