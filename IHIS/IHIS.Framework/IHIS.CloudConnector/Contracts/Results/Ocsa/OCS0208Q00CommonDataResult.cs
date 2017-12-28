using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0208Q00CommonDataResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _dvTimeInfo = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _dvInfo = new List<ComboListItemInfo>();
		private List<OCS0208Q00LayTabGubunInfo> _tabGubunItemList = new List<OCS0208Q00LayTabGubunInfo>();
		private List<OCS0208Q00LayBanghyangInfo> _banghyangItemList = new List<OCS0208Q00LayBanghyangInfo>();

		public List<ComboListItemInfo> DvTimeInfo
		{
			get { return this._dvTimeInfo; }
			set { this._dvTimeInfo = value; }
		}

		public List<ComboListItemInfo> DvInfo
		{
			get { return this._dvInfo; }
			set { this._dvInfo = value; }
		}

		public List<OCS0208Q00LayTabGubunInfo> TabGubunItemList
		{
			get { return this._tabGubunItemList; }
			set { this._tabGubunItemList = value; }
		}

		public List<OCS0208Q00LayBanghyangInfo> BanghyangItemList
		{
			get { return this._banghyangItemList; }
			set { this._banghyangItemList = value; }
		}

		public OCS0208Q00CommonDataResult() { }

	}
}