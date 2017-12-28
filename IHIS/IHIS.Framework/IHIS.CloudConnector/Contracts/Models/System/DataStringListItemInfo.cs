using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
	public class DataStringListItemInfo
	{
		private String _dataValue;

		public String DataValue
		{
			get { return this._dataValue; }
			set { this._dataValue = value; }
		}

		public DataStringListItemInfo() { }

		public DataStringListItemInfo(String dataValue)
		{
			this._dataValue = dataValue;
		}

	}
}