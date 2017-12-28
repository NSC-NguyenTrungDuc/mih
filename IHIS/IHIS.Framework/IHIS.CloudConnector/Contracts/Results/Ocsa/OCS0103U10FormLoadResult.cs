using System;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U10FormLoadResult : AbstractContractResult
	{
		private String _generalDispYn;
		private String _sentouSearchYn;
		private String _checkDrgTime;
		private String _broughtDrgYn;
		private String _name;
		private String _mainDoctorCode;
		private List<LoadOftenUsedTabResponseInfo> _usedTabResponseInfo = new List<LoadOftenUsedTabResponseInfo>();

		public String GeneralDispYn
		{
			get { return this._generalDispYn; }
			set { this._generalDispYn = value; }
		}

		public String SentouSearchYn
		{
			get { return this._sentouSearchYn; }
			set { this._sentouSearchYn = value; }
		}

		public String CheckDrgTime
		{
			get { return this._checkDrgTime; }
			set { this._checkDrgTime = value; }
		}

		public String BroughtDrgYn
		{
			get { return this._broughtDrgYn; }
			set { this._broughtDrgYn = value; }
		}

		public String Name
		{
			get { return this._name; }
			set { this._name = value; }
		}

		public String MainDoctorCode
		{
			get { return this._mainDoctorCode; }
			set { this._mainDoctorCode = value; }
		}

		public List<LoadOftenUsedTabResponseInfo> UsedTabResponseInfo
		{
			get { return this._usedTabResponseInfo; }
			set { this._usedTabResponseInfo = value; }
		}

		public OCS0103U10FormLoadResult() { }

	}
}