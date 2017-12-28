using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
	public class XRT0201U00GrdJaeryoItemInfo
	{
		private String _jaeryoCode;
		private String _jaeryoName;
		private String _suryang;
		private String _ordDanui;
		private String _pkinv1001;
		private String _bunho;
		private String _orderDate;
		private String _inOutGubun;
		private String _actingDate;
		private String _actingBuseo;
		private String _fkocsInv;
		private String _fkocsXrt;
		private String _danuiName;
		private String _bunryu2;
		private String _jaeryoGubun;
		private String _jaeryoYn;
		private String _inputControl;
		private String _bunCode;
		private String _nalsu;
		private String _dataRowState;

		public String JaeryoCode
		{
			get { return this._jaeryoCode; }
			set { this._jaeryoCode = value; }
		}

		public String JaeryoName
		{
			get { return this._jaeryoName; }
			set { this._jaeryoName = value; }
		}

		public String Suryang
		{
			get { return this._suryang; }
			set { this._suryang = value; }
		}

		public String OrdDanui
		{
			get { return this._ordDanui; }
			set { this._ordDanui = value; }
		}

		public String Pkinv1001
		{
			get { return this._pkinv1001; }
			set { this._pkinv1001 = value; }
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

		public String InOutGubun
		{
			get { return this._inOutGubun; }
			set { this._inOutGubun = value; }
		}

		public String ActingDate
		{
			get { return this._actingDate; }
			set { this._actingDate = value; }
		}

		public String ActingBuseo
		{
			get { return this._actingBuseo; }
			set { this._actingBuseo = value; }
		}

		public String FkocsInv
		{
			get { return this._fkocsInv; }
			set { this._fkocsInv = value; }
		}

		public String FkocsXrt
		{
			get { return this._fkocsXrt; }
			set { this._fkocsXrt = value; }
		}

		public String DanuiName
		{
			get { return this._danuiName; }
			set { this._danuiName = value; }
		}

		public String Bunryu2
		{
			get { return this._bunryu2; }
			set { this._bunryu2 = value; }
		}

		public String JaeryoGubun
		{
			get { return this._jaeryoGubun; }
			set { this._jaeryoGubun = value; }
		}

		public String JaeryoYn
		{
			get { return this._jaeryoYn; }
			set { this._jaeryoYn = value; }
		}

		public String InputControl
		{
			get { return this._inputControl; }
			set { this._inputControl = value; }
		}

		public String BunCode
		{
			get { return this._bunCode; }
			set { this._bunCode = value; }
		}

		public String Nalsu
		{
			get { return this._nalsu; }
			set { this._nalsu = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public XRT0201U00GrdJaeryoItemInfo() { }

		public XRT0201U00GrdJaeryoItemInfo(String jaeryoCode, String jaeryoName, String suryang, String ordDanui, String pkinv1001, String bunho, String orderDate, String inOutGubun, String actingDate, String actingBuseo, String fkocsInv, String fkocsXrt, String danuiName, String bunryu2, String jaeryoGubun, String jaeryoYn, String inputControl, String bunCode, String nalsu, String dataRowState)
		{
			this._jaeryoCode = jaeryoCode;
			this._jaeryoName = jaeryoName;
			this._suryang = suryang;
			this._ordDanui = ordDanui;
			this._pkinv1001 = pkinv1001;
			this._bunho = bunho;
			this._orderDate = orderDate;
			this._inOutGubun = inOutGubun;
			this._actingDate = actingDate;
			this._actingBuseo = actingBuseo;
			this._fkocsInv = fkocsInv;
			this._fkocsXrt = fkocsXrt;
			this._danuiName = danuiName;
			this._bunryu2 = bunryu2;
			this._jaeryoGubun = jaeryoGubun;
			this._jaeryoYn = jaeryoYn;
			this._inputControl = inputControl;
			this._bunCode = bunCode;
			this._nalsu = nalsu;
			this._dataRowState = dataRowState;
		}

	}
}