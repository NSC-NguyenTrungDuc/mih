using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
	public class XRT0000Q00LayOrderListItemInfo
	{
		private String _bunho;
		private String _decodeResult;
		private String _oValue;
		private String _gwa;
		private String _doctor;
		private String _doctorName;
		private String _nullValue;
		private String _hangmogCode;
		private String _hangmogName;
		private String _pandokSerial;
		private String _gwaName;
		private String _chk;
		private String _pkocs1003First;
		private String _pkocs1003Second;
		private String _ifActSendYn;
		private String _pandokStatus;
		private String _portableYn2;
		private String _pandokRequestYn;
		private String _xrayDate;
		private String _actDate;
		private String _hoDong;
		private String _hoCode;
		private String _gumsaMokjuk;
		private String _xrayGubun;
		private String _sortDate;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String DecodeResult
		{
			get { return this._decodeResult; }
			set { this._decodeResult = value; }
		}

		public String OValue
		{
			get { return this._oValue; }
			set { this._oValue = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public String NullValue
		{
			get { return this._nullValue; }
			set { this._nullValue = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String HangmogName
		{
			get { return this._hangmogName; }
			set { this._hangmogName = value; }
		}

		public String PandokSerial
		{
			get { return this._pandokSerial; }
			set { this._pandokSerial = value; }
		}

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public String Chk
		{
			get { return this._chk; }
			set { this._chk = value; }
		}

		public String Pkocs1003First
		{
			get { return this._pkocs1003First; }
			set { this._pkocs1003First = value; }
		}

		public String Pkocs1003Second
		{
			get { return this._pkocs1003Second; }
			set { this._pkocs1003Second = value; }
		}

		public String IfActSendYn
		{
			get { return this._ifActSendYn; }
			set { this._ifActSendYn = value; }
		}

		public String PandokStatus
		{
			get { return this._pandokStatus; }
			set { this._pandokStatus = value; }
		}

		public String PortableYn2
		{
			get { return this._portableYn2; }
			set { this._portableYn2 = value; }
		}

		public String PandokRequestYn
		{
			get { return this._pandokRequestYn; }
			set { this._pandokRequestYn = value; }
		}

		public String XrayDate
		{
			get { return this._xrayDate; }
			set { this._xrayDate = value; }
		}

		public String ActDate
		{
			get { return this._actDate; }
			set { this._actDate = value; }
		}

		public String HoDong
		{
			get { return this._hoDong; }
			set { this._hoDong = value; }
		}

		public String HoCode
		{
			get { return this._hoCode; }
			set { this._hoCode = value; }
		}

		public String GumsaMokjuk
		{
			get { return this._gumsaMokjuk; }
			set { this._gumsaMokjuk = value; }
		}

		public String XrayGubun
		{
			get { return this._xrayGubun; }
			set { this._xrayGubun = value; }
		}

		public String SortDate
		{
			get { return this._sortDate; }
			set { this._sortDate = value; }
		}

		public XRT0000Q00LayOrderListItemInfo() { }

		public XRT0000Q00LayOrderListItemInfo(String bunho, String decodeResult, String oValue, String gwa, String doctor, String doctorName, String nullValue, String hangmogCode, String hangmogName, String pandokSerial, String gwaName, String chk, String pkocs1003First, String pkocs1003Second, String ifActSendYn, String pandokStatus, String portableYn2, String pandokRequestYn, String xrayDate, String actDate, String hoDong, String hoCode, String gumsaMokjuk, String xrayGubun, String sortDate)
		{
			this._bunho = bunho;
			this._decodeResult = decodeResult;
			this._oValue = oValue;
			this._gwa = gwa;
			this._doctor = doctor;
			this._doctorName = doctorName;
			this._nullValue = nullValue;
			this._hangmogCode = hangmogCode;
			this._hangmogName = hangmogName;
			this._pandokSerial = pandokSerial;
			this._gwaName = gwaName;
			this._chk = chk;
			this._pkocs1003First = pkocs1003First;
			this._pkocs1003Second = pkocs1003Second;
			this._ifActSendYn = ifActSendYn;
			this._pandokStatus = pandokStatus;
			this._portableYn2 = portableYn2;
			this._pandokRequestYn = pandokRequestYn;
			this._xrayDate = xrayDate;
			this._actDate = actDate;
			this._hoDong = hoDong;
			this._hoCode = hoCode;
			this._gumsaMokjuk = gumsaMokjuk;
			this._xrayGubun = xrayGubun;
			this._sortDate = sortDate;
		}

	}
}