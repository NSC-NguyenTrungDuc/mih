using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using OCS0150Q00GridOCS0150Info = IHIS.CloudConnector.Contracts.Models.Ocsa.OCS0150Q00GridOCS0150Info;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0150Q00SaveLayoutForGridOCS0150Args : IContractArgs
	{
    protected bool Equals(OCS0150Q00SaveLayoutForGridOCS0150Args other)
    {
        return string.Equals(_userId, other._userId) && Equals(_gridOcs0150Info, other._gridOcs0150Info);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0150Q00SaveLayoutForGridOCS0150Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_gridOcs0150Info != null ? _gridOcs0150Info.GetHashCode() : 0);
        }
    }

    private List<OCS0150Q00GridOCS0150Info> _gridOcs0150Info = new List<OCS0150Q00GridOCS0150Info>();
		private String _userId;

		public List<OCS0150Q00GridOCS0150Info> GridOcs0150Info
		{
			get { return this._gridOcs0150Info; }
			set { this._gridOcs0150Info = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public OCS0150Q00SaveLayoutForGridOCS0150Args() { }

		public OCS0150Q00SaveLayoutForGridOCS0150Args(List<OCS0150Q00GridOCS0150Info> gridOcs0150Info, String userId)
		{
			this._gridOcs0150Info = gridOcs0150Info;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0150Q00SaveLayoutForGridOCS0150Request();
		}
	}
}