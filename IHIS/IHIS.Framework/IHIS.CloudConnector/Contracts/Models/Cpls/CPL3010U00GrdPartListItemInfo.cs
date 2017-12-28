using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL3010U00GrdPartListItemInfo
	{
		private String _labNo;
		private String _specimenSer;
		private String _bunho;
		private String _suname2;
		private String _fnBasLoadGwaName;
		private String _hoDong;
		private String _partJubsuDate;
		private String _partJubsuTime;
		private String _partJubsuja;
		private String _jubsuja;
		private String _remark;
		private String _partJubsuFlag;
		private String _fkocs;
		private String _inOutGubun;
		private String _doctorName;
		private String _tubeName;
		private String _emergency;
		private String _sunabYn;
		private String _resultYn;
		private String _labelOneMore;
		private String _dataRowState;

		public String LabNo
		{
			get { return this._labNo; }
			set { this._labNo = value; }
		}

		public String SpecimenSer
		{
			get { return this._specimenSer; }
			set { this._specimenSer = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Suname2
		{
			get { return this._suname2; }
			set { this._suname2 = value; }
		}

		public String FnBasLoadGwaName
		{
			get { return this._fnBasLoadGwaName; }
			set { this._fnBasLoadGwaName = value; }
		}

		public String HoDong
		{
			get { return this._hoDong; }
			set { this._hoDong = value; }
		}

		public String PartJubsuDate
		{
			get { return this._partJubsuDate; }
			set { this._partJubsuDate = value; }
		}

		public String PartJubsuTime
		{
			get { return this._partJubsuTime; }
			set { this._partJubsuTime = value; }
		}

		public String PartJubsuja
		{
			get { return this._partJubsuja; }
			set { this._partJubsuja = value; }
		}

		public String Jubsuja
		{
			get { return this._jubsuja; }
			set { this._jubsuja = value; }
		}

		public String Remark
		{
			get { return this._remark; }
			set { this._remark = value; }
		}

		public String PartJubsuFlag
		{
			get { return this._partJubsuFlag; }
			set { this._partJubsuFlag = value; }
		}

		public String Fkocs
		{
			get { return this._fkocs; }
			set { this._fkocs = value; }
		}

		public String InOutGubun
		{
			get { return this._inOutGubun; }
			set { this._inOutGubun = value; }
		}

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public String TubeName
		{
			get { return this._tubeName; }
			set { this._tubeName = value; }
		}

		public String Emergency
		{
			get { return this._emergency; }
			set { this._emergency = value; }
		}

		public String SunabYn
		{
			get { return this._sunabYn; }
			set { this._sunabYn = value; }
		}

		public String ResultYn
		{
			get { return this._resultYn; }
			set { this._resultYn = value; }
		}

		public String LabelOneMore
		{
			get { return this._labelOneMore; }
			set { this._labelOneMore = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public CPL3010U00GrdPartListItemInfo() { }

		public CPL3010U00GrdPartListItemInfo(String labNo, String specimenSer, String bunho, String suname2, String fnBasLoadGwaName, String hoDong, String partJubsuDate, String partJubsuTime, String partJubsuja, String jubsuja, String remark, String partJubsuFlag, String fkocs, String inOutGubun, String doctorName, String tubeName, String emergency, String sunabYn, String resultYn, String labelOneMore, String dataRowState)
		{
			this._labNo = labNo;
			this._specimenSer = specimenSer;
			this._bunho = bunho;
			this._suname2 = suname2;
			this._fnBasLoadGwaName = fnBasLoadGwaName;
			this._hoDong = hoDong;
			this._partJubsuDate = partJubsuDate;
			this._partJubsuTime = partJubsuTime;
			this._partJubsuja = partJubsuja;
			this._jubsuja = jubsuja;
			this._remark = remark;
			this._partJubsuFlag = partJubsuFlag;
			this._fkocs = fkocs;
			this._inOutGubun = inOutGubun;
			this._doctorName = doctorName;
			this._tubeName = tubeName;
			this._emergency = emergency;
			this._sunabYn = sunabYn;
			this._resultYn = resultYn;
			this._labelOneMore = labelOneMore;
			this._dataRowState = dataRowState;
		}

	}
}