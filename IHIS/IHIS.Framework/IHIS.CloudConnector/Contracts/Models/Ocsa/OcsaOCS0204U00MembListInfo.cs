using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OcsaOCS0204U00MembListInfo
	{
		private String _userId;
		private String _userNm;

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String UserNm
		{
			get { return this._userNm; }
			set { this._userNm = value; }
		}

		public OcsaOCS0204U00MembListInfo() { }

		public OcsaOCS0204U00MembListInfo(String userId, String userNm)
		{
			this._userId = userId;
			this._userNm = userNm;
		}

	}
}