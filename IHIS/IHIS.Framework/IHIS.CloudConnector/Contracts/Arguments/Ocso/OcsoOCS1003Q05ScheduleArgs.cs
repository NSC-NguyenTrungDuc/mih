using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OcsoOCS1003Q05ScheduleArgs : IContractArgs
	{
    protected bool Equals(OcsoOCS1003Q05ScheduleArgs other)
    {
        return string.Equals(_inputGubun, other._inputGubun) && string.Equals(_telYn, other._telYn) && string.Equals(_inputTab, other._inputTab) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_selectedInputTab, other._selectedInputTab) && string.Equals(_bunho, other._bunho) && string.Equals(_kijun, other._kijun) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_gwa, other._gwa);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsoOCS1003Q05ScheduleArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_inputGubun != null ? _inputGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_telYn != null ? _telYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_selectedInputTab != null ? _selectedInputTab.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_kijun != null ? _kijun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _inputGubun;
		private String _telYn;
		private String _inputTab;
		private String _ioGubun;
		private String _selectedInputTab;
		private String _bunho;
		private String _kijun;
		private String _naewonDate;
		private String _gwa;

		public String InputGubun
		{
			get { return this._inputGubun; }
			set { this._inputGubun = value; }
		}

		public String TelYn
		{
			get { return this._telYn; }
			set { this._telYn = value; }
		}

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String SelectedInputTab
		{
			get { return this._selectedInputTab; }
			set { this._selectedInputTab = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Kijun
		{
			get { return this._kijun; }
			set { this._kijun = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public OcsoOCS1003Q05ScheduleArgs() { }

		public OcsoOCS1003Q05ScheduleArgs(String inputGubun, String telYn, String inputTab, String ioGubun, String selectedInputTab, String bunho, String kijun, String naewonDate, String gwa)
		{
			this._inputGubun = inputGubun;
			this._telYn = telYn;
			this._inputTab = inputTab;
			this._ioGubun = ioGubun;
			this._selectedInputTab = selectedInputTab;
			this._bunho = bunho;
			this._kijun = kijun;
			this._naewonDate = naewonDate;
			this._gwa = gwa;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsoOCS1003Q05ScheduleRequest();
		}
	}
}