using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0310U00MakeFindWorker2Args : IContractArgs
	{
        protected bool Equals(BAS0310U00MakeFindWorker2Args other)
        {
            return string.Equals(_find, other._find);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0310U00MakeFindWorker2Args) obj);
        }

        public override int GetHashCode()
        {
            return (_find != null ? _find.GetHashCode() : 0);
        }

        private String _find;

		public String Find
		{
			get { return this._find; }
			set { this._find = value; }
		}

		public BAS0310U00MakeFindWorker2Args() { }

		public BAS0310U00MakeFindWorker2Args(String find)
		{
			this._find = find;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0310U00MakeFindWorker2Request();
		}
	}
}