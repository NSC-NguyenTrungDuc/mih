using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U18InitializeScreenResult : AbstractContractResult
	{
		private String _name;
		private String _mainDoctorCode;
		private List<OCS0103U17LayHangwiGubunInfo> _layHangwiGubunInfo = new List<OCS0103U17LayHangwiGubunInfo>();
		private List<OCS0103U18MakeJaeryoGubunTabListItemInfo> _makeJaeryoGubunInfo = new List<OCS0103U18MakeJaeryoGubunTabListItemInfo>();

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

		public List<OCS0103U17LayHangwiGubunInfo> LayHangwiGubunInfo
		{
			get { return this._layHangwiGubunInfo; }
			set { this._layHangwiGubunInfo = value; }
		}

		public List<OCS0103U18MakeJaeryoGubunTabListItemInfo> MakeJaeryoGubunInfo
		{
			get { return this._makeJaeryoGubunInfo; }
			set { this._makeJaeryoGubunInfo = value; }
		}

		public OCS0103U18InitializeScreenResult() { }

	}
}