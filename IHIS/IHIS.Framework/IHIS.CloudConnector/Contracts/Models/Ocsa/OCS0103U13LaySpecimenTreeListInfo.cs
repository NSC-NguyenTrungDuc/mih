using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0103U13LaySpecimenTreeListInfo
	{
		private String _slipGubun;
		private String _slipGubunName;
		private String _slipCode;
		private String _slipName;
		private String _cplCodeYn;
		private String _zero;

		public String SlipGubun
		{
			get { return this._slipGubun; }
			set { this._slipGubun = value; }
		}

		public String SlipGubunName
		{
			get { return this._slipGubunName; }
			set { this._slipGubunName = value; }
		}

		public String SlipCode
		{
			get { return this._slipCode; }
			set { this._slipCode = value; }
		}

		public String SlipName
		{
			get { return this._slipName; }
			set { this._slipName = value; }
		}

		public String CplCodeYn
		{
			get { return this._cplCodeYn; }
			set { this._cplCodeYn = value; }
		}

		public String Zero
		{
			get { return this._zero; }
			set { this._zero = value; }
		}

		public OCS0103U13LaySpecimenTreeListInfo() { }

		public OCS0103U13LaySpecimenTreeListInfo(String slipGubun, String slipGubunName, String slipCode, String slipName, String cplCodeYn, String zero)
		{
			this._slipGubun = slipGubun;
			this._slipGubunName = slipGubunName;
			this._slipCode = slipCode;
			this._slipName = slipName;
			this._cplCodeYn = cplCodeYn;
			this._zero = zero;
		}

	}
}