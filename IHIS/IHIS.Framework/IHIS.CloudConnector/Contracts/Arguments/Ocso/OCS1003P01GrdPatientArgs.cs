using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using NotApproveOrderCntInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.NotApproveOrderCntInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OCS1003P01GrdPatientArgs : IContractArgs
	{
    protected bool Equals(OCS1003P01GrdPatientArgs other)
    {
        return string.Equals(_naewonYn, other._naewonYn) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_reserYn, other._reserYn) && string.Equals(_doctor, other._doctor) && string.Equals(_doctorModeYn, other._doctorModeYn) && string.Equals(_bunho, other._bunho) && Equals(_orderCnt, other._orderCnt);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS1003P01GrdPatientArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_naewonYn != null ? _naewonYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_reserYn != null ? _reserYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctorModeYn != null ? _doctorModeYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderCnt != null ? _orderCnt.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _naewonYn;
		private String _naewonDate;
		private String _reserYn;
		private String _doctor;
		private String _doctorModeYn;
		private String _bunho;
		private NotApproveOrderCntInfo _orderCnt;

		public String NaewonYn
		{
			get { return this._naewonYn; }
			set { this._naewonYn = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String ReserYn
		{
			get { return this._reserYn; }
			set { this._reserYn = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String DoctorModeYn
		{
			get { return this._doctorModeYn; }
			set { this._doctorModeYn = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public NotApproveOrderCntInfo OrderCnt
		{
			get { return this._orderCnt; }
			set { this._orderCnt = value; }
		}

		public OCS1003P01GrdPatientArgs() { }

		public OCS1003P01GrdPatientArgs(String naewonYn, String naewonDate, String reserYn, String doctor, String doctorModeYn, String bunho, NotApproveOrderCntInfo orderCnt)
		{
			this._naewonYn = naewonYn;
			this._naewonDate = naewonDate;
			this._reserYn = reserYn;
			this._doctor = doctor;
			this._doctorModeYn = doctorModeYn;
			this._bunho = bunho;
			this._orderCnt = orderCnt;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS1003P01GrdPatientRequest();
		}
	}
}