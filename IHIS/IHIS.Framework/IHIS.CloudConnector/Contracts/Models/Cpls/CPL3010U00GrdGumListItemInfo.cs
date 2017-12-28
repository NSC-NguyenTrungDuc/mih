using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL3010U00GrdGumListItemInfo
	{
		private String _specimenSer;
		private String _fkcpl2010;
		private String _gumsaName;
		private String _jangbiName;
		private String _cplResult;
		private String _specimenName;
		private String _hangmogCode;
		private String _partJubsuja;
		private String _subJubsuYn;
		private String _spcialName;
		private String _fkocs;
		private String _confirmYn;
		private String _dataRowState;

		public String SpecimenSer
		{
			get { return this._specimenSer; }
			set { this._specimenSer = value; }
		}

		public String Fkcpl2010
		{
			get { return this._fkcpl2010; }
			set { this._fkcpl2010 = value; }
		}

		public String GumsaName
		{
			get { return this._gumsaName; }
			set { this._gumsaName = value; }
		}

		public String JangbiName
		{
			get { return this._jangbiName; }
			set { this._jangbiName = value; }
		}

		public String CplResult
		{
			get { return this._cplResult; }
			set { this._cplResult = value; }
		}

		public String SpecimenName
		{
			get { return this._specimenName; }
			set { this._specimenName = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String PartJubsuja
		{
			get { return this._partJubsuja; }
			set { this._partJubsuja = value; }
		}

		public String SubJubsuYn
		{
			get { return this._subJubsuYn; }
			set { this._subJubsuYn = value; }
		}

		public String SpcialName
		{
			get { return this._spcialName; }
			set { this._spcialName = value; }
		}

		public String Fkocs
		{
			get { return this._fkocs; }
			set { this._fkocs = value; }
		}

		public String ConfirmYn
		{
			get { return this._confirmYn; }
			set { this._confirmYn = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public CPL3010U00GrdGumListItemInfo() { }

		public CPL3010U00GrdGumListItemInfo(String specimenSer, String fkcpl2010, String gumsaName, String jangbiName, String cplResult, String specimenName, String hangmogCode, String partJubsuja, String subJubsuYn, String spcialName, String fkocs, String confirmYn, String dataRowState)
		{
			this._specimenSer = specimenSer;
			this._fkcpl2010 = fkcpl2010;
			this._gumsaName = gumsaName;
			this._jangbiName = jangbiName;
			this._cplResult = cplResult;
			this._specimenName = specimenName;
			this._hangmogCode = hangmogCode;
			this._partJubsuja = partJubsuja;
			this._subJubsuYn = subJubsuYn;
			this._spcialName = spcialName;
			this._fkocs = fkocs;
			this._confirmYn = confirmYn;
			this._dataRowState = dataRowState;
		}

	}
}