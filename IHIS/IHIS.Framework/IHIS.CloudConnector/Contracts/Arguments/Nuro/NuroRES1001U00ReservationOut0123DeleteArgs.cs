using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class NuroRES1001U00ReservationOut0123DeleteArgs : IContractArgs
	{
        protected bool Equals(NuroRES1001U00ReservationOut0123DeleteArgs other)
        {
            return string.Equals(_patientCode, other._patientCode) && string.Equals(_pkout1001, other._pkout1001);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES1001U00ReservationOut0123DeleteArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_patientCode != null ? _patientCode.GetHashCode() : 0)*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
            }
        }

        private String _patientCode;
		private String _pkout1001;

		public String PatientCode
		{
			get { return this._patientCode; }
			set { this._patientCode = value; }
		}

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public NuroRES1001U00ReservationOut0123DeleteArgs() { }

		public NuroRES1001U00ReservationOut0123DeleteArgs(String patientCode, String pkout1001)
		{
			this._patientCode = patientCode;
			this._pkout1001 = pkout1001;
		}

		public IExtensible GetRequestInstance()
		{
			return new NuroRES1001U00ReservationOut0123DeleteRequest();
		}
	}
}