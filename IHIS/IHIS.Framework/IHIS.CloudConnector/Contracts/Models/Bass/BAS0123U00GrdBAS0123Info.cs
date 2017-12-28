using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
	public class BAS0123U00GrdBAS0123Info
	{
		private String _zipCode;
		private String _zipName1;
		private String _zipName2;
		private String _zipName3;
		private String _zipNameGana1;
		private String _zipNameGana2;
		private String _zipNameGana3;
		private String _zipTonggye;
		private String _zipCode1;
		private String _zipCode2;
		private String _dataRowState;

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

		public String ZipNameGana1
		{
			get { return this._zipNameGana1; }
			set { this._zipNameGana1 = value; }
		}

		public String ZipNameGana2
		{
			get { return this._zipNameGana2; }
			set { this._zipNameGana2 = value; }
		}

		public String ZipNameGana3
		{
			get { return this._zipNameGana3; }
			set { this._zipNameGana3 = value; }
		}

		public String ZipTonggye
		{
			get { return this._zipTonggye; }
			set { this._zipTonggye = value; }
		}

		public String ZipCode1
		{
			get { return this._zipCode1; }
			set { this._zipCode1 = value; }
		}

		public String ZipCode2
		{
			get { return this._zipCode2; }
			set { this._zipCode2 = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public BAS0123U00GrdBAS0123Info() { }

		public BAS0123U00GrdBAS0123Info(String zipCode, String zipName1, String zipName2, String zipName3, String zipNameGana1, String zipNameGana2, String zipNameGana3, String zipTonggye, String zipCode1, String zipCode2, String dataRowState)
		{
			this._zipCode = zipCode;
			this._zipName1 = zipName1;
			this._zipName2 = zipName2;
			this._zipName3 = zipName3;
			this._zipNameGana1 = zipNameGana1;
			this._zipNameGana2 = zipNameGana2;
			this._zipNameGana3 = zipNameGana3;
			this._zipTonggye = zipTonggye;
			this._zipCode1 = zipCode1;
			this._zipCode2 = zipCode2;
			this._dataRowState = dataRowState;
		}

	}
}