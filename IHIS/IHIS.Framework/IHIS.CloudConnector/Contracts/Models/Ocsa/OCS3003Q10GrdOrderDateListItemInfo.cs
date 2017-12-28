using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS3003Q10GrdOrderDateListItemInfo
	{
		private String _orderDate;
		private String _gwa;
		private String _gwaName;
		private String _doctorName;
		private String _bunho;
		private String _doctor;
		private String _naewonType;
		private String _jubsuNo;
		private String _pkOrder;
		private String _ioGubun;
		private String _specificComment;
		private String _pkocskey;
		private String _hangmogName;
		private String _hangmogCode;
		private String _jundalPart;
		private String _iraiKubun;
		private String _image;
		private String _imagePath;
		private String _crTime;

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String NaewonType
		{
			get { return this._naewonType; }
			set { this._naewonType = value; }
		}

		public String JubsuNo
		{
			get { return this._jubsuNo; }
			set { this._jubsuNo = value; }
		}

		public String PkOrder
		{
			get { return this._pkOrder; }
			set { this._pkOrder = value; }
		}

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String SpecificComment
		{
			get { return this._specificComment; }
			set { this._specificComment = value; }
		}

		public String Pkocskey
		{
			get { return this._pkocskey; }
			set { this._pkocskey = value; }
		}

		public String HangmogName
		{
			get { return this._hangmogName; }
			set { this._hangmogName = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String JundalPart
		{
			get { return this._jundalPart; }
			set { this._jundalPart = value; }
		}

		public String IraiKubun
		{
			get { return this._iraiKubun; }
			set { this._iraiKubun = value; }
		}

		public String Image
		{
			get { return this._image; }
			set { this._image = value; }
		}

		public String ImagePath
		{
			get { return this._imagePath; }
			set { this._imagePath = value; }
		}

		public String CrTime
		{
			get { return this._crTime; }
			set { this._crTime = value; }
		}

		public OCS3003Q10GrdOrderDateListItemInfo() { }

		public OCS3003Q10GrdOrderDateListItemInfo(String orderDate, String gwa, String gwaName, String doctorName, String bunho, String doctor, String naewonType, String jubsuNo, String pkOrder, String ioGubun, String specificComment, String pkocskey, String hangmogName, String hangmogCode, String jundalPart, String iraiKubun, String image, String imagePath, String crTime)
		{
			this._orderDate = orderDate;
			this._gwa = gwa;
			this._gwaName = gwaName;
			this._doctorName = doctorName;
			this._bunho = bunho;
			this._doctor = doctor;
			this._naewonType = naewonType;
			this._jubsuNo = jubsuNo;
			this._pkOrder = pkOrder;
			this._ioGubun = ioGubun;
			this._specificComment = specificComment;
			this._pkocskey = pkocskey;
			this._hangmogName = hangmogName;
			this._hangmogCode = hangmogCode;
			this._jundalPart = jundalPart;
			this._iraiKubun = iraiKubun;
			this._image = image;
			this._imagePath = imagePath;
			this._crTime = crTime;
		}

	}
}