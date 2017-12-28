using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OcsaOCS0503U01GrdOCS0503ListArgs : IContractArgs
	{
    protected bool Equals(OcsaOCS0503U01GrdOCS0503ListArgs other)
    {
        return string.Equals(_reqDate, other._reqDate) && string.Equals(_fBunho, other._fBunho) && string.Equals(_consultDoctor, other._consultDoctor);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsaOCS0503U01GrdOCS0503ListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_reqDate != null ? _reqDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fBunho != null ? _fBunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_consultDoctor != null ? _consultDoctor.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _reqDate;
		private String _fBunho;
		private String _consultDoctor;

		public String ReqDate
		{
			get { return this._reqDate; }
			set { this._reqDate = value; }
		}

		public String FBunho
		{
			get { return this._fBunho; }
			set { this._fBunho = value; }
		}

		public String ConsultDoctor
		{
			get { return this._consultDoctor; }
			set { this._consultDoctor = value; }
		}

		public OcsaOCS0503U01GrdOCS0503ListArgs() { }

		public OcsaOCS0503U01GrdOCS0503ListArgs(String reqDate, String fBunho, String consultDoctor)
		{
			this._reqDate = reqDate;
			this._fBunho = fBunho;
			this._consultDoctor = consultDoctor;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsaOCS0503U01GrdOCS0503ListRequest();
		}
	}
}