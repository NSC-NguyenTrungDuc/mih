using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
	public class TripleListItemInfo
	{
		private String _item1;
		private String _item2;
		private String _item3;

		public String Item1
		{
			get { return this._item1; }
			set { this._item1 = value; }
		}

		public String Item2
		{
			get { return this._item2; }
			set { this._item2 = value; }
		}

		public String Item3
		{
			get { return this._item3; }
			set { this._item3 = value; }
		}

		public TripleListItemInfo() { }

		public TripleListItemInfo(String item1, String item2, String item3)
		{
			this._item1 = item1;
			this._item2 = item2;
			this._item3 = item3;
		}

	}
}