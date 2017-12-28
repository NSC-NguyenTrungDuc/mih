using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Models.Xrts;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
	public class XRT0201U00GrdOrderRowFocusChangedResult : AbstractContractResult
	{
		private List<XRT0201U00GrdJaeryoItemInfo> _grdJaeryoItemInfo = new List<XRT0201U00GrdJaeryoItemInfo>();
		private List<DataStringListItemInfo> _sangName = new List<DataStringListItemInfo>();
		private List<XRT0201U00DefaultJearyoItemInfo> _defaultJearyoItemInfo = new List<XRT0201U00DefaultJearyoItemInfo>();

		public List<XRT0201U00GrdJaeryoItemInfo> GrdJaeryoItemInfo
		{
			get { return this._grdJaeryoItemInfo; }
			set { this._grdJaeryoItemInfo = value; }
		}

		public List<DataStringListItemInfo> SangName
		{
			get { return this._sangName; }
			set { this._sangName = value; }
		}

		public List<XRT0201U00DefaultJearyoItemInfo> DefaultJearyoItemInfo
		{
			get { return this._defaultJearyoItemInfo; }
			set { this._defaultJearyoItemInfo = value; }
		}

		public XRT0201U00GrdOrderRowFocusChangedResult() { }

	}
}