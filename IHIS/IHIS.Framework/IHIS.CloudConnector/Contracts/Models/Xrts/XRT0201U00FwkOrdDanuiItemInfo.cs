using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
	public class XRT0201U00FwkOrdDanuiItemInfo
	{
		private String _ordDanui;
		private String _ordDanuiName;
		private String _seq;

		public String OrdDanui
		{
			get { return this._ordDanui; }
			set { this._ordDanui = value; }
		}

		public String OrdDanuiName
		{
			get { return this._ordDanuiName; }
			set { this._ordDanuiName = value; }
		}

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
		}

		public XRT0201U00FwkOrdDanuiItemInfo() { }

		public XRT0201U00FwkOrdDanuiItemInfo(String ordDanui, String ordDanuiName, String seq)
		{
			this._ordDanui = ordDanui;
			this._ordDanuiName = ordDanuiName;
			this._seq = seq;
		}

	}
}