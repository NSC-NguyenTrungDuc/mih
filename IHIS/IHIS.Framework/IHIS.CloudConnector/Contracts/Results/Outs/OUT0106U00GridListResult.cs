using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Outs;

namespace IHIS.CloudConnector.Contracts.Results.Outs
{
    [Serializable]
	public class OUT0106U00GridListResult : AbstractContractResult
	{
		private List<OUT0106U00GridItemInfo> _gridItemInfo = new List<OUT0106U00GridItemInfo>();
		private List<OUT0106U00PatientCommentItemInfo> _patientCommentItemInfo = new List<OUT0106U00PatientCommentItemInfo>();

		public List<OUT0106U00GridItemInfo> GridItemInfo
		{
			get { return this._gridItemInfo; }
			set { this._gridItemInfo = value; }
		}

		public List<OUT0106U00PatientCommentItemInfo> PatientCommentItemInfo
		{
			get { return this._patientCommentItemInfo; }
            set { this._patientCommentItemInfo = value; }
		}

		public OUT0106U00GridListResult() { }

	}
}