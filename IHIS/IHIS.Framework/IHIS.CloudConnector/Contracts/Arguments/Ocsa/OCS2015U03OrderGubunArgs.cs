using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OCS2015U03OrderGubunArgs : IContractArgs
	{
    protected bool Equals(OCS2015U03OrderGubunArgs other)
    {
        return string.Equals(_fHopitalCode, other._fHopitalCode) && string.Equals(_fPatientCode, other._fPatientCode) && string.Equals(_fReservationCode, other._fReservationCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U03OrderGubunArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_fHopitalCode != null ? _fHopitalCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fPatientCode != null ? _fPatientCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fReservationCode != null ? _fReservationCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _fHopitalCode;
		private String _fPatientCode;
		private String _fReservationCode;

		public String FHopitalCode
		{
			get { return this._fHopitalCode; }
			set { this._fHopitalCode = value; }
		}

		public String FPatientCode
		{
			get { return this._fPatientCode; }
			set { this._fPatientCode = value; }
		}

		public String FReservationCode
		{
			get { return this._fReservationCode; }
			set { this._fReservationCode = value; }
		}

		public OCS2015U03OrderGubunArgs() { }

		public OCS2015U03OrderGubunArgs(String fHopitalCode, String fPatientCode, String fReservationCode)
		{
			this._fHopitalCode = fHopitalCode;
			this._fPatientCode = fPatientCode;
			this._fReservationCode = fReservationCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U03OrderGubunRequest();
		}
	}
}