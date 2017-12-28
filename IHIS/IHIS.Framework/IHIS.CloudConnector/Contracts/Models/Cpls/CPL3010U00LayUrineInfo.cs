using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL3010U00LayUrineInfo
	{
		private String _userId;
		private String _urineRyang;
		private String _stabilityYn;
		private String _specimenSer;
		private String _pkcpl1000;

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String UrineRyang
		{
			get { return this._urineRyang; }
			set { this._urineRyang = value; }
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

		public String Pkcpl1000
		{
			get { return this._pkcpl1000; }
			set { this._pkcpl1000 = value; }
		}

		public CPL3010U00LayUrineInfo() { }

		public CPL3010U00LayUrineInfo(String userId, String urineRyang, String stabilityYn, String specimenSer, String pkcpl1000)
		{
			this._userId = userId;
			this._urineRyang = urineRyang;
			this._stabilityYn = stabilityYn;
			this._specimenSer = specimenSer;
			this._pkcpl1000 = pkcpl1000;
		}

	}
}