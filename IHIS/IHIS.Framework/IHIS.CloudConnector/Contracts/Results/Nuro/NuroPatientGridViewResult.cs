using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroPatientGridViewResult : AbstractContractResult
	{
		private List<NuroPatientCommentListItemInfo> _grdCommentList = new List<NuroPatientCommentListItemInfo>();
		private List<NuroPatientInsuranceListItemInfo> _grdGongbiCodeList = new List<NuroPatientInsuranceListItemInfo>();
		private List<NuroPatientDetailListItemInfo> _grdJubsuList = new List<NuroPatientDetailListItemInfo>();
		private List<NuroPatientReceptionHistoryListItemInfo> _grdJubsuHistoryList = new List<NuroPatientReceptionHistoryListItemInfo>();

		public List<NuroPatientCommentListItemInfo> GrdCommentList
		{
			get { return this._grdCommentList; }
			set { this._grdCommentList = value; }
		}

		public List<NuroPatientInsuranceListItemInfo> GrdGongbiCodeList
		{
			get { return this._grdGongbiCodeList; }
			set { this._grdGongbiCodeList = value; }
		}

		public List<NuroPatientDetailListItemInfo> GrdJubsuList
		{
			get { return this._grdJubsuList; }
			set { this._grdJubsuList = value; }
		}

		public List<NuroPatientReceptionHistoryListItemInfo> GrdJubsuHistoryList
		{
			get { return this._grdJubsuHistoryList; }
			set { this._grdJubsuHistoryList = value; }
		}

		public NuroPatientGridViewResult() { }

	}
}