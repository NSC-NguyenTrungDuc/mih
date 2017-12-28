using System;

namespace IHIS.CloudConnector.Contracts.Models.Injs
{
    [Serializable]
	public class InjsINJ1001U01InfectionListItemInfo
	{
		private String _infeJaeryo;
		private String _infeCode;

		public String InfeJaeryo
		{
			get { return this._infeJaeryo; }
			set { this._infeJaeryo = value; }
		}

		public String InfeCode
		{
			get { return this._infeCode; }
			set { this._infeCode = value; }
		}

		public InjsINJ1001U01InfectionListItemInfo() { }

		public InjsINJ1001U01InfectionListItemInfo(String infeJaeryo, String infeCode)
		{
			this._infeJaeryo = infeJaeryo;
			this._infeCode = infeCode;
		}

	}
}