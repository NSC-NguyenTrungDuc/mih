using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
	public class OCS1003P01LayDeletedDataListItemInfo
	{
		private String _sourceOrdKey;
		private String _pkocskey;

		public String SourceOrdKey
		{
			get { return this._sourceOrdKey; }
			set { this._sourceOrdKey = value; }
		}

		public String Pkocskey
		{
			get { return this._pkocskey; }
			set { this._pkocskey = value; }
		}

		public OCS1003P01LayDeletedDataListItemInfo() { }

		public OCS1003P01LayDeletedDataListItemInfo(String sourceOrdKey, String pkocskey)
		{
			this._sourceOrdKey = sourceOrdKey;
			this._pkocskey = pkocskey;
		}

	}
}