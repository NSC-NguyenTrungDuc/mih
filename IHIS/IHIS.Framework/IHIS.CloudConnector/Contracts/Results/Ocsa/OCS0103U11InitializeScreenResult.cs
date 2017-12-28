using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0103U11InitializeScreenResult : AbstractContractResult
	{
		private String _sysDate;
		private String _code;
		private String _userOption;
		private List<ComboListItemInfo> _orderGubunInfo = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _suryangInfo = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _nalsuInfo = new List<ComboListItemInfo>();
		private List<LoadOftenUsedTabResponseInfo> _usedTabInfo = new List<LoadOftenUsedTabResponseInfo>();
		private List<OCS0103U11LaySlipCodeTreeInfo> _laySlipCodeTreeInfo = new List<OCS0103U11LaySlipCodeTreeInfo>();

		public String SysDate
		{
			get { return this._sysDate; }
			set { this._sysDate = value; }
		}

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String UserOption
		{
			get { return this._userOption; }
			set { this._userOption = value; }
		}

		public List<ComboListItemInfo> OrderGubunInfo
		{
			get { return this._orderGubunInfo; }
			set { this._orderGubunInfo = value; }
		}

		public List<ComboListItemInfo> SuryangInfo
		{
			get { return this._suryangInfo; }
			set { this._suryangInfo = value; }
		}

		public List<ComboListItemInfo> NalsuInfo
		{
			get { return this._nalsuInfo; }
			set { this._nalsuInfo = value; }
		}

		public List<LoadOftenUsedTabResponseInfo> UsedTabInfo
		{
			get { return this._usedTabInfo; }
			set { this._usedTabInfo = value; }
		}

		public List<OCS0103U11LaySlipCodeTreeInfo> LaySlipCodeTreeInfo
		{
			get { return this._laySlipCodeTreeInfo; }
			set { this._laySlipCodeTreeInfo = value; }
		}

		public OCS0103U11InitializeScreenResult() { }

	}
}