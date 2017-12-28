using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL3020U00GrdResultListItemInfo
	{
		private String _pkcpl3020;
		private String _gumsaName;
		private String _standardYn;
		private String _cplResult;
		private String _confirmYn;
		private String _beforeResult;
		private String _panicYn;
		private String _deltaYn;
		private String _danuiName;
		private String _standard;
		private String _comments;
		private String _fkocs;
		private String _fkcpl2010;
		private String _labNo;
		private String _hangmogCode;
		private String _specimenCode;
		private String _emergency;
		private String _gumsaja;
		private String _bunho;
		private String _resultDate;
		private String _specimenSer;
		private String _resultForm;
		private String _sourceGumsa;
		private String _groupGubun;
		private String _groupHangmog;
		private String _displayYn;
		private String _keyValue;
		private String _dataRowState;

		public String Pkcpl3020
		{
			get { return this._pkcpl3020; }
			set { this._pkcpl3020 = value; }
		}

		public String GumsaName
		{
			get { return this._gumsaName; }
			set { this._gumsaName = value; }
		}

		public String StandardYn
		{
			get { return this._standardYn; }
			set { this._standardYn = value; }
		}

		public String CplResult
		{
			get { return this._cplResult; }
			set { this._cplResult = value; }
		}

		public String ConfirmYn
		{
			get { return this._confirmYn; }
			set { this._confirmYn = value; }
		}

		public String BeforeResult
		{
			get { return this._beforeResult; }
			set { this._beforeResult = value; }
		}

		public String PanicYn
		{
			get { return this._panicYn; }
			set { this._panicYn = value; }
		}

		public String DeltaYn
		{
			get { return this._deltaYn; }
			set { this._deltaYn = value; }
		}

		public String DanuiName
		{
			get { return this._danuiName; }
			set { this._danuiName = value; }
		}

		public String Standard
		{
			get { return this._standard; }
			set { this._standard = value; }
		}

		public String Comments
		{
			get { return this._comments; }
			set { this._comments = value; }
		}

		public String Fkocs
		{
			get { return this._fkocs; }
			set { this._fkocs = value; }
		}

		public String Fkcpl2010
		{
			get { return this._fkcpl2010; }
			set { this._fkcpl2010 = value; }
		}

		public String LabNo
		{
			get { return this._labNo; }
			set { this._labNo = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String SpecimenCode
		{
			get { return this._specimenCode; }
			set { this._specimenCode = value; }
		}

		public String Emergency
		{
			get { return this._emergency; }
			set { this._emergency = value; }
		}

		public String Gumsaja
		{
			get { return this._gumsaja; }
			set { this._gumsaja = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String ResultDate
		{
			get { return this._resultDate; }
			set { this._resultDate = value; }
		}

		public String SpecimenSer
		{
			get { return this._specimenSer; }
			set { this._specimenSer = value; }
		}

		public String ResultForm
		{
			get { return this._resultForm; }
			set { this._resultForm = value; }
		}

		public String SourceGumsa
		{
			get { return this._sourceGumsa; }
			set { this._sourceGumsa = value; }
		}

		public String GroupGubun
		{
			get { return this._groupGubun; }
			set { this._groupGubun = value; }
		}

		public String GroupHangmog
		{
			get { return this._groupHangmog; }
			set { this._groupHangmog = value; }
		}

		public String DisplayYn
		{
			get { return this._displayYn; }
			set { this._displayYn = value; }
		}

		public String KeyValue
		{
			get { return this._keyValue; }
			set { this._keyValue = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public CPL3020U00GrdResultListItemInfo() { }

		public CPL3020U00GrdResultListItemInfo(String pkcpl3020, String gumsaName, String standardYn, String cplResult, String confirmYn, String beforeResult, String panicYn, String deltaYn, String danuiName, String standard, String comments, String fkocs, String fkcpl2010, String labNo, String hangmogCode, String specimenCode, String emergency, String gumsaja, String bunho, String resultDate, String specimenSer, String resultForm, String sourceGumsa, String groupGubun, String groupHangmog, String displayYn, String keyValue, String dataRowState)
		{
			this._pkcpl3020 = pkcpl3020;
			this._gumsaName = gumsaName;
			this._standardYn = standardYn;
			this._cplResult = cplResult;
			this._confirmYn = confirmYn;
			this._beforeResult = beforeResult;
			this._panicYn = panicYn;
			this._deltaYn = deltaYn;
			this._danuiName = danuiName;
			this._standard = standard;
			this._comments = comments;
			this._fkocs = fkocs;
			this._fkcpl2010 = fkcpl2010;
			this._labNo = labNo;
			this._hangmogCode = hangmogCode;
			this._specimenCode = specimenCode;
			this._emergency = emergency;
			this._gumsaja = gumsaja;
			this._bunho = bunho;
			this._resultDate = resultDate;
			this._specimenSer = specimenSer;
			this._resultForm = resultForm;
			this._sourceGumsa = sourceGumsa;
			this._groupGubun = groupGubun;
			this._groupHangmog = groupHangmog;
			this._displayYn = displayYn;
			this._keyValue = keyValue;
			this._dataRowState = dataRowState;
		}

	}
}