using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DRG9040U01GrdOrderInfo
	{
		private String _jubsuDate;
		private String _drgBunho;
		private String _bunho;
		private String _orderDate;
		private String _doctor;
		private String _doctorName;
		private String _gwa;
		private String _buseoName;
		private String _orderRemark;
		private String _drgRemark;
		private String _magamGubun;
		private String _bunryu1;
		private String _dataRowState;

		public String JubsuDate
		{
			get { return this._jubsuDate; }
			set { this._jubsuDate = value; }
		}

		public String DrgBunho
		{
			get { return this._drgBunho; }
			set { this._drgBunho = value; }
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

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String BuseoName
		{
			get { return this._buseoName; }
			set { this._buseoName = value; }
		}

		public String OrderRemark
		{
			get { return this._orderRemark; }
			set { this._orderRemark = value; }
		}

		public String DrgRemark
		{
			get { return this._drgRemark; }
			set { this._drgRemark = value; }
		}

		public String MagamGubun
		{
			get { return this._magamGubun; }
			set { this._magamGubun = value; }
		}

		public String Bunryu1
		{
			get { return this._bunryu1; }
			set { this._bunryu1 = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public DRG9040U01GrdOrderInfo() { }

		public DRG9040U01GrdOrderInfo(String jubsuDate, String drgBunho, String bunho, String orderDate, String doctor, String doctorName, String gwa, String buseoName, String orderRemark, String drgRemark, String magamGubun, String bunryu1, String dataRowState)
		{
			this._jubsuDate = jubsuDate;
			this._drgBunho = drgBunho;
			this._bunho = bunho;
			this._orderDate = orderDate;
			this._doctor = doctor;
			this._doctorName = doctorName;
			this._gwa = gwa;
			this._buseoName = buseoName;
			this._orderRemark = orderRemark;
			this._drgRemark = drgRemark;
			this._magamGubun = magamGubun;
			this._bunryu1 = bunryu1;
			this._dataRowState = dataRowState;
		}

	}
}