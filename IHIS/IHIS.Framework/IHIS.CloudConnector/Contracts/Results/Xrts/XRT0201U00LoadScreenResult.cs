using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Xrts;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
	public class XRT0201U00LoadScreenResult : AbstractContractResult
	{
		private List<XRT0201U00CbxActorItemInfo> _cbxActorItemInfo = new List<XRT0201U00CbxActorItemInfo>();
		private List<XRT0201U00GrdPaListItemInfo> _grdPaListItemInfo = new List<XRT0201U00GrdPaListItemInfo>();

		public List<XRT0201U00CbxActorItemInfo> CbxActorItemInfo
		{
			get { return this._cbxActorItemInfo; }
			set { this._cbxActorItemInfo = value; }
		}

		public List<XRT0201U00GrdPaListItemInfo> GrdPaListItemInfo
		{
			get { return this._grdPaListItemInfo; }
			set { this._grdPaListItemInfo = value; }
		}

		public XRT0201U00LoadScreenResult() { }

	}
}