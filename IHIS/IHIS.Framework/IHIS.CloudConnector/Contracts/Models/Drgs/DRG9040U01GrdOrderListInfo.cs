using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DRG9040U01GrdOrderListInfo
	{
		private String _orderDate;
		private String _groupSer;
		private String _jaeryoCode;
		private String _jaeryoName;
		private String _ordSuryang;
		private String _dvTime;
		private String _dv;
		private String _nalsu;
		private String _orderDanui;
		private String _danuiName;
		private String _bogyongCode;
		private String _bogyongName;
		private String _powderYn;
		private String _remark;
		private String _dv1;
		private String _dv2;
		private String _dv3;
		private String _dv4;
		private String _dv5;
		private String _hubalChangeYn;
		private String _pharmacy;
		private String _drgPackYn;
		private String _jusa;
		private String _suname;
		private String _orderRemark;
		private String _drgRemark;
		private String _drgBunho;
		private String _jubsuDate;
		private String _bunho;
		private String _fkocs2003;
		private String _dataRowState;

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public String GroupSer
		{
			get { return this._groupSer; }
			set { this._groupSer = value; }
		}

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

		public String OrdSuryang
		{
			get { return this._ordSuryang; }
			set { this._ordSuryang = value; }
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

		public String Nalsu
		{
			get { return this._nalsu; }
			set { this._nalsu = value; }
		}

		public String OrderDanui
		{
			get { return this._orderDanui; }
			set { this._orderDanui = value; }
		}

		public String DanuiName
		{
			get { return this._danuiName; }
			set { this._danuiName = value; }
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

		public String PowderYn
		{
			get { return this._powderYn; }
			set { this._powderYn = value; }
		}

		public String Remark
		{
			get { return this._remark; }
			set { this._remark = value; }
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

		public String Dv5
		{
			get { return this._dv5; }
			set { this._dv5 = value; }
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

		public String Jusa
		{
			get { return this._jusa; }
			set { this._jusa = value; }
		}

		public String Suname
		{
			get { return this._suname; }
			set { this._suname = value; }
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

		public String DrgBunho
		{
			get { return this._drgBunho; }
			set { this._drgBunho = value; }
		}

		public String JubsuDate
		{
			get { return this._jubsuDate; }
			set { this._jubsuDate = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Fkocs2003
		{
			get { return this._fkocs2003; }
			set { this._fkocs2003 = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public DRG9040U01GrdOrderListInfo() { }

		public DRG9040U01GrdOrderListInfo(String orderDate, String groupSer, String jaeryoCode, String jaeryoName, String ordSuryang, String dvTime, String dv, String nalsu, String orderDanui, String danuiName, String bogyongCode, String bogyongName, String powderYn, String remark, String dv1, String dv2, String dv3, String dv4, String dv5, String hubalChangeYn, String pharmacy, String drgPackYn, String jusa, String suname, String orderRemark, String drgRemark, String drgBunho, String jubsuDate, String bunho, String fkocs2003, String dataRowState)
		{
			this._orderDate = orderDate;
			this._groupSer = groupSer;
			this._jaeryoCode = jaeryoCode;
			this._jaeryoName = jaeryoName;
			this._ordSuryang = ordSuryang;
			this._dvTime = dvTime;
			this._dv = dv;
			this._nalsu = nalsu;
			this._orderDanui = orderDanui;
			this._danuiName = danuiName;
			this._bogyongCode = bogyongCode;
			this._bogyongName = bogyongName;
			this._powderYn = powderYn;
			this._remark = remark;
			this._dv1 = dv1;
			this._dv2 = dv2;
			this._dv3 = dv3;
			this._dv4 = dv4;
			this._dv5 = dv5;
			this._hubalChangeYn = hubalChangeYn;
			this._pharmacy = pharmacy;
			this._drgPackYn = drgPackYn;
			this._jusa = jusa;
			this._suname = suname;
			this._orderRemark = orderRemark;
			this._drgRemark = drgRemark;
			this._drgBunho = drgBunho;
			this._jubsuDate = jubsuDate;
			this._bunho = bunho;
			this._fkocs2003 = fkocs2003;
			this._dataRowState = dataRowState;
		}

	}
}