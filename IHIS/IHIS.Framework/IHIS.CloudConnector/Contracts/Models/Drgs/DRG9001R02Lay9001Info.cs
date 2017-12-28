using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DRG9001R02Lay9001Info
	{
		private String _holiDay;
		private String _drgCnt;
		private String _drgGroupCnt;
		private String _drgHangmogCnt;
		private String _injCnt;
		private String _injGroupCnt;
		private String _injHangmogCnt;
		private String _drgInjCnt;
		private String _drgInjGroupCnt;
		private String _drgInjHangmogCnt;

		public String HoliDay
		{
			get { return this._holiDay; }
			set { this._holiDay = value; }
		}

		public String DrgCnt
		{
			get { return this._drgCnt; }
			set { this._drgCnt = value; }
		}

		public String DrgGroupCnt
		{
			get { return this._drgGroupCnt; }
			set { this._drgGroupCnt = value; }
		}

		public String DrgHangmogCnt
		{
			get { return this._drgHangmogCnt; }
			set { this._drgHangmogCnt = value; }
		}

		public String InjCnt
		{
			get { return this._injCnt; }
			set { this._injCnt = value; }
		}

		public String InjGroupCnt
		{
			get { return this._injGroupCnt; }
			set { this._injGroupCnt = value; }
		}

		public String InjHangmogCnt
		{
			get { return this._injHangmogCnt; }
			set { this._injHangmogCnt = value; }
		}

		public String DrgInjCnt
		{
			get { return this._drgInjCnt; }
			set { this._drgInjCnt = value; }
		}

		public String DrgInjGroupCnt
		{
			get { return this._drgInjGroupCnt; }
			set { this._drgInjGroupCnt = value; }
		}

		public String DrgInjHangmogCnt
		{
			get { return this._drgInjHangmogCnt; }
			set { this._drgInjHangmogCnt = value; }
		}

		public DRG9001R02Lay9001Info() { }

		public DRG9001R02Lay9001Info(String holiDay, String drgCnt, String drgGroupCnt, String drgHangmogCnt, String injCnt, String injGroupCnt, String injHangmogCnt, String drgInjCnt, String drgInjGroupCnt, String drgInjHangmogCnt)
		{
			this._holiDay = holiDay;
			this._drgCnt = drgCnt;
			this._drgGroupCnt = drgGroupCnt;
			this._drgHangmogCnt = drgHangmogCnt;
			this._injCnt = injCnt;
			this._injGroupCnt = injGroupCnt;
			this._injHangmogCnt = injHangmogCnt;
			this._drgInjCnt = drgInjCnt;
			this._drgInjGroupCnt = drgInjGroupCnt;
			this._drgInjHangmogCnt = drgInjHangmogCnt;
		}

	}
}