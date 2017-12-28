using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class InjsINJ1001U01LabelNewListArgs : IContractArgs
	{
        protected bool Equals(InjsINJ1001U01LabelNewListArgs other)
        {
            return string.Equals(_mixGroup, other._mixGroup) && string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_jubsuDate, other._jubsuDate) && string.Equals(_groupSer, other._groupSer) && string.Equals(_fkinj1001, other._fkinj1001);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((InjsINJ1001U01LabelNewListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_mixGroup != null ? _mixGroup.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuDate != null ? _jubsuDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_groupSer != null ? _groupSer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fkinj1001 != null ? _fkinj1001.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _mixGroup;
		private String _bunho;
		private String _gwa;
		private String _doctor;
		private String _jubsuDate;
		private String _groupSer;
		private String _fkinj1001;

		public String MixGroup
		{
			get { return this._mixGroup; }
			set { this._mixGroup = value; }
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

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String JubsuDate
		{
			get { return this._jubsuDate; }
			set { this._jubsuDate = value; }
		}

		public String GroupSer
		{
			get { return this._groupSer; }
			set { this._groupSer = value; }
		}

		public String Fkinj1001
		{
			get { return this._fkinj1001; }
			set { this._fkinj1001 = value; }
		}

		public InjsINJ1001U01LabelNewListArgs() { }

		public InjsINJ1001U01LabelNewListArgs(String mixGroup, String bunho, String gwa, String doctor, String jubsuDate, String groupSer, String fkinj1001)
		{
			this._mixGroup = mixGroup;
			this._bunho = bunho;
			this._gwa = gwa;
			this._doctor = doctor;
			this._jubsuDate = jubsuDate;
			this._groupSer = groupSer;
			this._fkinj1001 = fkinj1001;
		}

		public IExtensible GetRequestInstance()
		{
			return new InjsINJ1001U01LabelNewListRequest();
		}
	}
}