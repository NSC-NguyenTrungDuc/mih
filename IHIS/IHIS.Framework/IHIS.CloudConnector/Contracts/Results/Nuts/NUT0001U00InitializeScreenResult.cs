using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuts;

namespace IHIS.CloudConnector.Contracts.Results.Nuts
{
    [Serializable]
	public class NUT0001U00InitializeScreenResult : AbstractContractResult
	{
		private String _sysDate;
		private String _gwaName;
		private List<NUT0001U00GrdNUT0001ItemInfo> _grd001ItemInfo = new List<NUT0001U00GrdNUT0001ItemInfo>();
		private String _seq;
		private String _hangmogName;
		private Boolean _isPossibleInsteadOrder;

		public String SysDate
		{
			get { return this._sysDate; }
			set { this._sysDate = value; }
		}

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public List<NUT0001U00GrdNUT0001ItemInfo> Grd001ItemInfo
		{
			get { return this._grd001ItemInfo; }
			set { this._grd001ItemInfo = value; }
		}

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
		}

		public String HangmogName
		{
			get { return this._hangmogName; }
			set { this._hangmogName = value; }
		}

		public Boolean IsPossibleInsteadOrder
		{
			get { return this._isPossibleInsteadOrder; }
			set { this._isPossibleInsteadOrder = value; }
		}

		public NUT0001U00InitializeScreenResult() { }

	}
}