using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OcsoOCS1003P01LayPatArgs : IContractArgs
	{
    protected bool Equals(OcsoOCS1003P01LayPatArgs other)
    {
        return string.Equals(_fDoctor, other._fDoctor) && string.Equals(_fBunho, other._fBunho) && string.Equals(_fNaewonDate, other._fNaewonDate) && string.Equals(_fLoginDoctorYn, other._fLoginDoctorYn);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsoOCS1003P01LayPatArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_fDoctor != null ? _fDoctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fBunho != null ? _fBunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fNaewonDate != null ? _fNaewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fLoginDoctorYn != null ? _fLoginDoctorYn.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _fDoctor;
		private String _fBunho;
		private String _fNaewonDate;
		private String _fLoginDoctorYn;

		public String FDoctor
		{
			get { return this._fDoctor; }
			set { this._fDoctor = value; }
		}

		public String FBunho
		{
			get { return this._fBunho; }
			set { this._fBunho = value; }
		}

		public String FNaewonDate
		{
			get { return this._fNaewonDate; }
			set { this._fNaewonDate = value; }
		}

		public String FLoginDoctorYn
		{
			get { return this._fLoginDoctorYn; }
			set { this._fLoginDoctorYn = value; }
		}

		public OcsoOCS1003P01LayPatArgs() { }

		public OcsoOCS1003P01LayPatArgs(String fDoctor, String fBunho, String fNaewonDate, String fLoginDoctorYn)
		{
			this._fDoctor = fDoctor;
			this._fBunho = fBunho;
			this._fNaewonDate = fNaewonDate;
			this._fLoginDoctorYn = fLoginDoctorYn;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsoOCS1003P01LayPatRequest();
		}
	}
}