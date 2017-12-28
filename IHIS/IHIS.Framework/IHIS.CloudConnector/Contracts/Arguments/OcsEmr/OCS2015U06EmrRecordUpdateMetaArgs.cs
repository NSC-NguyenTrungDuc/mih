using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OCS2015U06EmrRecordUpdateMetaArgs : IContractArgs
	{
    protected bool Equals(OCS2015U06EmrRecordUpdateMetaArgs other)
    {
        return string.Equals(_fRecordId, other._fRecordId) && string.Equals(_fMeta, other._fMeta);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U06EmrRecordUpdateMetaArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_fRecordId != null ? _fRecordId.GetHashCode() : 0)*397) ^ (_fMeta != null ? _fMeta.GetHashCode() : 0);
        }
    }

    private String _fRecordId;
		private String _fMeta;

		public String FRecordId
		{
			get { return this._fRecordId; }
			set { this._fRecordId = value; }
		}

		public String FMeta
		{
			get { return this._fMeta; }
			set { this._fMeta = value; }
		}

		public OCS2015U06EmrRecordUpdateMetaArgs() { }

		public OCS2015U06EmrRecordUpdateMetaArgs(String fRecordId, String fMeta)
		{
			this._fRecordId = fRecordId;
			this._fMeta = fMeta;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U06EmrRecordUpdateMetaRequest();
		}
	}
}