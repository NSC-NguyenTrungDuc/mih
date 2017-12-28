using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OCS2015U06EmrRecordArgs : IContractArgs
	{
    protected bool Equals(OCS2015U06EmrRecordArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U06EmrRecordArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
        }
    }

    private String _bunho;
		private String _hospCode;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String HospCode
		{
			get { return this._hospCode; }
			set { this._hospCode = value; }
		}

		public OCS2015U06EmrRecordArgs() { }

		public OCS2015U06EmrRecordArgs(String bunho, String hospCode)
		{
			this._bunho = bunho;
			this._hospCode = hospCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U06EmrRecordRequest();
		}
	}
}