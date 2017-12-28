using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]

	public class OCS2015U06OrderTypeComboInfo
	{
		private String _codeName;

		public String CodeName
		{
			get { return this._codeName; }
			set { this._codeName = value; }
		}

		public OCS2015U06OrderTypeComboInfo() { }

		public OCS2015U06OrderTypeComboInfo(String codeName)
		{
			this._codeName = codeName;
		}

	}
}