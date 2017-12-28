using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using NuroOUT0101U02GridCommentInfo = IHIS.CloudConnector.Contracts.Models.Nuro.NuroOUT0101U02GridCommentInfo;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class OUT0101U02GridViewResult : AbstractContractResult
	{
		private List<NuroOUT0101U02GridPatientInfo> _gridPationItem = new List<NuroOUT0101U02GridPatientInfo>();
		private List<NuroOUT0101U02GridBoheomInfo> _gridBoheomItem = new List<NuroOUT0101U02GridBoheomInfo>();
		private List<NuroOUT0101U02GridGongbiListInfo> _gridGongbiListItem = new List<NuroOUT0101U02GridGongbiListInfo>();
		private List<NuroOUT0101U02GridCommentInfo> _gridCommentItem = new List<NuroOUT0101U02GridCommentInfo>();

		public List<NuroOUT0101U02GridPatientInfo> GridPationItem
		{
			get { return this._gridPationItem; }
			set { this._gridPationItem = value; }
		}

		public List<NuroOUT0101U02GridBoheomInfo> GridBoheomItem
		{
			get { return this._gridBoheomItem; }
			set { this._gridBoheomItem = value; }
		}

		public List<NuroOUT0101U02GridGongbiListInfo> GridGongbiListItem
		{
			get { return this._gridGongbiListItem; }
			set { this._gridGongbiListItem = value; }
		}

		public List<NuroOUT0101U02GridCommentInfo> GridCommentItem
		{
			get { return this._gridCommentItem; }
			set { this._gridCommentItem = value; }
		}

		public OUT0101U02GridViewResult() { }

	}
}