using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
	public class OcsEmrPatientReceptionHistoryListItemInfo
	{
		private String _comingDate;
		private String _examDate;
		private String _examTime;
		private String _departmentCode;
		private String _doctor;
		private String _insurType;
		private String _sunnabStatus;
		private String _examStatus;
		private String _comingStatus;
		private String _patientCode;
		private String _receptionTime;
		private String _departmentName;
		private String _sujinNo;
		private String _dokuStatus;
		private String _contKey;
		private String _pkout1001;
		private List<OCS2015U03OrderGubunInfo> _orderGubun = new List<OCS2015U03OrderGubunInfo>();

		public String ComingDate
		{
			get { return this._comingDate; }
			set { this._comingDate = value; }
		}

		public String ExamDate
		{
			get { return this._examDate; }
			set { this._examDate = value; }
		}

		public String ExamTime
		{
			get { return this._examTime; }
			set { this._examTime = value; }
		}

		public String DepartmentCode
		{
			get { return this._departmentCode; }
			set { this._departmentCode = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String InsurType
		{
			get { return this._insurType; }
			set { this._insurType = value; }
		}

		public String SunnabStatus
		{
			get { return this._sunnabStatus; }
			set { this._sunnabStatus = value; }
		}

		public String ExamStatus
		{
			get { return this._examStatus; }
			set { this._examStatus = value; }
		}

		public String ComingStatus
		{
			get { return this._comingStatus; }
			set { this._comingStatus = value; }
		}

		public String PatientCode
		{
			get { return this._patientCode; }
			set { this._patientCode = value; }
		}

		public String ReceptionTime
		{
			get { return this._receptionTime; }
			set { this._receptionTime = value; }
		}

		public String DepartmentName
		{
			get { return this._departmentName; }
			set { this._departmentName = value; }
		}

		public String SujinNo
		{
			get { return this._sujinNo; }
			set { this._sujinNo = value; }
		}

		public String DokuStatus
		{
			get { return this._dokuStatus; }
			set { this._dokuStatus = value; }
		}

		public String ContKey
		{
			get { return this._contKey; }
			set { this._contKey = value; }
		}

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public List<OCS2015U03OrderGubunInfo> OrderGubun
		{
			get { return this._orderGubun; }
			set { this._orderGubun = value; }
		}

		public OcsEmrPatientReceptionHistoryListItemInfo() { }

		public OcsEmrPatientReceptionHistoryListItemInfo(String comingDate, String examDate, String examTime, String departmentCode, String doctor, String insurType, String sunnabStatus, String examStatus, String comingStatus, String patientCode, String receptionTime, String departmentName, String sujinNo, String dokuStatus, String contKey, String pkout1001, List<OCS2015U03OrderGubunInfo> orderGubun)
		{
			this._comingDate = comingDate;
			this._examDate = examDate;
			this._examTime = examTime;
			this._departmentCode = departmentCode;
			this._doctor = doctor;
			this._insurType = insurType;
			this._sunnabStatus = sunnabStatus;
			this._examStatus = examStatus;
			this._comingStatus = comingStatus;
			this._patientCode = patientCode;
			this._receptionTime = receptionTime;
			this._departmentName = departmentName;
			this._sujinNo = sujinNo;
			this._dokuStatus = dokuStatus;
			this._contKey = contKey;
			this._pkout1001 = pkout1001;
			this._orderGubun = orderGubun;
		}

	}
}