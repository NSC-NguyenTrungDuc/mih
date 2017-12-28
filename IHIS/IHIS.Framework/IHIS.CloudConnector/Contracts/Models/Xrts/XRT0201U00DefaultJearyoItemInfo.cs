using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
	public class XRT0201U00DefaultJearyoItemInfo
	{
		private String _setHangmogCode;
		private String _suryang;
		private String _danui;
		private String _danuiName;

		public String SetHangmogCode
		{
			get { return this._setHangmogCode; }
			set { this._setHangmogCode = value; }
		}

		public String Suryang
		{
			get { return this._suryang; }
			set { this._suryang = value; }
		}

		public String Danui
		{
			get { return this._danui; }
			set { this._danui = value; }
		}

		public String DanuiName
		{
			get { return this._danuiName; }
			set { this._danuiName = value; }
		}

		public XRT0201U00DefaultJearyoItemInfo() { }

		public XRT0201U00DefaultJearyoItemInfo(String setHangmogCode, String suryang, String danui, String danuiName)
		{
			this._setHangmogCode = setHangmogCode;
			this._suryang = suryang;
			this._danui = danui;
			this._danuiName = danuiName;
		}

	}
}