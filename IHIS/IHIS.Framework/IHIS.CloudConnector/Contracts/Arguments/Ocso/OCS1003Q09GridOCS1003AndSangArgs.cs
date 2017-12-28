using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OCS1003Q09GridOCS1003AndSangArgs : IContractArgs
	{
    protected bool Equals(OCS1003Q09GridOCS1003AndSangArgs other)
    {
        return string.Equals(_grdsangBunho, other._grdsangBunho) && string.Equals(_grdsangNaewonDate, other._grdsangNaewonDate) && string.Equals(_grdsangGwa, other._grdsangGwa) && string.Equals(_grdsangDoctor, other._grdsangDoctor) && string.Equals(_grdsangNaewonType, other._grdsangNaewonType) && string.Equals(_grdsangJubsuNo, other._grdsangJubsuNo) && string.Equals(_grdsangIoGubun, other._grdsangIoGubun) && string.Equals(_grdocs1003Bunho, other._grdocs1003Bunho) && string.Equals(_grdocs1003NaewonDate, other._grdocs1003NaewonDate) && string.Equals(_grdocs1003Gwa, other._grdocs1003Gwa) && string.Equals(_grdocs1003Doctor, other._grdocs1003Doctor) && string.Equals(_grdocs1003NaewonType, other._grdocs1003NaewonType) && string.Equals(_grdocs1003InputGubun, other._grdocs1003InputGubun) && string.Equals(_grdocs1003TelYn, other._grdocs1003TelYn) && string.Equals(_grdocs1003InputTab, other._grdocs1003InputTab) && string.Equals(_grdocs1003JubsuNo, other._grdocs1003JubsuNo) && string.Equals(_grdocs1003PkOrder, other._grdocs1003PkOrder) && string.Equals(_grdocs1003GenericYn, other._grdocs1003GenericYn) && string.Equals(_grdocs1003Kijun, other._grdocs1003Kijun) && string.Equals(_grdocs1003IoGubun, other._grdocs1003IoGubun);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS1003Q09GridOCS1003AndSangArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_grdsangBunho != null ? _grdsangBunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdsangNaewonDate != null ? _grdsangNaewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdsangGwa != null ? _grdsangGwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdsangDoctor != null ? _grdsangDoctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdsangNaewonType != null ? _grdsangNaewonType.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdsangJubsuNo != null ? _grdsangJubsuNo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdsangIoGubun != null ? _grdsangIoGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdocs1003Bunho != null ? _grdocs1003Bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdocs1003NaewonDate != null ? _grdocs1003NaewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdocs1003Gwa != null ? _grdocs1003Gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdocs1003Doctor != null ? _grdocs1003Doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdocs1003NaewonType != null ? _grdocs1003NaewonType.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdocs1003InputGubun != null ? _grdocs1003InputGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdocs1003TelYn != null ? _grdocs1003TelYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdocs1003InputTab != null ? _grdocs1003InputTab.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdocs1003JubsuNo != null ? _grdocs1003JubsuNo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdocs1003PkOrder != null ? _grdocs1003PkOrder.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdocs1003GenericYn != null ? _grdocs1003GenericYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdocs1003Kijun != null ? _grdocs1003Kijun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdocs1003IoGubun != null ? _grdocs1003IoGubun.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _grdsangBunho;
		private String _grdsangNaewonDate;
		private String _grdsangGwa;
		private String _grdsangDoctor;
		private String _grdsangNaewonType;
		private String _grdsangJubsuNo;
		private String _grdsangIoGubun;
		private String _grdocs1003Bunho;
		private String _grdocs1003NaewonDate;
		private String _grdocs1003Gwa;
		private String _grdocs1003Doctor;
		private String _grdocs1003NaewonType;
		private String _grdocs1003InputGubun;
		private String _grdocs1003TelYn;
		private String _grdocs1003InputTab;
		private String _grdocs1003JubsuNo;
		private String _grdocs1003PkOrder;
		private String _grdocs1003GenericYn;
		private String _grdocs1003Kijun;
		private String _grdocs1003IoGubun;

		public String GrdsangBunho
		{
			get { return this._grdsangBunho; }
			set { this._grdsangBunho = value; }
		}

		public String GrdsangNaewonDate
		{
			get { return this._grdsangNaewonDate; }
			set { this._grdsangNaewonDate = value; }
		}

		public String GrdsangGwa
		{
			get { return this._grdsangGwa; }
			set { this._grdsangGwa = value; }
		}

		public String GrdsangDoctor
		{
			get { return this._grdsangDoctor; }
			set { this._grdsangDoctor = value; }
		}

		public String GrdsangNaewonType
		{
			get { return this._grdsangNaewonType; }
			set { this._grdsangNaewonType = value; }
		}

		public String GrdsangJubsuNo
		{
			get { return this._grdsangJubsuNo; }
			set { this._grdsangJubsuNo = value; }
		}

		public String GrdsangIoGubun
		{
			get { return this._grdsangIoGubun; }
			set { this._grdsangIoGubun = value; }
		}

		public String Grdocs1003Bunho
		{
			get { return this._grdocs1003Bunho; }
			set { this._grdocs1003Bunho = value; }
		}

		public String Grdocs1003NaewonDate
		{
			get { return this._grdocs1003NaewonDate; }
			set { this._grdocs1003NaewonDate = value; }
		}

		public String Grdocs1003Gwa
		{
			get { return this._grdocs1003Gwa; }
			set { this._grdocs1003Gwa = value; }
		}

		public String Grdocs1003Doctor
		{
			get { return this._grdocs1003Doctor; }
			set { this._grdocs1003Doctor = value; }
		}

		public String Grdocs1003NaewonType
		{
			get { return this._grdocs1003NaewonType; }
			set { this._grdocs1003NaewonType = value; }
		}

		public String Grdocs1003InputGubun
		{
			get { return this._grdocs1003InputGubun; }
			set { this._grdocs1003InputGubun = value; }
		}

		public String Grdocs1003TelYn
		{
			get { return this._grdocs1003TelYn; }
			set { this._grdocs1003TelYn = value; }
		}

		public String Grdocs1003InputTab
		{
			get { return this._grdocs1003InputTab; }
			set { this._grdocs1003InputTab = value; }
		}

		public String Grdocs1003JubsuNo
		{
			get { return this._grdocs1003JubsuNo; }
			set { this._grdocs1003JubsuNo = value; }
		}

		public String Grdocs1003PkOrder
		{
			get { return this._grdocs1003PkOrder; }
			set { this._grdocs1003PkOrder = value; }
		}

		public String Grdocs1003GenericYn
		{
			get { return this._grdocs1003GenericYn; }
			set { this._grdocs1003GenericYn = value; }
		}

		public String Grdocs1003Kijun
		{
			get { return this._grdocs1003Kijun; }
			set { this._grdocs1003Kijun = value; }
		}

		public String Grdocs1003IoGubun
		{
			get { return this._grdocs1003IoGubun; }
			set { this._grdocs1003IoGubun = value; }
		}

		public OCS1003Q09GridOCS1003AndSangArgs() { }

		public OCS1003Q09GridOCS1003AndSangArgs(String grdsangBunho, String grdsangNaewonDate, String grdsangGwa, String grdsangDoctor, String grdsangNaewonType, String grdsangJubsuNo, String grdsangIoGubun, String grdocs1003Bunho, String grdocs1003NaewonDate, String grdocs1003Gwa, String grdocs1003Doctor, String grdocs1003NaewonType, String grdocs1003InputGubun, String grdocs1003TelYn, String grdocs1003InputTab, String grdocs1003JubsuNo, String grdocs1003PkOrder, String grdocs1003GenericYn, String grdocs1003Kijun, String grdocs1003IoGubun)
		{
			this._grdsangBunho = grdsangBunho;
			this._grdsangNaewonDate = grdsangNaewonDate;
			this._grdsangGwa = grdsangGwa;
			this._grdsangDoctor = grdsangDoctor;
			this._grdsangNaewonType = grdsangNaewonType;
			this._grdsangJubsuNo = grdsangJubsuNo;
			this._grdsangIoGubun = grdsangIoGubun;
			this._grdocs1003Bunho = grdocs1003Bunho;
			this._grdocs1003NaewonDate = grdocs1003NaewonDate;
			this._grdocs1003Gwa = grdocs1003Gwa;
			this._grdocs1003Doctor = grdocs1003Doctor;
			this._grdocs1003NaewonType = grdocs1003NaewonType;
			this._grdocs1003InputGubun = grdocs1003InputGubun;
			this._grdocs1003TelYn = grdocs1003TelYn;
			this._grdocs1003InputTab = grdocs1003InputTab;
			this._grdocs1003JubsuNo = grdocs1003JubsuNo;
			this._grdocs1003PkOrder = grdocs1003PkOrder;
			this._grdocs1003GenericYn = grdocs1003GenericYn;
			this._grdocs1003Kijun = grdocs1003Kijun;
			this._grdocs1003IoGubun = grdocs1003IoGubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS1003Q09GridOCS1003AndSangRequest();
		}
	}
}