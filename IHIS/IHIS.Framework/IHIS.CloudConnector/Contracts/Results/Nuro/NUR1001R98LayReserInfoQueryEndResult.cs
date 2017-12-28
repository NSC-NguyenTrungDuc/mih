using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NUR1001R98LayReserInfoQueryEndResult : AbstractContractResult
	{
		private List<DataStringListItemInfo> _reserMoveName = new List<DataStringListItemInfo>();
		private String _telItem;
		private List<DataStringListItemInfo> _codeNameItem = new List<DataStringListItemInfo>();
		private List<DataStringListItemInfo> _infoTextItem = new List<DataStringListItemInfo>();

		public List<DataStringListItemInfo> ReserMoveName
		{
			get { return this._reserMoveName; }
			set { this._reserMoveName = value; }
		}

		public String TelItem
		{
			get { return this._telItem; }
			set { this._telItem = value; }
		}

		public List<DataStringListItemInfo> CodeNameItem
		{
			get { return this._codeNameItem; }
			set { this._codeNameItem = value; }
		}

		public List<DataStringListItemInfo> InfoTextItem
		{
			get { return this._infoTextItem; }
			set { this._infoTextItem = value; }
		}

		public NUR1001R98LayReserInfoQueryEndResult() { }

	}
}