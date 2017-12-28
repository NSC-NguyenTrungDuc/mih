using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OcsaOCS0304U00GrdOCS0306ListInfo
	{
		private String _memb;
		private String _yaksokDirectCode;
		private String _directGubun;
		private String _directCode;
		private String _directDetail;
		private String _pkSeq;
		private String _seq;
		private String _hangmogCode;
		private String _suryang;
		private String _nalsu;
		private String _ordDanui;
		private String _bogyongCode;
		private String _jusaCode;
		private String _jusaSpdGubun;
		private String _dv;
		private String _dvTime;
		private String _insulinFrom;
		private String _insulinTo;
		private String _timeGubun;
		private String _bomSourceKey;
		private String _bomYn;
		private String _rowState;

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String YaksokDirectCode
		{
			get { return this._yaksokDirectCode; }
			set { this._yaksokDirectCode = value; }
		}

		public String DirectGubun
		{
			get { return this._directGubun; }
			set { this._directGubun = value; }
		}

		public String DirectCode
		{
			get { return this._directCode; }
			set { this._directCode = value; }
		}

		public String DirectDetail
		{
			get { return this._directDetail; }
			set { this._directDetail = value; }
		}

		public String PkSeq
		{
			get { return this._pkSeq; }
			set { this._pkSeq = value; }
		}

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String Suryang
		{
			get { return this._suryang; }
			set { this._suryang = value; }
		}

		public String Nalsu
		{
			get { return this._nalsu; }
			set { this._nalsu = value; }
		}

		public String OrdDanui
		{
			get { return this._ordDanui; }
			set { this._ordDanui = value; }
		}

		public String BogyongCode
		{
			get { return this._bogyongCode; }
			set { this._bogyongCode = value; }
		}

		public String JusaCode
		{
			get { return this._jusaCode; }
			set { this._jusaCode = value; }
		}

		public String JusaSpdGubun
		{
			get { return this._jusaSpdGubun; }
			set { this._jusaSpdGubun = value; }
		}

		public String Dv
		{
			get { return this._dv; }
			set { this._dv = value; }
		}

		public String DvTime
		{
			get { return this._dvTime; }
			set { this._dvTime = value; }
		}

		public String InsulinFrom
		{
			get { return this._insulinFrom; }
			set { this._insulinFrom = value; }
		}

		public String InsulinTo
		{
			get { return this._insulinTo; }
			set { this._insulinTo = value; }
		}

		public String TimeGubun
		{
			get { return this._timeGubun; }
			set { this._timeGubun = value; }
		}

		public String BomSourceKey
		{
			get { return this._bomSourceKey; }
			set { this._bomSourceKey = value; }
		}

		public String BomYn
		{
			get { return this._bomYn; }
			set { this._bomYn = value; }
		}

		public String RowState
		{
			get { return this._rowState; }
			set { this._rowState = value; }
		}

		public OcsaOCS0304U00GrdOCS0306ListInfo() { }

		public OcsaOCS0304U00GrdOCS0306ListInfo(String memb, String yaksokDirectCode, String directGubun, String directCode, String directDetail, String pkSeq, String seq, String hangmogCode, String suryang, String nalsu, String ordDanui, String bogyongCode, String jusaCode, String jusaSpdGubun, String dv, String dvTime, String insulinFrom, String insulinTo, String timeGubun, String bomSourceKey, String bomYn, String rowState)
		{
			this._memb = memb;
			this._yaksokDirectCode = yaksokDirectCode;
			this._directGubun = directGubun;
			this._directCode = directCode;
			this._directDetail = directDetail;
			this._pkSeq = pkSeq;
			this._seq = seq;
			this._hangmogCode = hangmogCode;
			this._suryang = suryang;
			this._nalsu = nalsu;
			this._ordDanui = ordDanui;
			this._bogyongCode = bogyongCode;
			this._jusaCode = jusaCode;
			this._jusaSpdGubun = jusaSpdGubun;
			this._dv = dv;
			this._dvTime = dvTime;
			this._insulinFrom = insulinFrom;
			this._insulinTo = insulinTo;
			this._timeGubun = timeGubun;
			this._bomSourceKey = bomSourceKey;
			this._bomYn = bomYn;
			this._rowState = rowState;
		}

	}
}