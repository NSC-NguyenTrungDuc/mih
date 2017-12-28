using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OCS2015U04LoadBookmarkByPk0ut1001Args : IContractArgs
	{
    protected bool Equals(OCS2015U04LoadBookmarkByPk0ut1001Args other)
    {
        return string.Equals(_emrRecordId, other._emrRecordId) && string.Equals(_pkout1001, other._pkout1001) && string.Equals(_sysId, other._sysId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U04LoadBookmarkByPk0ut1001Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_emrRecordId != null ? _emrRecordId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_sysId != null ? _sysId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _emrRecordId;
		private String _pkout1001;
		private String _sysId;

		public String EmrRecordId
		{
			get { return this._emrRecordId; }
			set { this._emrRecordId = value; }
		}

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public String SysId
		{
			get { return this._sysId; }
			set { this._sysId = value; }
		}

		public OCS2015U04LoadBookmarkByPk0ut1001Args() { }

		public OCS2015U04LoadBookmarkByPk0ut1001Args(String emrRecordId, String pkout1001, String sysId)
		{
			this._emrRecordId = emrRecordId;
			this._pkout1001 = pkout1001;
			this._sysId = sysId;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U04LoadBookmarkByPk0ut1001Request();
		}
	}
}