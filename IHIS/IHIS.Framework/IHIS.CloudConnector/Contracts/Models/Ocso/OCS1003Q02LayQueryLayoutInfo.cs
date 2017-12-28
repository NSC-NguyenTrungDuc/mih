using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
	public class OCS1003Q02LayQueryLayoutInfo
	{
		private String _inOutKey;
		private String _pkocskey;
		private String _bunho;
		private String _orderDate;
		private String _gwa;
		private String _doctor;
		private String _resident;
		private String _naewonType;
		private String _jubsuNo;
		private String _inputId;
		private String _inputPart;
		private String _inputGwa;
		private String _inputDoctor;
		private String _inputGubun;
		private String _inputGubunName;
		private String _groupSer;
		private String _inputTab;
		private String _inputTabName;
		private String _orderGubun;
		private String _orderGubunName;
		private String _groupYn;
		private String _seq;
		private String _slipCode;
		private String _hangmogCode;
		private String _hangmogName;
		private String _specimenCode;
		private String _specimenName;
		private String _suryang;
		private String _sunabSuryang;
		private String _subulSuryang;
		private String _ordDanui;
		private String _ordDanuiName;
		private String _dvTime;
		private String _dv;
		private String _dv1;
		private String _dv2;
		private String _dv3;
		private String _dv4;
		private String _nalsu;
		private String _sunabNalsu;
		private String _jusa;
		private String _jusaName;
		private String _jusaSpdGubun;
		private String _bogyongCode;
		private String _bogyongName;
		private String _emergency;
		private String _jaeryoJundalYn;
		private String _jundalTable;
		private String _jundalPart;
		private String _movePart;
		private String _portableYn;
		private String _powderYn;
		private String _hubalChangeYn;
		private String _pharmacy;
		private String _drgPackYn;
		private String _muhyo;
		private String _prnYn;
		private String _toiwonDrgYn;
		private String _prnNurse;
		private String _appendYn;
		private String _orderRemark;
		private String _nurseRemark;
		private String _comments;
		private String _mixGroup;
		private String _amt;
		private String _pay;
		private String _wonyoiOrderYn;
		private String _dangilGumsaOrderYn;
		private String _dangilGumsaResultYn;
		private String _bomOccurYn;
		private String _bomSourceKey;
		private String _displayYn;
		private String _sunabYn;
		private String _sunabDate;
		private String _sunabTime;
		private String _hopeDate;
		private String _hopeTime;
		private String _nurseConfirmUser;
		private String _nurseConfirmDate;
		private String _nurseConfirmTime;
		private String _nursePickupUser;
		private String _nursePickupDate;
		private String _nursePickupTime;
		private String _nurseHoldUser;
		private String _nurseHoldDate;
		private String _nurseHoldTime;
		private String _reserDate;
		private String _reserTime;
		private String _jubsuDate;
		private String _jubsuTime;
		private String _actingDate;
		private String _actingTime;
		private String _actingDay;
		private String _resultDate;
		private String _dcGubun;
		private String _dcYn;
		private String _bannabYn;
		private String _bannabConfirm;
		private String _sourceOrdKey;
		private String _ocsFlag;
		private String _sgCode;
		private String _sgYmd;
		private String _ioGubun;
		private String _afterActYn;
		private String _bichiYn;
		private String _drgBunho;
		private String _subSusul;
		private String _printYn;
		private String _chisik;
		private String _telYn;
		private String _orderGubunBas;
		private String _inputControl;
		private String _sugaYn;
		private String _jaeryoYn;
		private String _wonyoiCheck;
		private String _emergencyCheck;
		private String _specimenCheck;
		private String _portableYn2;
		private String _bulyongCheck;
		private String _sunabCheck;
		private String _dcCheck;
		private String _dcGubunCheck;
		private String _confirmCheck;
		private String _reserYnCheck;
		private String _chisikYn;
		private String _ndayYn;
		private String _defaultJaeryoJundalYn;
		private String _defaultWonyoiYn;
		private String _specificComment;
		private String _specificCommentName;
		private String _specificCommentSysId;
		private String _specificCommentPgmId;
		private String _specificCommentNotNull;
		private String _specificCommentTableId;
		private String _specificCommentColId;
		private String _donbogYn;
		private String _orderGubunBasName;
		private String _actDoctor;
		private String _actBuseo;
		private String _actGwa;
		private String _homeCareYn;
		private String _regularYn;
		private String _sortFkocskey;
		private String _childYn;
		private String _ifInputControl;
		private String _slipName;
		private String _orgKey;
		private String _parentKey;
		private String _bunCode;
		private String _dv5;
		private String _dv6;
		private String _dv7;
		private String _dv8;
		private String _wonnaeDrgYn;
		private String _hubalChangeCheck;
		private String _drgPackCheck;
		private String _pharmacyCheck;
		private String _powerCheck;
		private String _imsiDrugYn;
		private String _orderByKey;

		public String InOutKey
		{
			get { return this._inOutKey; }
			set { this._inOutKey = value; }
		}

		public String Pkocskey
		{
			get { return this._pkocskey; }
			set { this._pkocskey = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String Resident
		{
			get { return this._resident; }
			set { this._resident = value; }
		}

		public String NaewonType
		{
			get { return this._naewonType; }
			set { this._naewonType = value; }
		}

		public String JubsuNo
		{
			get { return this._jubsuNo; }
			set { this._jubsuNo = value; }
		}

		public String InputId
		{
			get { return this._inputId; }
			set { this._inputId = value; }
		}

		public String InputPart
		{
			get { return this._inputPart; }
			set { this._inputPart = value; }
		}

		public String InputGwa
		{
			get { return this._inputGwa; }
			set { this._inputGwa = value; }
		}

		public String InputDoctor
		{
			get { return this._inputDoctor; }
			set { this._inputDoctor = value; }
		}

		public String InputGubun
		{
			get { return this._inputGubun; }
			set { this._inputGubun = value; }
		}

		public String InputGubunName
		{
			get { return this._inputGubunName; }
			set { this._inputGubunName = value; }
		}

		public String GroupSer
		{
			get { return this._groupSer; }
			set { this._groupSer = value; }
		}

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public String InputTabName
		{
			get { return this._inputTabName; }
			set { this._inputTabName = value; }
		}

		public String OrderGubun
		{
			get { return this._orderGubun; }
			set { this._orderGubun = value; }
		}

		public String OrderGubunName
		{
			get { return this._orderGubunName; }
			set { this._orderGubunName = value; }
		}

		public String GroupYn
		{
			get { return this._groupYn; }
			set { this._groupYn = value; }
		}

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
		}

		public String SlipCode
		{
			get { return this._slipCode; }
			set { this._slipCode = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String HangmogName
		{
			get { return this._hangmogName; }
			set { this._hangmogName = value; }
		}

		public String SpecimenCode
		{
			get { return this._specimenCode; }
			set { this._specimenCode = value; }
		}

		public String SpecimenName
		{
			get { return this._specimenName; }
			set { this._specimenName = value; }
		}

		public String Suryang
		{
			get { return this._suryang; }
			set { this._suryang = value; }
		}

		public String SunabSuryang
		{
			get { return this._sunabSuryang; }
			set { this._sunabSuryang = value; }
		}

		public String SubulSuryang
		{
			get { return this._subulSuryang; }
			set { this._subulSuryang = value; }
		}

		public String OrdDanui
		{
			get { return this._ordDanui; }
			set { this._ordDanui = value; }
		}

		public String OrdDanuiName
		{
			get { return this._ordDanuiName; }
			set { this._ordDanuiName = value; }
		}

		public String DvTime
		{
			get { return this._dvTime; }
			set { this._dvTime = value; }
		}

		public String Dv
		{
			get { return this._dv; }
			set { this._dv = value; }
		}

		public String Dv1
		{
			get { return this._dv1; }
			set { this._dv1 = value; }
		}

		public String Dv2
		{
			get { return this._dv2; }
			set { this._dv2 = value; }
		}

		public String Dv3
		{
			get { return this._dv3; }
			set { this._dv3 = value; }
		}

		public String Dv4
		{
			get { return this._dv4; }
			set { this._dv4 = value; }
		}

		public String Nalsu
		{
			get { return this._nalsu; }
			set { this._nalsu = value; }
		}

		public String SunabNalsu
		{
			get { return this._sunabNalsu; }
			set { this._sunabNalsu = value; }
		}

		public String Jusa
		{
			get { return this._jusa; }
			set { this._jusa = value; }
		}

		public String JusaName
		{
			get { return this._jusaName; }
			set { this._jusaName = value; }
		}

		public String JusaSpdGubun
		{
			get { return this._jusaSpdGubun; }
			set { this._jusaSpdGubun = value; }
		}

		public String BogyongCode
		{
			get { return this._bogyongCode; }
			set { this._bogyongCode = value; }
		}

		public String BogyongName
		{
			get { return this._bogyongName; }
			set { this._bogyongName = value; }
		}

		public String Emergency
		{
			get { return this._emergency; }
			set { this._emergency = value; }
		}

		public String JaeryoJundalYn
		{
			get { return this._jaeryoJundalYn; }
			set { this._jaeryoJundalYn = value; }
		}

		public String JundalTable
		{
			get { return this._jundalTable; }
			set { this._jundalTable = value; }
		}

		public String JundalPart
		{
			get { return this._jundalPart; }
			set { this._jundalPart = value; }
		}

		public String MovePart
		{
			get { return this._movePart; }
			set { this._movePart = value; }
		}

		public String PortableYn
		{
			get { return this._portableYn; }
			set { this._portableYn = value; }
		}

		public String PowderYn
		{
			get { return this._powderYn; }
			set { this._powderYn = value; }
		}

		public String HubalChangeYn
		{
			get { return this._hubalChangeYn; }
			set { this._hubalChangeYn = value; }
		}

		public String Pharmacy
		{
			get { return this._pharmacy; }
			set { this._pharmacy = value; }
		}

		public String DrgPackYn
		{
			get { return this._drgPackYn; }
			set { this._drgPackYn = value; }
		}

		public String Muhyo
		{
			get { return this._muhyo; }
			set { this._muhyo = value; }
		}

		public String PrnYn
		{
			get { return this._prnYn; }
			set { this._prnYn = value; }
		}

		public String ToiwonDrgYn
		{
			get { return this._toiwonDrgYn; }
			set { this._toiwonDrgYn = value; }
		}

		public String PrnNurse
		{
			get { return this._prnNurse; }
			set { this._prnNurse = value; }
		}

		public String AppendYn
		{
			get { return this._appendYn; }
			set { this._appendYn = value; }
		}

		public String OrderRemark
		{
			get { return this._orderRemark; }
			set { this._orderRemark = value; }
		}

		public String NurseRemark
		{
			get { return this._nurseRemark; }
			set { this._nurseRemark = value; }
		}

		public String Comments
		{
			get { return this._comments; }
			set { this._comments = value; }
		}

		public String MixGroup
		{
			get { return this._mixGroup; }
			set { this._mixGroup = value; }
		}

		public String Amt
		{
			get { return this._amt; }
			set { this._amt = value; }
		}

		public String Pay
		{
			get { return this._pay; }
			set { this._pay = value; }
		}

		public String WonyoiOrderYn
		{
			get { return this._wonyoiOrderYn; }
			set { this._wonyoiOrderYn = value; }
		}

		public String DangilGumsaOrderYn
		{
			get { return this._dangilGumsaOrderYn; }
			set { this._dangilGumsaOrderYn = value; }
		}

		public String DangilGumsaResultYn
		{
			get { return this._dangilGumsaResultYn; }
			set { this._dangilGumsaResultYn = value; }
		}

		public String BomOccurYn
		{
			get { return this._bomOccurYn; }
			set { this._bomOccurYn = value; }
		}

		public String BomSourceKey
		{
			get { return this._bomSourceKey; }
			set { this._bomSourceKey = value; }
		}

		public String DisplayYn
		{
			get { return this._displayYn; }
			set { this._displayYn = value; }
		}

		public String SunabYn
		{
			get { return this._sunabYn; }
			set { this._sunabYn = value; }
		}

		public String SunabDate
		{
			get { return this._sunabDate; }
			set { this._sunabDate = value; }
		}

		public String SunabTime
		{
			get { return this._sunabTime; }
			set { this._sunabTime = value; }
		}

		public String HopeDate
		{
			get { return this._hopeDate; }
			set { this._hopeDate = value; }
		}

		public String HopeTime
		{
			get { return this._hopeTime; }
			set { this._hopeTime = value; }
		}

		public String NurseConfirmUser
		{
			get { return this._nurseConfirmUser; }
			set { this._nurseConfirmUser = value; }
		}

		public String NurseConfirmDate
		{
			get { return this._nurseConfirmDate; }
			set { this._nurseConfirmDate = value; }
		}

		public String NurseConfirmTime
		{
			get { return this._nurseConfirmTime; }
			set { this._nurseConfirmTime = value; }
		}

		public String NursePickupUser
		{
			get { return this._nursePickupUser; }
			set { this._nursePickupUser = value; }
		}

		public String NursePickupDate
		{
			get { return this._nursePickupDate; }
			set { this._nursePickupDate = value; }
		}

		public String NursePickupTime
		{
			get { return this._nursePickupTime; }
			set { this._nursePickupTime = value; }
		}

		public String NurseHoldUser
		{
			get { return this._nurseHoldUser; }
			set { this._nurseHoldUser = value; }
		}

		public String NurseHoldDate
		{
			get { return this._nurseHoldDate; }
			set { this._nurseHoldDate = value; }
		}

		public String NurseHoldTime
		{
			get { return this._nurseHoldTime; }
			set { this._nurseHoldTime = value; }
		}

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public String ReserTime
		{
			get { return this._reserTime; }
			set { this._reserTime = value; }
		}

		public String JubsuDate
		{
			get { return this._jubsuDate; }
			set { this._jubsuDate = value; }
		}

		public String JubsuTime
		{
			get { return this._jubsuTime; }
			set { this._jubsuTime = value; }
		}

		public String ActingDate
		{
			get { return this._actingDate; }
			set { this._actingDate = value; }
		}

		public String ActingTime
		{
			get { return this._actingTime; }
			set { this._actingTime = value; }
		}

		public String ActingDay
		{
			get { return this._actingDay; }
			set { this._actingDay = value; }
		}

		public String ResultDate
		{
			get { return this._resultDate; }
			set { this._resultDate = value; }
		}

		public String DcGubun
		{
			get { return this._dcGubun; }
			set { this._dcGubun = value; }
		}

		public String DcYn
		{
			get { return this._dcYn; }
			set { this._dcYn = value; }
		}

		public String BannabYn
		{
			get { return this._bannabYn; }
			set { this._bannabYn = value; }
		}

		public String BannabConfirm
		{
			get { return this._bannabConfirm; }
			set { this._bannabConfirm = value; }
		}

		public String SourceOrdKey
		{
			get { return this._sourceOrdKey; }
			set { this._sourceOrdKey = value; }
		}

		public String OcsFlag
		{
			get { return this._ocsFlag; }
			set { this._ocsFlag = value; }
		}

		public String SgCode
		{
			get { return this._sgCode; }
			set { this._sgCode = value; }
		}

		public String SgYmd
		{
			get { return this._sgYmd; }
			set { this._sgYmd = value; }
		}

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String AfterActYn
		{
			get { return this._afterActYn; }
			set { this._afterActYn = value; }
		}

		public String BichiYn
		{
			get { return this._bichiYn; }
			set { this._bichiYn = value; }
		}

		public String DrgBunho
		{
			get { return this._drgBunho; }
			set { this._drgBunho = value; }
		}

		public String SubSusul
		{
			get { return this._subSusul; }
			set { this._subSusul = value; }
		}

		public String PrintYn
		{
			get { return this._printYn; }
			set { this._printYn = value; }
		}

		public String Chisik
		{
			get { return this._chisik; }
			set { this._chisik = value; }
		}

		public String TelYn
		{
			get { return this._telYn; }
			set { this._telYn = value; }
		}

		public String OrderGubunBas
		{
			get { return this._orderGubunBas; }
			set { this._orderGubunBas = value; }
		}

		public String InputControl
		{
			get { return this._inputControl; }
			set { this._inputControl = value; }
		}

		public String SugaYn
		{
			get { return this._sugaYn; }
			set { this._sugaYn = value; }
		}

		public String JaeryoYn
		{
			get { return this._jaeryoYn; }
			set { this._jaeryoYn = value; }
		}

		public String WonyoiCheck
		{
			get { return this._wonyoiCheck; }
			set { this._wonyoiCheck = value; }
		}

		public String EmergencyCheck
		{
			get { return this._emergencyCheck; }
			set { this._emergencyCheck = value; }
		}

		public String SpecimenCheck
		{
			get { return this._specimenCheck; }
			set { this._specimenCheck = value; }
		}

		public String PortableYn2
		{
			get { return this._portableYn2; }
			set { this._portableYn2 = value; }
		}

		public String BulyongCheck
		{
			get { return this._bulyongCheck; }
			set { this._bulyongCheck = value; }
		}

		public String SunabCheck
		{
			get { return this._sunabCheck; }
			set { this._sunabCheck = value; }
		}

		public String DcCheck
		{
			get { return this._dcCheck; }
			set { this._dcCheck = value; }
		}

		public String DcGubunCheck
		{
			get { return this._dcGubunCheck; }
			set { this._dcGubunCheck = value; }
		}

		public String ConfirmCheck
		{
			get { return this._confirmCheck; }
			set { this._confirmCheck = value; }
		}

		public String ReserYnCheck
		{
			get { return this._reserYnCheck; }
			set { this._reserYnCheck = value; }
		}

		public String ChisikYn
		{
			get { return this._chisikYn; }
			set { this._chisikYn = value; }
		}

		public String NdayYn
		{
			get { return this._ndayYn; }
			set { this._ndayYn = value; }
		}

		public String DefaultJaeryoJundalYn
		{
			get { return this._defaultJaeryoJundalYn; }
			set { this._defaultJaeryoJundalYn = value; }
		}

		public String DefaultWonyoiYn
		{
			get { return this._defaultWonyoiYn; }
			set { this._defaultWonyoiYn = value; }
		}

		public String SpecificComment
		{
			get { return this._specificComment; }
			set { this._specificComment = value; }
		}

		public String SpecificCommentName
		{
			get { return this._specificCommentName; }
			set { this._specificCommentName = value; }
		}

		public String SpecificCommentSysId
		{
			get { return this._specificCommentSysId; }
			set { this._specificCommentSysId = value; }
		}

		public String SpecificCommentPgmId
		{
			get { return this._specificCommentPgmId; }
			set { this._specificCommentPgmId = value; }
		}

		public String SpecificCommentNotNull
		{
			get { return this._specificCommentNotNull; }
			set { this._specificCommentNotNull = value; }
		}

		public String SpecificCommentTableId
		{
			get { return this._specificCommentTableId; }
			set { this._specificCommentTableId = value; }
		}

		public String SpecificCommentColId
		{
			get { return this._specificCommentColId; }
			set { this._specificCommentColId = value; }
		}

		public String DonbogYn
		{
			get { return this._donbogYn; }
			set { this._donbogYn = value; }
		}

		public String OrderGubunBasName
		{
			get { return this._orderGubunBasName; }
			set { this._orderGubunBasName = value; }
		}

		public String ActDoctor
		{
			get { return this._actDoctor; }
			set { this._actDoctor = value; }
		}

		public String ActBuseo
		{
			get { return this._actBuseo; }
			set { this._actBuseo = value; }
		}

		public String ActGwa
		{
			get { return this._actGwa; }
			set { this._actGwa = value; }
		}

		public String HomeCareYn
		{
			get { return this._homeCareYn; }
			set { this._homeCareYn = value; }
		}

		public String RegularYn
		{
			get { return this._regularYn; }
			set { this._regularYn = value; }
		}

		public String SortFkocskey
		{
			get { return this._sortFkocskey; }
			set { this._sortFkocskey = value; }
		}

		public String ChildYn
		{
			get { return this._childYn; }
			set { this._childYn = value; }
		}

		public String IfInputControl
		{
			get { return this._ifInputControl; }
			set { this._ifInputControl = value; }
		}

		public String SlipName
		{
			get { return this._slipName; }
			set { this._slipName = value; }
		}

		public String OrgKey
		{
			get { return this._orgKey; }
			set { this._orgKey = value; }
		}

		public String ParentKey
		{
			get { return this._parentKey; }
			set { this._parentKey = value; }
		}

		public String BunCode
		{
			get { return this._bunCode; }
			set { this._bunCode = value; }
		}

		public String Dv5
		{
			get { return this._dv5; }
			set { this._dv5 = value; }
		}

		public String Dv6
		{
			get { return this._dv6; }
			set { this._dv6 = value; }
		}

		public String Dv7
		{
			get { return this._dv7; }
			set { this._dv7 = value; }
		}

		public String Dv8
		{
			get { return this._dv8; }
			set { this._dv8 = value; }
		}

		public String WonnaeDrgYn
		{
			get { return this._wonnaeDrgYn; }
			set { this._wonnaeDrgYn = value; }
		}

		public String HubalChangeCheck
		{
			get { return this._hubalChangeCheck; }
			set { this._hubalChangeCheck = value; }
		}

		public String DrgPackCheck
		{
			get { return this._drgPackCheck; }
			set { this._drgPackCheck = value; }
		}

		public String PharmacyCheck
		{
			get { return this._pharmacyCheck; }
			set { this._pharmacyCheck = value; }
		}

		public String PowerCheck
		{
			get { return this._powerCheck; }
			set { this._powerCheck = value; }
		}

		public String ImsiDrugYn
		{
			get { return this._imsiDrugYn; }
			set { this._imsiDrugYn = value; }
		}

		public String OrderByKey
		{
			get { return this._orderByKey; }
			set { this._orderByKey = value; }
		}

		public OCS1003Q02LayQueryLayoutInfo() { }

		public OCS1003Q02LayQueryLayoutInfo(String inOutKey, String pkocskey, String bunho, String orderDate, String gwa, String doctor, String resident, String naewonType, String jubsuNo, String inputId, String inputPart, String inputGwa, String inputDoctor, String inputGubun, String inputGubunName, String groupSer, String inputTab, String inputTabName, String orderGubun, String orderGubunName, String groupYn, String seq, String slipCode, String hangmogCode, String hangmogName, String specimenCode, String specimenName, String suryang, String sunabSuryang, String subulSuryang, String ordDanui, String ordDanuiName, String dvTime, String dv, String dv1, String dv2, String dv3, String dv4, String nalsu, String sunabNalsu, String jusa, String jusaName, String jusaSpdGubun, String bogyongCode, String bogyongName, String emergency, String jaeryoJundalYn, String jundalTable, String jundalPart, String movePart, String portableYn, String powderYn, String hubalChangeYn, String pharmacy, String drgPackYn, String muhyo, String prnYn, String toiwonDrgYn, String prnNurse, String appendYn, String orderRemark, String nurseRemark, String comments, String mixGroup, String amt, String pay, String wonyoiOrderYn, String dangilGumsaOrderYn, String dangilGumsaResultYn, String bomOccurYn, String bomSourceKey, String displayYn, String sunabYn, String sunabDate, String sunabTime, String hopeDate, String hopeTime, String nurseConfirmUser, String nurseConfirmDate, String nurseConfirmTime, String nursePickupUser, String nursePickupDate, String nursePickupTime, String nurseHoldUser, String nurseHoldDate, String nurseHoldTime, String reserDate, String reserTime, String jubsuDate, String jubsuTime, String actingDate, String actingTime, String actingDay, String resultDate, String dcGubun, String dcYn, String bannabYn, String bannabConfirm, String sourceOrdKey, String ocsFlag, String sgCode, String sgYmd, String ioGubun, String afterActYn, String bichiYn, String drgBunho, String subSusul, String printYn, String chisik, String telYn, String orderGubunBas, String inputControl, String sugaYn, String jaeryoYn, String wonyoiCheck, String emergencyCheck, String specimenCheck, String portableYn2, String bulyongCheck, String sunabCheck, String dcCheck, String dcGubunCheck, String confirmCheck, String reserYnCheck, String chisikYn, String ndayYn, String defaultJaeryoJundalYn, String defaultWonyoiYn, String specificComment, String specificCommentName, String specificCommentSysId, String specificCommentPgmId, String specificCommentNotNull, String specificCommentTableId, String specificCommentColId, String donbogYn, String orderGubunBasName, String actDoctor, String actBuseo, String actGwa, String homeCareYn, String regularYn, String sortFkocskey, String childYn, String ifInputControl, String slipName, String orgKey, String parentKey, String bunCode, String dv5, String dv6, String dv7, String dv8, String wonnaeDrgYn, String hubalChangeCheck, String drgPackCheck, String pharmacyCheck, String powerCheck, String imsiDrugYn, String orderByKey)
		{
			this._inOutKey = inOutKey;
			this._pkocskey = pkocskey;
			this._bunho = bunho;
			this._orderDate = orderDate;
			this._gwa = gwa;
			this._doctor = doctor;
			this._resident = resident;
			this._naewonType = naewonType;
			this._jubsuNo = jubsuNo;
			this._inputId = inputId;
			this._inputPart = inputPart;
			this._inputGwa = inputGwa;
			this._inputDoctor = inputDoctor;
			this._inputGubun = inputGubun;
			this._inputGubunName = inputGubunName;
			this._groupSer = groupSer;
			this._inputTab = inputTab;
			this._inputTabName = inputTabName;
			this._orderGubun = orderGubun;
			this._orderGubunName = orderGubunName;
			this._groupYn = groupYn;
			this._seq = seq;
			this._slipCode = slipCode;
			this._hangmogCode = hangmogCode;
			this._hangmogName = hangmogName;
			this._specimenCode = specimenCode;
			this._specimenName = specimenName;
			this._suryang = suryang;
			this._sunabSuryang = sunabSuryang;
			this._subulSuryang = subulSuryang;
			this._ordDanui = ordDanui;
			this._ordDanuiName = ordDanuiName;
			this._dvTime = dvTime;
			this._dv = dv;
			this._dv1 = dv1;
			this._dv2 = dv2;
			this._dv3 = dv3;
			this._dv4 = dv4;
			this._nalsu = nalsu;
			this._sunabNalsu = sunabNalsu;
			this._jusa = jusa;
			this._jusaName = jusaName;
			this._jusaSpdGubun = jusaSpdGubun;
			this._bogyongCode = bogyongCode;
			this._bogyongName = bogyongName;
			this._emergency = emergency;
			this._jaeryoJundalYn = jaeryoJundalYn;
			this._jundalTable = jundalTable;
			this._jundalPart = jundalPart;
			this._movePart = movePart;
			this._portableYn = portableYn;
			this._powderYn = powderYn;
			this._hubalChangeYn = hubalChangeYn;
			this._pharmacy = pharmacy;
			this._drgPackYn = drgPackYn;
			this._muhyo = muhyo;
			this._prnYn = prnYn;
			this._toiwonDrgYn = toiwonDrgYn;
			this._prnNurse = prnNurse;
			this._appendYn = appendYn;
			this._orderRemark = orderRemark;
			this._nurseRemark = nurseRemark;
			this._comments = comments;
			this._mixGroup = mixGroup;
			this._amt = amt;
			this._pay = pay;
			this._wonyoiOrderYn = wonyoiOrderYn;
			this._dangilGumsaOrderYn = dangilGumsaOrderYn;
			this._dangilGumsaResultYn = dangilGumsaResultYn;
			this._bomOccurYn = bomOccurYn;
			this._bomSourceKey = bomSourceKey;
			this._displayYn = displayYn;
			this._sunabYn = sunabYn;
			this._sunabDate = sunabDate;
			this._sunabTime = sunabTime;
			this._hopeDate = hopeDate;
			this._hopeTime = hopeTime;
			this._nurseConfirmUser = nurseConfirmUser;
			this._nurseConfirmDate = nurseConfirmDate;
			this._nurseConfirmTime = nurseConfirmTime;
			this._nursePickupUser = nursePickupUser;
			this._nursePickupDate = nursePickupDate;
			this._nursePickupTime = nursePickupTime;
			this._nurseHoldUser = nurseHoldUser;
			this._nurseHoldDate = nurseHoldDate;
			this._nurseHoldTime = nurseHoldTime;
			this._reserDate = reserDate;
			this._reserTime = reserTime;
			this._jubsuDate = jubsuDate;
			this._jubsuTime = jubsuTime;
			this._actingDate = actingDate;
			this._actingTime = actingTime;
			this._actingDay = actingDay;
			this._resultDate = resultDate;
			this._dcGubun = dcGubun;
			this._dcYn = dcYn;
			this._bannabYn = bannabYn;
			this._bannabConfirm = bannabConfirm;
			this._sourceOrdKey = sourceOrdKey;
			this._ocsFlag = ocsFlag;
			this._sgCode = sgCode;
			this._sgYmd = sgYmd;
			this._ioGubun = ioGubun;
			this._afterActYn = afterActYn;
			this._bichiYn = bichiYn;
			this._drgBunho = drgBunho;
			this._subSusul = subSusul;
			this._printYn = printYn;
			this._chisik = chisik;
			this._telYn = telYn;
			this._orderGubunBas = orderGubunBas;
			this._inputControl = inputControl;
			this._sugaYn = sugaYn;
			this._jaeryoYn = jaeryoYn;
			this._wonyoiCheck = wonyoiCheck;
			this._emergencyCheck = emergencyCheck;
			this._specimenCheck = specimenCheck;
			this._portableYn2 = portableYn2;
			this._bulyongCheck = bulyongCheck;
			this._sunabCheck = sunabCheck;
			this._dcCheck = dcCheck;
			this._dcGubunCheck = dcGubunCheck;
			this._confirmCheck = confirmCheck;
			this._reserYnCheck = reserYnCheck;
			this._chisikYn = chisikYn;
			this._ndayYn = ndayYn;
			this._defaultJaeryoJundalYn = defaultJaeryoJundalYn;
			this._defaultWonyoiYn = defaultWonyoiYn;
			this._specificComment = specificComment;
			this._specificCommentName = specificCommentName;
			this._specificCommentSysId = specificCommentSysId;
			this._specificCommentPgmId = specificCommentPgmId;
			this._specificCommentNotNull = specificCommentNotNull;
			this._specificCommentTableId = specificCommentTableId;
			this._specificCommentColId = specificCommentColId;
			this._donbogYn = donbogYn;
			this._orderGubunBasName = orderGubunBasName;
			this._actDoctor = actDoctor;
			this._actBuseo = actBuseo;
			this._actGwa = actGwa;
			this._homeCareYn = homeCareYn;
			this._regularYn = regularYn;
			this._sortFkocskey = sortFkocskey;
			this._childYn = childYn;
			this._ifInputControl = ifInputControl;
			this._slipName = slipName;
			this._orgKey = orgKey;
			this._parentKey = parentKey;
			this._bunCode = bunCode;
			this._dv5 = dv5;
			this._dv6 = dv6;
			this._dv7 = dv7;
			this._dv8 = dv8;
			this._wonnaeDrgYn = wonnaeDrgYn;
			this._hubalChangeCheck = hubalChangeCheck;
			this._drgPackCheck = drgPackCheck;
			this._pharmacyCheck = pharmacyCheck;
			this._powerCheck = powerCheck;
			this._imsiDrugYn = imsiDrugYn;
			this._orderByKey = orderByKey;
		}

	}
}