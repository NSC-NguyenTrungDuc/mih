using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroPatientCommentListResult : AbstractContractResult
	{
		private List<NuroPatientCommentListItemInfo> _patientCommentListItem = new List<NuroPatientCommentListItemInfo>();

		public List<NuroPatientCommentListItemInfo> PatientCommentListItem
		{
			get { return this._patientCommentListItem; }
			set { this._patientCommentListItem = value; }
		}

		public NuroPatientCommentListResult() { }

	}
}

