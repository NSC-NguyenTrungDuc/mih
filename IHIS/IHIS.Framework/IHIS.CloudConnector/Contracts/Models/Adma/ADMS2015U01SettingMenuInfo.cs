using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
	public class ADMS2015U01SettingMenuInfo
	{
		private String _trId;
		private String _selectFlg;

		public String TrId
		{
			get { return this._trId; }
			set { this._trId = value; }
		}

		public String SelectFlg
		{
			get { return this._selectFlg; }
			set { this._selectFlg = value; }
		}

		public ADMS2015U01SettingMenuInfo() { }

		public ADMS2015U01SettingMenuInfo(String trId, String selectFlg)
		{
			this._trId = trId;
			this._selectFlg = selectFlg;
		}

	}
}