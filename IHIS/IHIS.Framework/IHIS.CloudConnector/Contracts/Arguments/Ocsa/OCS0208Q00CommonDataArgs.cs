using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using ComboDataSourceInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.ComboDataSourceInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0208Q00CommonDataArgs : IContractArgs
	{
    protected bool Equals(OCS0208Q00CommonDataArgs other)
    {
        return Equals(_dvTimeInfo, other._dvTimeInfo) && Equals(_dvInfo, other._dvInfo) && string.Equals(_bogyongCode, other._bogyongCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0208Q00CommonDataArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_dvTimeInfo != null ? _dvTimeInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_dvInfo != null ? _dvInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bogyongCode != null ? _bogyongCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private ComboDataSourceInfo _dvTimeInfo;
		private ComboDataSourceInfo _dvInfo;
		private String _bogyongCode;

		public ComboDataSourceInfo DvTimeInfo
		{
			get { return this._dvTimeInfo; }
			set { this._dvTimeInfo = value; }
		}

		public ComboDataSourceInfo DvInfo
		{
			get { return this._dvInfo; }
			set { this._dvInfo = value; }
		}

		public String BogyongCode
		{
			get { return this._bogyongCode; }
			set { this._bogyongCode = value; }
		}

		public OCS0208Q00CommonDataArgs() { }

		public OCS0208Q00CommonDataArgs(ComboDataSourceInfo dvTimeInfo, ComboDataSourceInfo dvInfo, String bogyongCode)
		{
			this._dvTimeInfo = dvTimeInfo;
			this._dvInfo = dvInfo;
			this._bogyongCode = bogyongCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0208Q00CommonDataRequest();
		}
	}
}