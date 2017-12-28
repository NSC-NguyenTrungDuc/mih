using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using OCS0131U00GrdOCS0131Info = IHIS.CloudConnector.Contracts.Models.Ocsa.OCS0131U00GrdOCS0131Info;
using OCS0131U00GrdOCS0132Info = IHIS.CloudConnector.Contracts.Models.Ocsa.OCS0131U00GrdOCS0132Info;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0131U00XSavePerformerArgs : IContractArgs
	{
    protected bool Equals(OCS0131U00XSavePerformerArgs other)
    {
        return string.Equals(_userId, other._userId) && Equals(_grdocs0131Info, other._grdocs0131Info) && Equals(_grdocs0132Info, other._grdocs0132Info);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0131U00XSavePerformerArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdocs0131Info != null ? _grdocs0131Info.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdocs0132Info != null ? _grdocs0132Info.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _userId;
		private List<OCS0131U00GrdOCS0131Info> _grdocs0131Info = new List<OCS0131U00GrdOCS0131Info>();
		private List<OCS0131U00GrdOCS0132Info> _grdocs0132Info = new List<OCS0131U00GrdOCS0132Info>();

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public List<OCS0131U00GrdOCS0131Info> Grdocs0131Info
		{
			get { return this._grdocs0131Info; }
			set { this._grdocs0131Info = value; }
		}

		public List<OCS0131U00GrdOCS0132Info> Grdocs0132Info
		{
			get { return this._grdocs0132Info; }
			set { this._grdocs0132Info = value; }
		}

		public OCS0131U00XSavePerformerArgs() { }

		public OCS0131U00XSavePerformerArgs(String userId, List<OCS0131U00GrdOCS0131Info> grdocs0131Info, List<OCS0131U00GrdOCS0132Info> grdocs0132Info)
		{
			this._userId = userId;
			this._grdocs0131Info = grdocs0131Info;
			this._grdocs0132Info = grdocs0132Info;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0131U00XSavePerformerRequest();
		}
	}
}