using System;

namespace IHIS.CloudConnector.Contracts.Models.Injs
{
    [Serializable]
	public class INJ1001U01FormJusaBedLayHosilItemInfo
	{
		private String _codeType;
		private String _one;
		private String _su;

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public String One
		{
			get { return this._one; }
			set { this._one = value; }
		}

		public String Su
		{
			get { return this._su; }
			set { this._su = value; }
		}

		public INJ1001U01FormJusaBedLayHosilItemInfo() { }

		public INJ1001U01FormJusaBedLayHosilItemInfo(String codeType, String one, String su)
		{
			this._codeType = codeType;
			this._one = one;
			this._su = su;
		}

	}
}