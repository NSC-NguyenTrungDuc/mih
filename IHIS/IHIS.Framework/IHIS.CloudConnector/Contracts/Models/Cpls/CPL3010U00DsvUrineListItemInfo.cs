using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL3010U00DsvUrineListItemInfo
	{
		private String _pkcpl1000;
		private String _urineRyang;
		private String _height;
		private String _weight;
		private String _stabilityYn;
		private String _specimenSer;

		public String Pkcpl1000
		{
			get { return this._pkcpl1000; }
			set { this._pkcpl1000 = value; }
		}

		public String UrineRyang
		{
			get { return this._urineRyang; }
			set { this._urineRyang = value; }
		}

		public String Height
		{
			get { return this._height; }
			set { this._height = value; }
		}

		public String Weight
		{
			get { return this._weight; }
			set { this._weight = value; }
		}

		public String StabilityYn
		{
			get { return this._stabilityYn; }
			set { this._stabilityYn = value; }
		}

		public String SpecimenSer
		{
			get { return this._specimenSer; }
			set { this._specimenSer = value; }
		}

		public CPL3010U00DsvUrineListItemInfo() { }

		public CPL3010U00DsvUrineListItemInfo(String pkcpl1000, String urineRyang, String height, String weight, String stabilityYn, String specimenSer)
		{
			this._pkcpl1000 = pkcpl1000;
			this._urineRyang = urineRyang;
			this._height = height;
			this._weight = weight;
			this._stabilityYn = stabilityYn;
			this._specimenSer = specimenSer;
		}

	}
}