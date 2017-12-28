using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0503U00GetFindWorkerArgs : IContractArgs
	{
    protected bool Equals(OCS0503U00GetFindWorkerArgs other)
    {
        return string.Equals(_findMode, other._findMode) && string.Equals(_refCode, other._refCode) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_mInOutGubun, other._mInOutGubun);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0503U00GetFindWorkerArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_findMode != null ? _findMode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_refCode != null ? _refCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_mInOutGubun != null ? _mInOutGubun.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _findMode;
		private String _refCode;
		private String _naewonDate;
		private String _mInOutGubun;

		public String FindMode
		{
			get { return this._findMode; }
			set { this._findMode = value; }
		}

		public String RefCode
		{
			get { return this._refCode; }
			set { this._refCode = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String MInOutGubun
		{
			get { return this._mInOutGubun; }
			set { this._mInOutGubun = value; }
		}

		public OCS0503U00GetFindWorkerArgs() { }

		public OCS0503U00GetFindWorkerArgs(String findMode, String refCode, String naewonDate, String mInOutGubun)
		{
			this._findMode = findMode;
			this._refCode = refCode;
			this._naewonDate = naewonDate;
			this._mInOutGubun = mInOutGubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0503U00GetFindWorkerRequest();
		}
	}
}