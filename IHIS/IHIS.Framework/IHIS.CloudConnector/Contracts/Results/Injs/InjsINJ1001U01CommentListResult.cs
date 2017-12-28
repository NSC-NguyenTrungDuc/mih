using IHIS.CloudConnector.Contracts.Models.System;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class InjsINJ1001U01CommentListResult : AbstractContractResult
	{
		private List<DataStringListItemInfo> _commentList = new List<DataStringListItemInfo>();

		public List<DataStringListItemInfo> CommentList
		{
			get { return this._commentList; }
			set { this._commentList = value; }
		}

		public InjsINJ1001U01CommentListResult() { }

	}
}