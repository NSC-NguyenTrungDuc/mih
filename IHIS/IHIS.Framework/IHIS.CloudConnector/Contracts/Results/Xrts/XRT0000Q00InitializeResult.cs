using IHIS.CloudConnector.Contracts.Models.Xrts;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
	public class XRT0000Q00InitializeResult : AbstractContractResult
	{
		private List<XRT0000Q00LayOrderListItemInfo> _layOrderList = new List<XRT0000Q00LayOrderListItemInfo>();
		private List<XRT0000Q00LayMakeTabPageListItemInfo> _layMakeTabPageList = new List<XRT0000Q00LayMakeTabPageListItemInfo>();

		public List<XRT0000Q00LayOrderListItemInfo> LayOrderList
		{
			get { return this._layOrderList; }
			set { this._layOrderList = value; }
		}

		public List<XRT0000Q00LayMakeTabPageListItemInfo> LayMakeTabPageList
		{
			get { return this._layMakeTabPageList; }
			set { this._layMakeTabPageList = value; }
		}

		public XRT0000Q00InitializeResult() { }

	}
}