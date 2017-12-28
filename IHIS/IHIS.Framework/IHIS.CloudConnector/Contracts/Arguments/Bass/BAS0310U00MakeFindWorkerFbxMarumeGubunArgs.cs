using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0310U00MakeFindWorkerFbxMarumeGubunArgs : IContractArgs
	{
        protected bool Equals(BAS0310U00MakeFindWorkerFbxMarumeGubunArgs other)
        {
            return string.Equals(_find, other._find) && string.Equals(_codeType, other._codeType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0310U00MakeFindWorkerFbxMarumeGubunArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_find != null ? _find.GetHashCode() : 0)*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
            }
        }

        private String _find;
		private String _codeType;

		public String Find
		{
			get { return this._find; }
			set { this._find = value; }
		}

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public BAS0310U00MakeFindWorkerFbxMarumeGubunArgs() { }

		public BAS0310U00MakeFindWorkerFbxMarumeGubunArgs(String find, String codeType)
		{
			this._find = find;
			this._codeType = codeType;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0310U00MakeFindWorkerFbxMarumeGubunRequest();
		}
	}
}