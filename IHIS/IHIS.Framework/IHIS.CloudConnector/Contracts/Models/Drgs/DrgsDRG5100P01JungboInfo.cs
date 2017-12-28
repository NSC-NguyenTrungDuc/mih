using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01JungboInfo
	{
		private String _height;
		private String _cm;
		private String _weight;
		private String _kg;
		private String _cplResult;
		private String _comments;
		private String _cnt;

		public String Height
		{
			get { return this._height; }
			set { this._height = value; }
		}

		public String Cm
		{
			get { return this._cm; }
			set { this._cm = value; }
		}

		public String Weight
		{
			get { return this._weight; }
			set { this._weight = value; }
		}

		public String Kg
		{
			get { return this._kg; }
			set { this._kg = value; }
		}

		public String CplResult
		{
			get { return this._cplResult; }
			set { this._cplResult = value; }
		}

		public String Comments
		{
			get { return this._comments; }
			set { this._comments = value; }
		}

		public String Cnt
		{
			get { return this._cnt; }
			set { this._cnt = value; }
		}

		public DrgsDRG5100P01JungboInfo() { }

		public DrgsDRG5100P01JungboInfo(String height, String cm, String weight, String kg, String cplResult, String comments, String cnt)
		{
			this._height = height;
			this._cm = cm;
			this._weight = weight;
			this._kg = kg;
			this._cplResult = cplResult;
			this._comments = comments;
			this._cnt = cnt;
		}

	}
}