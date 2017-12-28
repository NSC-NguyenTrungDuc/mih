using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCSAPPROVEGrdPatientListArgs : IContractArgs
	{
    protected bool Equals(OCSAPPROVEGrdPatientListArgs other)
    {
        return string.Equals(_inputGubun, other._inputGubun) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_doctor, other._doctor) && string.Equals(_insteadYn, other._insteadYn) && string.Equals(_approveYn, other._approveYn) && string.Equals(_inputTab, other._inputTab);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSAPPROVEGrdPatientListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_inputGubun != null ? _inputGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_insteadYn != null ? _insteadYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_approveYn != null ? _approveYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _inputGubun;
		private String _ioGubun;
		private String _doctor;
		private String _insteadYn;
		private String _approveYn;
		private String _inputTab;

		public String InputGubun
		{
			get { return this._inputGubun; }
			set { this._inputGubun = value; }
		}

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String InsteadYn
		{
			get { return this._insteadYn; }
			set { this._insteadYn = value; }
		}

		public String ApproveYn
		{
			get { return this._approveYn; }
			set { this._approveYn = value; }
		}

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public OCSAPPROVEGrdPatientListArgs() { }

		public OCSAPPROVEGrdPatientListArgs(String inputGubun, String ioGubun, String doctor, String insteadYn, String approveYn, String inputTab)
		{
			this._inputGubun = inputGubun;
			this._ioGubun = ioGubun;
			this._doctor = doctor;
			this._insteadYn = insteadYn;
			this._approveYn = approveYn;
			this._inputTab = inputTab;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCSAPPROVEGrdPatientListRequest();
		}
	}
}