using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroOUT1001U01InsertJubsuArgs : IContractArgs
	{
        protected bool Equals(NuroOUT1001U01InsertJubsuArgs other)
        {
            return string.Equals(_sysId, other._sysId) && string.Equals(_updId, other._updId) && string.Equals(_pkout1001, other._pkout1001) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_gubun, other._gubun) && string.Equals(_doctor, other._doctor) && string.Equals(_chojae, other._chojae) && string.Equals(_jubsuTime, other._jubsuTime) && string.Equals(_naewonYn, other._naewonYn) && string.Equals(_naewonType, other._naewonType) && string.Equals(_sunnabYn, other._sunnabYn) && string.Equals(_jubsuGubun, other._jubsuGubun) && string.Equals(_inpTransYn, other._inpTransYn) && string.Equals(_bigo, other._bigo) && string.Equals(_jubsuNo, other._jubsuNo) && string.Equals(_sujinNo, other._sujinNo) && string.Equals(_wonyoiOrderYn, other._wonyoiOrderYn);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01InsertJubsuArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_sysId != null ? _sysId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_updId != null ? _updId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_chojae != null ? _chojae.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuTime != null ? _jubsuTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonYn != null ? _naewonYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonType != null ? _naewonType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sunnabYn != null ? _sunnabYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuGubun != null ? _jubsuGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_inpTransYn != null ? _inpTransYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bigo != null ? _bigo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuNo != null ? _jubsuNo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sujinNo != null ? _sujinNo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_wonyoiOrderYn != null ? _wonyoiOrderYn.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _sysId;
		private String _updId;
		private String _pkout1001;
		private String _naewonDate;
		private String _bunho;
		private String _gwa;
		private String _gubun;
		private String _doctor;
		private String _chojae;
		private String _jubsuTime;
		private String _naewonYn;
		private String _naewonType;
		private String _sunnabYn;
		private String _jubsuGubun;
		private String _inpTransYn;
		private String _bigo;
		private String _jubsuNo;
		private String _sujinNo;
		private String _wonyoiOrderYn;

		public String SysId
		{
			get { return this._sysId; }
			set { this._sysId = value; }
		}

		public String UpdId
		{
			get { return this._updId; }
			set { this._updId = value; }
		}

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String Chojae
		{
			get { return this._chojae; }
			set { this._chojae = value; }
		}

		public String JubsuTime
		{
			get { return this._jubsuTime; }
			set { this._jubsuTime = value; }
		}

		public String NaewonYn
		{
			get { return this._naewonYn; }
			set { this._naewonYn = value; }
		}

		public String NaewonType
		{
			get { return this._naewonType; }
			set { this._naewonType = value; }
		}

		public String SunnabYn
		{
			get { return this._sunnabYn; }
			set { this._sunnabYn = value; }
		}

		public String JubsuGubun
		{
			get { return this._jubsuGubun; }
			set { this._jubsuGubun = value; }
		}

		public String InpTransYn
		{
			get { return this._inpTransYn; }
			set { this._inpTransYn = value; }
		}

		public String Bigo
		{
			get { return this._bigo; }
			set { this._bigo = value; }
		}

		public String JubsuNo
		{
			get { return this._jubsuNo; }
			set { this._jubsuNo = value; }
		}

		public String SujinNo
		{
			get { return this._sujinNo; }
			set { this._sujinNo = value; }
		}

		public String WonyoiOrderYn
		{
			get { return this._wonyoiOrderYn; }
			set { this._wonyoiOrderYn = value; }
		}

		public NuroOUT1001U01InsertJubsuArgs() { }

		public NuroOUT1001U01InsertJubsuArgs(String sysId, String updId, String pkout1001, String naewonDate, String bunho, String gwa, String gubun, String doctor, String chojae, String jubsuTime, String naewonYn, String naewonType, String sunnabYn, String jubsuGubun, String inpTransYn, String bigo, String jubsuNo, String sujinNo, String wonyoiOrderYn)
		{
			this._sysId = sysId;
			this._updId = updId;
			this._pkout1001 = pkout1001;
			this._naewonDate = naewonDate;
			this._bunho = bunho;
			this._gwa = gwa;
			this._gubun = gubun;
			this._doctor = doctor;
			this._chojae = chojae;
			this._jubsuTime = jubsuTime;
			this._naewonYn = naewonYn;
			this._naewonType = naewonType;
			this._sunnabYn = sunnabYn;
			this._jubsuGubun = jubsuGubun;
			this._inpTransYn = inpTransYn;
			this._bigo = bigo;
			this._jubsuNo = jubsuNo;
			this._sujinNo = sujinNo;
			this._wonyoiOrderYn = wonyoiOrderYn;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroOUT1001U01InsertJubsuRequest();
		}
	}
}