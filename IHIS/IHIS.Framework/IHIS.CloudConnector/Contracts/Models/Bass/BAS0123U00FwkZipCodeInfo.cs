using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
	public class BAS0123U00FwkZipCodeInfo
	{
		private String _zipCode;
		private String _zipName1;
		private String _zipName2;
		private String _zipName3;

		public String ZipCode
		{
			get { return this._zipCode; }
			set { this._zipCode = value; }
		}

		public String ZipName1
		{
			get { return this._zipName1; }
			set { this._zipName1 = value; }
		}

		public String ZipName2
		{
			get { return this._zipName2; }
			set { this._zipName2 = value; }
		}

		public String ZipName3
		{
			get { return this._zipName3; }
			set { this._zipName3 = value; }
		}

		public BAS0123U00FwkZipCodeInfo() { }

		public BAS0123U00FwkZipCodeInfo(String zipCode, String zipName1, String zipName2, String zipName3)
		{
			this._zipCode = zipCode;
			this._zipName1 = zipName1;
			this._zipName2 = zipName2;
			this._zipName3 = zipName3;
		}

	}
}