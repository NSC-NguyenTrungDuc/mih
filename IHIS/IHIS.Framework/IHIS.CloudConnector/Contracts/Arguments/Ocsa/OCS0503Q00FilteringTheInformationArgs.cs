using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0503Q00FilteringTheInformationArgs : IContractArgs
	{
    protected bool Equals(OCS0503Q00FilteringTheInformationArgs other)
    {
        return string.Equals(_grdConsultNaewonDate, other._grdConsultNaewonDate) && string.Equals(_grdConsultBunho, other._grdConsultBunho) && string.Equals(_gridRequestNaewonDate, other._gridRequestNaewonDate) && string.Equals(_gridRequestBunho, other._gridRequestBunho);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0503Q00FilteringTheInformationArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_grdConsultNaewonDate != null ? _grdConsultNaewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdConsultBunho != null ? _grdConsultBunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gridRequestNaewonDate != null ? _gridRequestNaewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gridRequestBunho != null ? _gridRequestBunho.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _grdConsultNaewonDate;
		private String _grdConsultBunho;
		private String _gridRequestNaewonDate;
		private String _gridRequestBunho;

		public String GrdConsultNaewonDate
		{
			get { return this._grdConsultNaewonDate; }
			set { this._grdConsultNaewonDate = value; }
		}

		public String GrdConsultBunho
		{
			get { return this._grdConsultBunho; }
			set { this._grdConsultBunho = value; }
		}

		public String GridRequestNaewonDate
		{
			get { return this._gridRequestNaewonDate; }
			set { this._gridRequestNaewonDate = value; }
		}

		public String GridRequestBunho
		{
			get { return this._gridRequestBunho; }
			set { this._gridRequestBunho = value; }
		}

		public OCS0503Q00FilteringTheInformationArgs() { }

		public OCS0503Q00FilteringTheInformationArgs(String grdConsultNaewonDate, String grdConsultBunho, String gridRequestNaewonDate, String gridRequestBunho)
		{
			this._grdConsultNaewonDate = grdConsultNaewonDate;
			this._grdConsultBunho = grdConsultBunho;
			this._gridRequestNaewonDate = gridRequestNaewonDate;
			this._gridRequestBunho = gridRequestBunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0503Q00FilteringTheInformationRequest();
		}
	}
}