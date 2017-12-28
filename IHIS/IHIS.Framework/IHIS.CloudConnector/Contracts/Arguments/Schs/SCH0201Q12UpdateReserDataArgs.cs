using System;
using ProtoBuf;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;
using IHIS.CloudConnector.Messaging;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SCH0201Q12UpdateReserDataArgs : IContractArgs
	{
    protected bool Equals(SCH0201Q12UpdateReserDataArgs other)
    {
        return string.Equals(_gubun, other._gubun) && string.Equals(_userId, other._userId) && string.Equals(_reserDate, other._reserDate) && Equals(_updateData, other._updateData) && string.Equals(_iudGubun, other._iudGubun) && string.Equals(_pkout1001, other._pkout1001) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_reserGubun, other._reserGubun) && string.Equals(_statFlg, other._statFlg) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_bunho, other._bunho);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH0201Q12UpdateReserDataArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_gubun != null ? _gubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_updateData != null ? _updateData.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_iudGubun != null ? _iudGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_reserGubun != null ? _reserGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_statFlg != null ? _statFlg.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _gubun;
		private String _userId;
		private String _reserDate;
        private List<IHIS.CloudConnector.Contracts.Models.Schs.SCH0201Q12UpdateReserData> _updateData =
            new List<IHIS.CloudConnector.Contracts.Models.Schs.SCH0201Q12UpdateReserData>();
		private String _iudGubun;
		private String _pkout1001;
		private String _gwa;
		private String _doctor;
		private String _reserGubun;
		private String _statFlg;
		private String _naewonDate;
		private String _bunho;

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

        public List<IHIS.CloudConnector.Contracts.Models.Schs.SCH0201Q12UpdateReserData> UpdateData
		{
			get { return this._updateData; }
			set { this._updateData = value; }
		}

		public String IudGubun
		{
			get { return this._iudGubun; }
			set { this._iudGubun = value; }
		}

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
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

		public String ReserGubun
		{
			get { return this._reserGubun; }
			set { this._reserGubun = value; }
		}

		public String StatFlg
		{
			get { return this._statFlg; }
			set { this._statFlg = value; }
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

		public SCH0201Q12UpdateReserDataArgs() { }

		public SCH0201Q12UpdateReserDataArgs
        (
            String gubun,
            String userId,
            String reserDate,
            List<IHIS.CloudConnector.Contracts.Models.Schs.SCH0201Q12UpdateReserData> updateData,
            String iudGubun,
            String pkout1001,
            String gwa,
            String doctor,
            String reserGubun,
            String statFlg,
            String naewonDate,
            String bunho
        )
		{
			this._gubun = gubun;
			this._userId = userId;
			this._reserDate = reserDate;
			this._updateData = updateData;
			this._iudGubun = iudGubun;
			this._pkout1001 = pkout1001;
			this._gwa = gwa;
			this._doctor = doctor;
			this._reserGubun = reserGubun;
			this._statFlg = statFlg;
			this._naewonDate = naewonDate;
			this._bunho = bunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new SCH0201Q12UpdateReserDataRequest();
		}
	}
}