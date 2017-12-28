using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL3020U00GrdPaRowFocusChangedResult : AbstractContractResult
	{
		private List<CPL3020U00CplSpecimenInfo> _cplSpecimenItem = new List<CPL3020U00CplSpecimenInfo>();
		private String _gwaName;
		private String _hoDongName;
		private List<CPL3020U00DsvNoteListItemInfo> _dsvNoteItem = new List<CPL3020U00DsvNoteListItemInfo>();

		public List<CPL3020U00CplSpecimenInfo> CplSpecimenItem
		{
			get { return this._cplSpecimenItem; }
			set { this._cplSpecimenItem = value; }
		}

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public String HoDongName
		{
			get { return this._hoDongName; }
			set { this._hoDongName = value; }
		}

		public List<CPL3020U00DsvNoteListItemInfo> DsvNoteItem
		{
			get { return this._dsvNoteItem; }
			set { this._dsvNoteItem = value; }
		}

		public CPL3020U00GrdPaRowFocusChangedResult() { }

	}
}