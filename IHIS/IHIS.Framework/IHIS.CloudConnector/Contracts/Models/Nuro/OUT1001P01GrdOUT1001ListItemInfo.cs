using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class OUT1001P01GrdOUT1001ListItemInfo
	{
		private String _pkout1001;
		private String _bunho;
		private String _gwa;
		private String _gwaName;
		private String _doctor;
		private String _doctorName;
		private String _jubsuNo;

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
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

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public String JubsuNo
		{
			get { return this._jubsuNo; }
			set { this._jubsuNo = value; }
		}

		public OUT1001P01GrdOUT1001ListItemInfo() { }

		public OUT1001P01GrdOUT1001ListItemInfo(String pkout1001, String bunho, String gwa, String gwaName, String doctor, String doctorName, String jubsuNo)
		{
			this._pkout1001 = pkout1001;
			this._bunho = bunho;
			this._gwa = gwa;
			this._gwaName = gwaName;
			this._doctor = doctor;
			this._doctorName = doctorName;
			this._jubsuNo = jubsuNo;
		}

	}
}