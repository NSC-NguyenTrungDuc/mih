using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OCS2015U00SelectEmrRecordByPkout1001Args : IContractArgs
	{
    protected bool Equals(OCS2015U00SelectEmrRecordByPkout1001Args other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_hospCode, other._hospCode) && string.Equals(_pkout1001, other._pkout1001);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U00SelectEmrRecordByPkout1001Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _bunho;
		private String _hospCode;
		private String _pkout1001;

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

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public OCS2015U00SelectEmrRecordByPkout1001Args() { }

		public OCS2015U00SelectEmrRecordByPkout1001Args(String bunho, String hospCode, String pkout1001)
		{
			this._bunho = bunho;
			this._hospCode = hospCode;
			this._pkout1001 = pkout1001;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U00SelectEmrRecordByPkout1001Request();
		}
	}
}