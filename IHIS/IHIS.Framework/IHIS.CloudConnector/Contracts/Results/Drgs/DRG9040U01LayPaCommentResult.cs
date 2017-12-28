using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG9040U01LayPaCommentResult : AbstractContractResult
	{
		private List<DRG9040U01LayPaCommentInfo> _layPaComment = new List<DRG9040U01LayPaCommentInfo>();

		public List<DRG9040U01LayPaCommentInfo> LayPaComment
		{
			get { return this._layPaComment; }
			set { this._layPaComment = value; }
		}

		public DRG9040U01LayPaCommentResult() { }

	}
}