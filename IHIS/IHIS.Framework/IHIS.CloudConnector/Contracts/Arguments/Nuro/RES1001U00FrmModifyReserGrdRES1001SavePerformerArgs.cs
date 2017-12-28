using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class RES1001U00FrmModifyReserGrdRES1001SavePerformerArgs : IContractArgs
	{
        protected bool Equals(RES1001U00FrmModifyReserGrdRES1001SavePerformerArgs other)
        {
            return string.Equals(_qUserId, other._qUserId) && string.Equals(_hospCode, other._hospCode) && string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_gubun, other._gubun) && string.Equals(_jinryoPreDate, other._jinryoPreDate) && string.Equals(_jinryoPreTime, other._jinryoPreTime) && string.Equals(_doctor, other._doctor) && string.Equals(_inputGubun, other._inputGubun) && string.Equals(_pkres1001, other._pkres1001) && string.Equals(_pkout1001, other._pkout1001) && string.Equals(_changgu, other._changgu) && string.Equals(_chojae, other._chojae) && string.Equals(_jubsuNo, other._jubsuNo) && string.Equals(_resGubun, other._resGubun) && string.Equals(_rowstate, other._rowstate) && string.Equals(_newrow, other._newrow);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RES1001U00FrmModifyReserGrdRES1001SavePerformerArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_qUserId != null ? _qUserId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jinryoPreDate != null ? _jinryoPreDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jinryoPreTime != null ? _jinryoPreTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_inputGubun != null ? _inputGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkres1001 != null ? _pkres1001.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_changgu != null ? _changgu.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_chojae != null ? _chojae.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuNo != null ? _jubsuNo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resGubun != null ? _resGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_rowstate != null ? _rowstate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_newrow != null ? _newrow.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _qUserId;
		private String _hospCode;
		private String _bunho;
		private String _gwa;
		private String _gubun;
		private String _jinryoPreDate;
		private String _jinryoPreTime;
		private String _doctor;
		private String _inputGubun;
		private String _pkres1001;
		private String _pkout1001;
		private String _changgu;
		private String _chojae;
		private String _jubsuNo;
		private String _resGubun;
		private String _rowstate;
		private String _newrow;

		public String QUserId
		{
			get { return this._qUserId; }
			set { this._qUserId = value; }
		}

		public String HospCode
		{
			get { return this._hospCode; }
			set { this._hospCode = value; }
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

		public String JinryoPreDate
		{
			get { return this._jinryoPreDate; }
			set { this._jinryoPreDate = value; }
		}

		public String JinryoPreTime
		{
			get { return this._jinryoPreTime; }
			set { this._jinryoPreTime = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String InputGubun
		{
			get { return this._inputGubun; }
			set { this._inputGubun = value; }
		}

		public String Pkres1001
		{
			get { return this._pkres1001; }
			set { this._pkres1001 = value; }
		}

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public String Changgu
		{
			get { return this._changgu; }
			set { this._changgu = value; }
		}

		public String Chojae
		{
			get { return this._chojae; }
			set { this._chojae = value; }
		}

		public String JubsuNo
		{
			get { return this._jubsuNo; }
			set { this._jubsuNo = value; }
		}

		public String ResGubun
		{
			get { return this._resGubun; }
			set { this._resGubun = value; }
		}

		public String Rowstate
		{
			get { return this._rowstate; }
			set { this._rowstate = value; }
		}

		public String Newrow
		{
			get { return this._newrow; }
			set { this._newrow = value; }
		}

		public RES1001U00FrmModifyReserGrdRES1001SavePerformerArgs() { }

		public RES1001U00FrmModifyReserGrdRES1001SavePerformerArgs(String qUserId, String hospCode, String bunho, String gwa, String gubun, String jinryoPreDate, String jinryoPreTime, String doctor, String inputGubun, String pkres1001, String pkout1001, String changgu, String chojae, String jubsuNo, String resGubun, String rowstate, String newrow)
		{
			this._qUserId = qUserId;
			this._hospCode = hospCode;
			this._bunho = bunho;
			this._gwa = gwa;
			this._gubun = gubun;
			this._jinryoPreDate = jinryoPreDate;
			this._jinryoPreTime = jinryoPreTime;
			this._doctor = doctor;
			this._inputGubun = inputGubun;
			this._pkres1001 = pkres1001;
			this._pkout1001 = pkout1001;
			this._changgu = changgu;
			this._chojae = chojae;
			this._jubsuNo = jubsuNo;
			this._resGubun = resGubun;
			this._rowstate = rowstate;
			this._newrow = newrow;
		}

		public IExtensible GetRequestInstance()
		{
			return new RES1001U00FrmModifyReserGrdRES1001SavePerformerRequest();
		}
	}
}