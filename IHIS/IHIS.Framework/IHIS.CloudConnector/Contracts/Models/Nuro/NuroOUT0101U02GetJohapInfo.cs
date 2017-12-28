using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable ]
	public class NuroOUT0101U02GetJohapInfo
	{
		private String _johapName;
		private String _johapGubun;

		public String JohapName
		{
			get { return this._johapName; }
			set { this._johapName = value; }
		}

		public String JohapGubun
		{
			get { return this._johapGubun; }
			set { this._johapGubun = value; }
		}

		public NuroOUT0101U02GetJohapInfo() { }

		public NuroOUT0101U02GetJohapInfo(String johapName, String johapGubun)
		{
			this._johapName = johapName;
			this._johapGubun = johapGubun;
		}

	}
}