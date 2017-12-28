using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using Ocs0131U01Grd0131ListItemInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.Ocs0131U01Grd0131ListItemInfo;
using Ocs0131U01Grd0132ListItemInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.Ocs0131U01Grd0132ListItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class Ocs0131U01SaveLayoutArgs : IContractArgs
	{
    protected bool Equals(Ocs0131U01SaveLayoutArgs other)
    {
        return Equals(_grd0131Item, other._grd0131Item) && Equals(_grd0132Item, other._grd0132Item) && string.Equals(_userId, other._userId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Ocs0131U01SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_grd0131Item != null ? _grd0131Item.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grd0132Item != null ? _grd0132Item.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private List<Ocs0131U01Grd0131ListItemInfo> _grd0131Item = new List<Ocs0131U01Grd0131ListItemInfo>();
		private List<Ocs0131U01Grd0132ListItemInfo> _grd0132Item = new List<Ocs0131U01Grd0132ListItemInfo>();
		private String _userId;

		public List<Ocs0131U01Grd0131ListItemInfo> Grd0131Item
		{
			get { return this._grd0131Item; }
			set { this._grd0131Item = value; }
		}

		public List<Ocs0131U01Grd0132ListItemInfo> Grd0132Item
		{
			get { return this._grd0132Item; }
			set { this._grd0132Item = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public Ocs0131U01SaveLayoutArgs() { }

		public Ocs0131U01SaveLayoutArgs(List<Ocs0131U01Grd0131ListItemInfo> grd0131Item, List<Ocs0131U01Grd0132ListItemInfo> grd0132Item, String userId)
		{
			this._grd0131Item = grd0131Item;
			this._grd0132Item = grd0132Item;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new Ocs0131U01SaveLayoutRequest();
		}
	}
}