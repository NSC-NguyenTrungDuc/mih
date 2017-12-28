using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
	public class XRT0000Q00LayMakeTabPageListItemInfo
	{
		private String _code;
		private String _codeName;
		private String _seq;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String CodeName
		{
			get { return this._codeName; }
			set { this._codeName = value; }
		}

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
		}

		public XRT0000Q00LayMakeTabPageListItemInfo() { }

		public XRT0000Q00LayMakeTabPageListItemInfo(String code, String codeName, String seq)
		{
			this._code = code;
			this._codeName = codeName;
			this._seq = seq;
		}

	}
}