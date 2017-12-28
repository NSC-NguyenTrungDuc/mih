using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCSAPPROVEInitScreenResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _cboSuryang = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _cboNalsu = new List<ComboListItemInfo>();
		private List<ComboListItemInfo> _cboDv = new List<ComboListItemInfo>();
		private Boolean _postApproveVisible;
		private Boolean _approveForce;

		public List<ComboListItemInfo> CboSuryang
		{
			get { return this._cboSuryang; }
			set { this._cboSuryang = value; }
		}

		public List<ComboListItemInfo> CboNalsu
		{
			get { return this._cboNalsu; }
			set { this._cboNalsu = value; }
		}

		public List<ComboListItemInfo> CboDv
		{
			get { return this._cboDv; }
			set { this._cboDv = value; }
		}

		public Boolean PostApproveVisible
		{
			get { return this._postApproveVisible; }
			set { this._postApproveVisible = value; }
		}

		public Boolean ApproveForce
		{
			get { return this._approveForce; }
			set { this._approveForce = value; }
		}

		public OCSAPPROVEInitScreenResult() { }

	}
}