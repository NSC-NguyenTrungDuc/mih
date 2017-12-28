using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable ]
	public class NuroOUT0101U02GridCommentResult : AbstractContractResult
	{
		private List<NuroOUT0101U02GridCommentInfo> _gridCommentItem = new List<NuroOUT0101U02GridCommentInfo>();

		public List<NuroOUT0101U02GridCommentInfo> GridCommentItem
		{
			get { return this._gridCommentItem; }
			set { this._gridCommentItem = value; }
		}

		public NuroOUT0101U02GridCommentResult() { }

	}
}