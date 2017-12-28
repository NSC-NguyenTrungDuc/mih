using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using CPL3020U00GrdNoteUpdateInfo = IHIS.CloudConnector.Contracts.Models.Cpls.CPL3020U00GrdNoteUpdateInfo;
using CPL3020U00GrdPaListItemInfo = IHIS.CloudConnector.Contracts.Models.Cpls.CPL3020U00GrdPaListItemInfo;
using CPL3020U00GrdResultListItemInfo = IHIS.CloudConnector.Contracts.Models.Cpls.CPL3020U00GrdResultListItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3020U02SaveArgs : IContractArgs
	{
        protected bool Equals(CPL3020U02SaveArgs other)
        {
            return Equals(_grdResultItemInfo, other._grdResultItemInfo) && Equals(_grdNoteUpdateItemInfo, other._grdNoteUpdateItemInfo) && Equals(_grdPaItemInfo, other._grdPaItemInfo) && string.Equals(_userId, other._userId) && string.Equals(_gumsaja, other._gumsaja);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U02SaveArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_grdResultItemInfo != null ? _grdResultItemInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grdNoteUpdateItemInfo != null ? _grdNoteUpdateItemInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grdPaItemInfo != null ? _grdPaItemInfo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gumsaja != null ? _gumsaja.GetHashCode() : 0);
                return hashCode;
            }
        }

        private List<CPL3020U00GrdResultListItemInfo> _grdResultItemInfo = new List<CPL3020U00GrdResultListItemInfo>();
		private List<CPL3020U00GrdNoteUpdateInfo> _grdNoteUpdateItemInfo = new List<CPL3020U00GrdNoteUpdateInfo>();
		private List<CPL3020U00GrdPaListItemInfo> _grdPaItemInfo = new List<CPL3020U00GrdPaListItemInfo>();
		private String _userId;
		private String _gumsaja;

		public List<CPL3020U00GrdResultListItemInfo> GrdResultItemInfo
		{
			get { return this._grdResultItemInfo; }
			set { this._grdResultItemInfo = value; }
		}

		public List<CPL3020U00GrdNoteUpdateInfo> GrdNoteUpdateItemInfo
		{
			get { return this._grdNoteUpdateItemInfo; }
			set { this._grdNoteUpdateItemInfo = value; }
		}

		public List<CPL3020U00GrdPaListItemInfo> GrdPaItemInfo
		{
			get { return this._grdPaItemInfo; }
			set { this._grdPaItemInfo = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String Gumsaja
		{
			get { return this._gumsaja; }
			set { this._gumsaja = value; }
		}

		public CPL3020U02SaveArgs() { }

		public CPL3020U02SaveArgs(List<CPL3020U00GrdResultListItemInfo> grdResultItemInfo, List<CPL3020U00GrdNoteUpdateInfo> grdNoteUpdateItemInfo, List<CPL3020U00GrdPaListItemInfo> grdPaItemInfo, String userId, String gumsaja)
		{
			this._grdResultItemInfo = grdResultItemInfo;
			this._grdNoteUpdateItemInfo = grdNoteUpdateItemInfo;
			this._grdPaItemInfo = grdPaItemInfo;
			this._userId = userId;
			this._gumsaja = gumsaja;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3020U02SaveRequest();
		}
	}
}