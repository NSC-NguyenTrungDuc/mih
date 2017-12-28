using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0108U00grdOCS0108ItemInfo
	{
		private String _hangmogCode;
		private String _seq;
		private String _ordDanui;
		private String _changeQty1;
		private String _changeQty2;
		private String _sunabDanui;
		private String _subulDanui;
		private String _hangmogStartDate;
		private String _dataRowState;

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
		}

		public String OrdDanui
		{
			get { return this._ordDanui; }
			set { this._ordDanui = value; }
		}

		public String ChangeQty1
		{
			get { return this._changeQty1; }
			set { this._changeQty1 = value; }
		}

		public String ChangeQty2
		{
			get { return this._changeQty2; }
			set { this._changeQty2 = value; }
		}

		public String SunabDanui
		{
			get { return this._sunabDanui; }
			set { this._sunabDanui = value; }
		}

		public String SubulDanui
		{
			get { return this._subulDanui; }
			set { this._subulDanui = value; }
		}

		public String HangmogStartDate
		{
			get { return this._hangmogStartDate; }
			set { this._hangmogStartDate = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public OCS0108U00grdOCS0108ItemInfo() { }

		public OCS0108U00grdOCS0108ItemInfo(String hangmogCode, String seq, String ordDanui, String changeQty1, String changeQty2, String sunabDanui, String subulDanui, String hangmogStartDate, String dataRowState)
		{
			this._hangmogCode = hangmogCode;
			this._seq = seq;
			this._ordDanui = ordDanui;
			this._changeQty1 = changeQty1;
			this._changeQty2 = changeQty2;
			this._sunabDanui = sunabDanui;
			this._subulDanui = subulDanui;
			this._hangmogStartDate = hangmogStartDate;
			this._dataRowState = dataRowState;
		}

	}
}