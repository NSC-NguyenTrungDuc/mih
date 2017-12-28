using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
	public class ADM501UListItemInfo
	{
		private String _adm0002Pk;
		private String _msgGubun;
		private String _koreaMsg;
		private String _japanMsg;
		private String _speakMsg;
		private String _dataRowState;

		public String Adm0002Pk
		{
			get { return this._adm0002Pk; }
			set { this._adm0002Pk = value; }
		}

		public String MsgGubun
		{
			get { return this._msgGubun; }
			set { this._msgGubun = value; }
		}

		public String KoreaMsg
		{
			get { return this._koreaMsg; }
			set { this._koreaMsg = value; }
		}

		public String JapanMsg
		{
			get { return this._japanMsg; }
			set { this._japanMsg = value; }
		}

		public String SpeakMsg
		{
			get { return this._speakMsg; }
			set { this._speakMsg = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public ADM501UListItemInfo() { }

		public ADM501UListItemInfo(String adm0002Pk, String msgGubun, String koreaMsg, String japanMsg, String speakMsg, String dataRowState)
		{
			this._adm0002Pk = adm0002Pk;
			this._msgGubun = msgGubun;
			this._koreaMsg = koreaMsg;
			this._japanMsg = japanMsg;
			this._speakMsg = speakMsg;
			this._dataRowState = dataRowState;
		}

	}
}