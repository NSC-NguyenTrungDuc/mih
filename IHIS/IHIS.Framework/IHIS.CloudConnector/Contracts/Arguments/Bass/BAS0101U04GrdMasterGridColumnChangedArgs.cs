using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0101U04GrdMasterGridColumnChangedArgs : IContractArgs
	{
        protected bool Equals(BAS0101U04GrdMasterGridColumnChangedArgs other)
        {
            return string.Equals(_masterCheck, other._masterCheck) && string.Equals(_codeType, other._codeType) && string.Equals(_colId, other._colId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0101U04GrdMasterGridColumnChangedArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_masterCheck != null ? _masterCheck.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_colId != null ? _colId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _masterCheck;
		private String _codeType;
		private String _colId;

		public String MasterCheck
		{
			get { return this._masterCheck; }
			set { this._masterCheck = value; }
		}

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public String ColId
		{
			get { return this._colId; }
			set { this._colId = value; }
		}

		public BAS0101U04GrdMasterGridColumnChangedArgs() { }

		public BAS0101U04GrdMasterGridColumnChangedArgs(String masterCheck, String codeType, String colId)
		{
			this._masterCheck = masterCheck;
			this._codeType = codeType;
			this._colId = colId;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0101U04GrdMasterGridColumnChangedRequest();
		}
	}
}