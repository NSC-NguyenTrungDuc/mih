using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using SCH3001U00GrdSCH3100Info = IHIS.CloudConnector.Contracts.Models.Schs.SCH3001U00GrdSCH3100Info;
using SCH3001U00GrdSCH3101Info = IHIS.CloudConnector.Contracts.Models.Schs.SCH3001U00GrdSCH3101Info;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SCH3001U00BtnMake2SaveLayoutArgs : IContractArgs
	{
    protected bool Equals(SCH3001U00BtnMake2SaveLayoutArgs other)
    {
        return Equals(_grdSch3101Info, other._grdSch3101Info) && Equals(_grdSch3100Info, other._grdSch3100Info) && string.Equals(_sysId, other._sysId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH3001U00BtnMake2SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_grdSch3101Info != null ? _grdSch3101Info.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdSch3100Info != null ? _grdSch3100Info.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_sysId != null ? _sysId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private List<SCH3001U00GrdSCH3101Info> _grdSch3101Info = new List<SCH3001U00GrdSCH3101Info>();
		private List<SCH3001U00GrdSCH3100Info> _grdSch3100Info = new List<SCH3001U00GrdSCH3100Info>();
		private String _sysId;

		public List<SCH3001U00GrdSCH3101Info> GrdSch3101Info
		{
			get { return this._grdSch3101Info; }
			set { this._grdSch3101Info = value; }
		}

		public List<SCH3001U00GrdSCH3100Info> GrdSch3100Info
		{
			get { return this._grdSch3100Info; }
			set { this._grdSch3100Info = value; }
		}

		public String SysId
		{
			get { return this._sysId; }
			set { this._sysId = value; }
		}

		public SCH3001U00BtnMake2SaveLayoutArgs() { }

		public SCH3001U00BtnMake2SaveLayoutArgs(List<SCH3001U00GrdSCH3101Info> grdSch3101Info, List<SCH3001U00GrdSCH3100Info> grdSch3100Info, String sysId)
		{
			this._grdSch3101Info = grdSch3101Info;
			this._grdSch3100Info = grdSch3100Info;
			this._sysId = sysId;
		}

		public IExtensible GetRequestInstance()
		{
			return new SCH3001U00BtnMake2SaveLayoutRequest();
		}
	}
}