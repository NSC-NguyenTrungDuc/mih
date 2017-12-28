using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
	public class XRT0201U00GrdJaeryoColumnChangedItemInfo
	{
		private String _hangmogName;
		private String _suryang;
		private String _danui;
		private String _danuiName;

		public String HangmogName
		{
			get { return this._hangmogName; }
			set { this._hangmogName = value; }
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

		public XRT0201U00GrdJaeryoColumnChangedItemInfo() { }

		public XRT0201U00GrdJaeryoColumnChangedItemInfo(String hangmogName, String suryang, String danui, String danuiName)
		{
			this._hangmogName = hangmogName;
			this._suryang = suryang;
			this._danui = danui;
			this._danuiName = danuiName;
		}

	}
}