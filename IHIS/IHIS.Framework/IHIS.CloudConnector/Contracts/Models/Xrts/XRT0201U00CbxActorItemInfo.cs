using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
	public class XRT0201U00CbxActorItemInfo
	{
		private String _userId;
		private String _userName;

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String UserName
		{
			get { return this._userName; }
			set { this._userName = value; }
		}

		public XRT0201U00CbxActorItemInfo() { }

		public XRT0201U00CbxActorItemInfo(String userId, String userName)
		{
			this._userId = userId;
			this._userName = userName;
		}

	}
}