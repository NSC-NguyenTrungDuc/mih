using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL0000Q00SelectOUT0101ListItemInfo
	{
		private String _bunho;
		private String _suname;
		private String _birth;
		private String _sex;
		private String _age;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Suname
		{
			get { return this._suname; }
			set { this._suname = value; }
		}

		public String Birth
		{
			get { return this._birth; }
			set { this._birth = value; }
		}

		public String Sex
		{
			get { return this._sex; }
			set { this._sex = value; }
		}

		public String Age
		{
			get { return this._age; }
			set { this._age = value; }
		}

		public CPL0000Q00SelectOUT0101ListItemInfo() { }

		public CPL0000Q00SelectOUT0101ListItemInfo(String bunho, String suname, String birth, String sex, String age)
		{
			this._bunho = bunho;
			this._suname = suname;
			this._birth = birth;
			this._sex = sex;
			this._age = age;
		}

	}
}