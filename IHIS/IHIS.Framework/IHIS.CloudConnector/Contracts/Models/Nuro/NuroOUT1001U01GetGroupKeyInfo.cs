using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class NuroOUT1001U01GetGroupKeyInfo
	{
		private String _groupKey;

		public String GroupKey
		{
			get { return this._groupKey; }
			set { this._groupKey = value; }
		}

		public NuroOUT1001U01GetGroupKeyInfo() { }

		public NuroOUT1001U01GetGroupKeyInfo(String groupKey)
		{
			this._groupKey = groupKey;
		}

	}
}
