using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCSAPPROVEGrdPatientListInfo
	{
		private String _naewonDate;
		private String _gwa;
		private String _gwaName;
		private String _doctorName;
		private String _nalsu;
		private String _bunho;
		private String _doctor;
		private String _gubunName;
		private String _chojaeName;
		private String _naewonType;
		private String _jubsuNo;
		private String _pkOrder;
		private String _inputGubun;
		private String _toiwonDrg;
		private String _inputTab;
		private String _ioGubun;
		private String _patientName;
		private String _selectYn;

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public String Nalsu
		{
			get { return this._nalsu; }
			set { this._nalsu = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String GubunName
		{
			get { return this._gubunName; }
			set { this._gubunName = value; }
		}

		public String ChojaeName
		{
			get { return this._chojaeName; }
			set { this._chojaeName = value; }
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

		public String PkOrder
		{
			get { return this._pkOrder; }
			set { this._pkOrder = value; }
		}

		public String InputGubun
		{
			get { return this._inputGubun; }
			set { this._inputGubun = value; }
		}

		public String ToiwonDrg
		{
			get { return this._toiwonDrg; }
			set { this._toiwonDrg = value; }
		}

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String PatientName
		{
			get { return this._patientName; }
			set { this._patientName = value; }
		}

		public String SelectYn
		{
			get { return this._selectYn; }
			set { this._selectYn = value; }
		}

		public OCSAPPROVEGrdPatientListInfo() { }

		public OCSAPPROVEGrdPatientListInfo(String naewonDate, String gwa, String gwaName, String doctorName, String nalsu, String bunho, String doctor, String gubunName, String chojaeName, String naewonType, String jubsuNo, String pkOrder, String inputGubun, String toiwonDrg, String inputTab, String ioGubun, String patientName, String selectYn)
		{
			this._naewonDate = naewonDate;
			this._gwa = gwa;
			this._gwaName = gwaName;
			this._doctorName = doctorName;
			this._nalsu = nalsu;
			this._bunho = bunho;
			this._doctor = doctor;
			this._gubunName = gubunName;
			this._chojaeName = chojaeName;
			this._naewonType = naewonType;
			this._jubsuNo = jubsuNo;
			this._pkOrder = pkOrder;
			this._inputGubun = inputGubun;
			this._toiwonDrg = toiwonDrg;
			this._inputTab = inputTab;
			this._ioGubun = ioGubun;
			this._patientName = patientName;
			this._selectYn = selectYn;
		}

	}
}