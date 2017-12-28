using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Xrts;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
	public class XRT0201U00LayPacsResult : AbstractContractResult
	{
		private List<XRT0000Q00LayPacsInfoListItemInfo> _layPacsItemInfo = new List<XRT0000Q00LayPacsInfoListItemInfo>();
		private String _modality;

		public List<XRT0000Q00LayPacsInfoListItemInfo> LayPacsItemInfo
		{
			get { return this._layPacsItemInfo; }
			set { this._layPacsItemInfo = value; }
		}

		public String Modality
		{
			get { return this._modality; }
			set { this._modality = value; }
		}

		public XRT0201U00LayPacsResult() { }

	}
}