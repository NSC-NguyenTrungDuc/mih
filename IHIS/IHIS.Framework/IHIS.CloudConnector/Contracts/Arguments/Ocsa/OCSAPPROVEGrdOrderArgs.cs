using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCSAPPROVEGrdOrderArgs : IContractArgs
	{
    protected bool Equals(OCSAPPROVEGrdOrderArgs other)
    {
        return string.Equals(_pkOrder, other._pkOrder) && string.Equals(_inputTab, other._inputTab) && string.Equals(_insteadYn, other._insteadYn) && string.Equals(_approveYn, other._approveYn) && string.Equals(_prepostGubun, other._prepostGubun) && string.Equals(_bunho, other._bunho) && string.Equals(_jubsuNo, other._jubsuNo) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_doctor, other._doctor);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSAPPROVEGrdOrderArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_pkOrder != null ? _pkOrder.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_insteadYn != null ? _insteadYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_approveYn != null ? _approveYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_prepostGubun != null ? _prepostGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jubsuNo != null ? _jubsuNo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _pkOrder;
		private String _inputTab;
		private String _insteadYn;
		private String _approveYn;
		private String _prepostGubun;
		private String _bunho;
		private String _jubsuNo;
		private String _naewonDate;
		private String _doctor;

		public String PkOrder
		{
			get { return this._pkOrder; }
			set { this._pkOrder = value; }
		}

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
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

		public String PrepostGubun
		{
			get { return this._prepostGubun; }
			set { this._prepostGubun = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String JubsuNo
		{
			get { return this._jubsuNo; }
			set { this._jubsuNo = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public OCSAPPROVEGrdOrderArgs() { }

		public OCSAPPROVEGrdOrderArgs(String pkOrder, String inputTab, String insteadYn, String approveYn, String prepostGubun, String bunho, String jubsuNo, String naewonDate, String doctor)
		{
			this._pkOrder = pkOrder;
			this._inputTab = inputTab;
			this._insteadYn = insteadYn;
			this._approveYn = approveYn;
			this._prepostGubun = prepostGubun;
			this._bunho = bunho;
			this._jubsuNo = jubsuNo;
			this._naewonDate = naewonDate;
			this._doctor = doctor;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCSAPPROVEGrdOrderRequest();
		}
	}
}