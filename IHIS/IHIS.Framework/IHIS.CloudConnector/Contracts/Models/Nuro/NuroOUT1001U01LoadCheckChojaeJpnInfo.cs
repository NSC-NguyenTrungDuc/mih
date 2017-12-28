using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class NuroOUT1001U01LoadCheckChojaeJpnInfo
	{
		private String _chojae;
		private String _chtChojae;
		private String _gajubsuGubun;
		private String _err;

		public String Chojae
		{
			get { return this._chojae; }
			set { this._chojae = value; }
		}

		public String ChtChojae
		{
			get { return this._chtChojae; }
			set { this._chtChojae = value; }
		}

		public String GajubsuGubun
		{
			get { return this._gajubsuGubun; }
			set { this._gajubsuGubun = value; }
		}

		public String Err
		{
			get { return this._err; }
			set { this._err = value; }
		}

		public NuroOUT1001U01LoadCheckChojaeJpnInfo() { }

		public NuroOUT1001U01LoadCheckChojaeJpnInfo(String chojae, String chtChojae, String gajubsuGubun, String err)
		{
			this._chojae = chojae;
			this._chtChojae = chtChojae;
			this._gajubsuGubun = gajubsuGubun;
			this._err = err;
		}

	}
}