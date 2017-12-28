using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class OcsLoadInputControlListItemInfo
	{
		private String _inputControl;
		private String _inputControlName;
		private String _specimenCode;
		private String _suryang;
		private String _ordDanui;
		private String _dv;
		private String _nalsu;
		private String _jusa;
		private String _bogyongCode;
		private String _toiwonDrgYn;
		private String _portableYn;
		private String _amt;
		private String _wonyoiOrderYn;

		public String InputControl
		{
			get { return this._inputControl; }
			set { this._inputControl = value; }
		}

		public String InputControlName
		{
			get { return this._inputControlName; }
			set { this._inputControlName = value; }
		}

		public String SpecimenCode
		{
			get { return this._specimenCode; }
			set { this._specimenCode = value; }
		}

		public String Suryang
		{
			get { return this._suryang; }
			set { this._suryang = value; }
		}

		public String OrdDanui
		{
			get { return this._ordDanui; }
			set { this._ordDanui = value; }
		}

		public String Dv
		{
			get { return this._dv; }
			set { this._dv = value; }
		}

		public String Nalsu
		{
			get { return this._nalsu; }
			set { this._nalsu = value; }
		}

		public String Jusa
		{
			get { return this._jusa; }
			set { this._jusa = value; }
		}

		public String BogyongCode
		{
			get { return this._bogyongCode; }
			set { this._bogyongCode = value; }
		}

		public String ToiwonDrgYn
		{
			get { return this._toiwonDrgYn; }
			set { this._toiwonDrgYn = value; }
		}

		public String PortableYn
		{
			get { return this._portableYn; }
			set { this._portableYn = value; }
		}

		public String Amt
		{
			get { return this._amt; }
			set { this._amt = value; }
		}

		public String WonyoiOrderYn
		{
			get { return this._wonyoiOrderYn; }
			set { this._wonyoiOrderYn = value; }
		}

		public OcsLoadInputControlListItemInfo() { }

		public OcsLoadInputControlListItemInfo(String inputControl, String inputControlName, String specimenCode, String suryang, String ordDanui, String dv, String nalsu, String jusa, String bogyongCode, String toiwonDrgYn, String portableYn, String amt, String wonyoiOrderYn)
		{
			this._inputControl = inputControl;
			this._inputControlName = inputControlName;
			this._specimenCode = specimenCode;
			this._suryang = suryang;
			this._ordDanui = ordDanui;
			this._dv = dv;
			this._nalsu = nalsu;
			this._jusa = jusa;
			this._bogyongCode = bogyongCode;
			this._toiwonDrgYn = toiwonDrgYn;
			this._portableYn = portableYn;
			this._amt = amt;
			this._wonyoiOrderYn = wonyoiOrderYn;
		}

	}
}