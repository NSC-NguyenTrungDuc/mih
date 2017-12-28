using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SchsSCH0201U99ExecEtcInsertArgs : IContractArgs
	{
    protected bool Equals(SchsSCH0201U99ExecEtcInsertArgs other)
    {
        return string.Equals(_iBunho, other._iBunho) && string.Equals(_iJundalTable, other._iJundalTable) && string.Equals(_iJundalPart, other._iJundalPart) && string.Equals(_iHangmogCode, other._iHangmogCode) && string.Equals(_iUserId, other._iUserId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201U99ExecEtcInsertArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_iBunho != null ? _iBunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_iJundalTable != null ? _iJundalTable.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_iJundalPart != null ? _iJundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_iHangmogCode != null ? _iHangmogCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_iUserId != null ? _iUserId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _iBunho;
		private String _iJundalTable;
		private String _iJundalPart;
		private String _iHangmogCode;
		private String _iUserId;

		public String IBunho
		{
			get { return this._iBunho; }
			set { this._iBunho = value; }
		}

		public String IJundalTable
		{
			get { return this._iJundalTable; }
			set { this._iJundalTable = value; }
		}

		public String IJundalPart
		{
			get { return this._iJundalPart; }
			set { this._iJundalPart = value; }
		}

		public String IHangmogCode
		{
			get { return this._iHangmogCode; }
			set { this._iHangmogCode = value; }
		}

		public String IUserId
		{
			get { return this._iUserId; }
			set { this._iUserId = value; }
		}

		public SchsSCH0201U99ExecEtcInsertArgs() { }

		public SchsSCH0201U99ExecEtcInsertArgs(String iBunho, String iJundalTable, String iJundalPart, String iHangmogCode, String iUserId)
		{
			this._iBunho = iBunho;
			this._iJundalTable = iJundalTable;
			this._iJundalPart = iJundalPart;
			this._iHangmogCode = iHangmogCode;
			this._iUserId = iUserId;
		}

		public IExtensible GetRequestInstance()
		{
			return new SchsSCH0201U99ExecEtcInsertRequest();
		}
	}
}