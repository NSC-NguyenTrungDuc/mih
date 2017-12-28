using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01LayBongtuInfo
	{
		private String _fkocs1003;
		private String _jubsuDateWareki;
		private String _actDateWareki;
		private String _donbokYn;
		private String _pattern;

		public String Fkocs1003
		{
			get { return this._fkocs1003; }
			set { this._fkocs1003 = value; }
		}

		public String JubsuDateWareki
		{
			get { return this._jubsuDateWareki; }
			set { this._jubsuDateWareki = value; }
		}

		public String ActDateWareki
		{
			get { return this._actDateWareki; }
			set { this._actDateWareki = value; }
		}

		public String DonbokYn
		{
			get { return this._donbokYn; }
			set { this._donbokYn = value; }
		}

		public String Pattern
		{
			get { return this._pattern; }
			set { this._pattern = value; }
		}

		public DrgsDRG5100P01LayBongtuInfo() { }

		public DrgsDRG5100P01LayBongtuInfo(String fkocs1003, String jubsuDateWareki, String actDateWareki, String donbokYn, String pattern)
		{
			this._fkocs1003 = fkocs1003;
			this._jubsuDateWareki = jubsuDateWareki;
			this._actDateWareki = actDateWareki;
			this._donbokYn = donbokYn;
			this._pattern = pattern;
		}

	}
}