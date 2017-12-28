using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U12ScreenOpenResult : AbstractContractResult
	{
		private String _userOptionResult;
		private List<ComboListItemInfo> _cboOrderGubunBas = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _cboDvTime = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _cboSuryang = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _cboDv = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _cboNalsu = new List<ComboListItemInfo>();
		private String _ynValue;

		public String UserOptionResult
		{
			get { return this._userOptionResult; }
			set { this._userOptionResult = value; }
		}

		public List<ComboListItemInfo> CboOrderGubunBas
		{
			get { return this._cboOrderGubunBas; }
			set { this._cboOrderGubunBas = value; }
		}

		public List<ComboListItemInfo> CboDvTime
		{
			get { return this._cboDvTime; }
			set { this._cboDvTime = value; }
		}

		public List<ComboListItemInfo> CboSuryang
		{
			get { return this._cboSuryang; }
			set { this._cboSuryang = value; }
		}

		public List<ComboListItemInfo> CboDv
		{
			get { return this._cboDv; }
			set { this._cboDv = value; }
		}

		public List<ComboListItemInfo> CboNalsu
		{
			get { return this._cboNalsu; }
			set { this._cboNalsu = value; }
		}

		public String YnValue
		{
			get { return this._ynValue; }
			set { this._ynValue = value; }
		}

		public OCS0103U12ScreenOpenResult() { }

	}
}